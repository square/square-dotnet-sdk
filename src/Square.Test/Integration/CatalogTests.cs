using System.Text.Json;
using NUnit.Framework;
using Square.Catalog;
using Square.Catalog.Images;
using Square.Catalog.Object;
using Square.Core;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace Square.Test.Integration;

[TestFixture]
public class CatalogTests
{
    private readonly SquareClient _client = Helpers.CreateClient();
    private string? _catalogObjectId;
    private string? _catalogModifierId;
    private string? _catalogModifierListId;
    private string? _catalogTaxId;

    [SetUp]
    public async Task SetUp()
    {
        var catalogItem = Helpers.CreateTestCatalogItem(new Helpers.CreateCatalogItemOptions());
        var catalogResponse = await _client.Catalog.Object.UpsertAsync(
            new UpsertCatalogObjectRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Object = catalogItem,
            }
        );
        var catalogObject =
            catalogResponse.CatalogObject
            ?? throw new Exception("Failed to create test catalog item");
        var catalogObjectItem = catalogObject.AsItem() ?? throw new Exception("Item data is null");
        _catalogObjectId = catalogObjectItem.Id ?? throw new Exception("Catalog object ID is null");
    }

    [Test]
    public async Task TestBulkCreateAndPaginateCatalogObjects()
    {
        await DeleteAllCatalogObjectsAsync();
        var catalogObjects = new List<CatalogObject>();
        for (var i = 0; i < 100; i++)
        {
            catalogObjects.Add(
                Helpers.CreateTestCatalogItem(new Helpers.CreateCatalogItemOptions())
            );
        }

        var createCatalogObjectsResp = await _client.Catalog.BatchUpsertAsync(
            new BatchUpsertCatalogObjectsRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Batches = [new CatalogObjectBatch { Objects = catalogObjects }],
            }
        );

        var objects = createCatalogObjectsResp.Objects ?? throw new Exception("Objects are null");
        Assert.That(objects.Count, Is.EqualTo(100));

        var numberOfPages = 0;
        var catalogObjectsResp = await _client.Catalog.ListAsync(new ListCatalogRequest());
        var allObjects = new List<CatalogObject>();

        await foreach (var page in catalogObjectsResp.AsPagesAsync())
        {
            allObjects.AddRange(page);
            numberOfPages++;
        }

        Assert.That(numberOfPages, Is.GreaterThan(0));

        var deleteCatalogObjectsResp = await _client.Catalog.BatchDeleteAsync(
            new BatchDeleteCatalogObjectsRequest
            {
                ObjectIds =
                [
                    .. allObjects.Select(o =>
                        JsonUtils.SerializeToElement(o).GetProperty("id").GetString()
                        ?? throw new Exception("Item data is null")
                    ),
                ],
            }
        );

        var deletedObjectIds =
            deleteCatalogObjectsResp.DeletedObjectIds
            ?? throw new Exception("Deleted object IDs are null");
        Assert.That(deletedObjectIds.Count, Is.EqualTo(200));
    }

    [Test]
    public async Task TestUploadCatalogImage()
    {
        var catalogObject = Helpers.CreateTestCatalogItem(new Helpers.CreateCatalogItemOptions());
        var createCatalogResp = await _client.Catalog.BatchUpsertAsync(
            new BatchUpsertCatalogObjectsRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Batches = [new CatalogObjectBatch { Objects = [catalogObject] }],
            }
        );

        var objects =
            createCatalogResp.Objects?.ToArray() ?? throw new Exception("Objects are null");
        Assert.That(objects, Has.Length.EqualTo(1));
        var createdCatalogObject = objects.First();
        var catalogObjectItem =
            createdCatalogObject.AsItem() ?? throw new Exception("Item data is null");

        var imageName = "Test Image " + Guid.NewGuid();
        await using var fileParam = Helpers.GetTestFile();
        var createCatalogImageResp = await _client.Catalog.Images.CreateAsync(
            new CreateImagesRequest
            {
                ImageFile = fileParam,
                Request = new CreateCatalogImageRequest
                {
                    IdempotencyKey = Guid.NewGuid().ToString(),
                    Image = new CatalogObject(
                        new CatalogObjectImage
                        {
                            Id = Helpers.NewTestSquareId(),
                            ImageData = new CatalogImage { Name = imageName },
                        }
                    ),
                    ObjectId = catalogObjectItem.Id,
                },
            }
        );

        var image =
            createCatalogImageResp.Image?.AsImage() ?? throw new Exception("Image data is null");
        Assert.That(image, Is.Not.Null);

        await _client.Catalog.BatchDeleteAsync(
            new BatchDeleteCatalogObjectsRequest { ObjectIds = [catalogObjectItem.Id, image.Id] }
        );
    }

    [Test]
    public async Task TestUpsertCatalogObject()
    {
        var coffee = Helpers.CreateTestCatalogItem(
            new Helpers.CreateCatalogItemOptions
            {
                Name = "Coffee",
                Description = "Strong coffee",
                Abbreviation = "C",
                VariationName = "Colombian Fair Trade",
            }
        );

        var response = await _client.Catalog.Object.UpsertAsync(
            new UpsertCatalogObjectRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Object = coffee,
            }
        );

        var catalogObject = response.CatalogObject ?? throw new Exception("Catalog object is null");
        Assert.That(catalogObject.IsItem, Is.True);
        var item = catalogObject.AsItem() ?? throw new Exception("Item data is null");
        var itemData = item.ItemData ?? throw new Exception("Item data is null");
        var variations =
            itemData.Variations?.ToArray() ?? throw new Exception("Variations are null");
        Assert.That(variations, Has.Length.EqualTo(1));

        var variationObject = variations.First();
        var variation =
            variationObject.AsItemVariation().ItemVariationData
            ?? throw new Exception("Item variation data is null");
        Assert.That(variation.Name, Is.EqualTo("Colombian Fair Trade"));
    }

    [Test]
    public async Task TestCatalogInfo()
    {
        var response = await _client.Catalog.InfoAsync();
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestSearchCatalogObjects()
    {
        var searchRequest = new SearchCatalogObjectsRequest { Limit = 1 };
        var response = await _client.Catalog.SearchAsync(searchRequest);
        var objects = response.Objects ?? throw new Exception("Objects are null");
        Assert.That(objects, Is.Not.Empty);
    }

    [Test]
    public async Task TestSearchCatalogItems()
    {
        var response = await _client.Catalog.SearchItemsAsync(
            new SearchCatalogItemsRequest { Limit = 1 }
        );
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestBatchUpsertCatalogObjects()
    {
        var modifier = new CatalogObject(
            new CatalogObjectModifier
            {
                Id = "#temp-modifier-id",
                ModifierData = new CatalogModifier
                {
                    Name = "Limited Time Only Price",
                    PriceMoney = Helpers.NewTestMoney(200),
                },
            }
        );

        var modifierList = new CatalogObject(
            new CatalogObjectModifierList
            {
                Id = "#temp-modifier-list-id",
                ModifierListData = new CatalogModifierList
                {
                    Name = "Special weekend deals",
                    Modifiers = [modifier],
                },
            }
        );

        var tax = new CatalogObject(
            new CatalogObjectTax
            {
                Id = "#temp-tax-id",
                TaxData = new CatalogTax
                {
                    Name = "Online only Tax",
                    CalculationPhase = TaxCalculationPhase.TaxSubtotalPhase,
                    InclusionType = TaxInclusionType.Additive,
                    Percentage = "5.0",
                    AppliesToCustomAmounts = true,
                    Enabled = true,
                },
            }
        );

        var response = await _client.Catalog.BatchUpsertAsync(
            new BatchUpsertCatalogObjectsRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Batches = [new CatalogObjectBatch { Objects = [tax, modifierList] }],
            }
        );

        var objects = response.Objects ?? throw new Exception("Objects are null");
        Assert.That(objects.Count, Is.EqualTo(2));

        var idMappings =
            response.IdMappings?.ToArray() ?? throw new Exception("ID mappings are null");

        _catalogTaxId =
            idMappings.First(mapping => mapping.ClientObjectId == "#temp-tax-id").ObjectId
            ?? throw new Exception("Tax ID is null");
        _catalogModifierId =
            idMappings.First(mapping => mapping.ClientObjectId == "#temp-modifier-id").ObjectId
            ?? throw new Exception("Modifier ID is null");
        _catalogModifierListId =
            idMappings.First(mapping => mapping.ClientObjectId == "#temp-modifier-list-id").ObjectId
            ?? throw new Exception("Modifier list ID is null");
    }

    [Test]
    public async Task TestBatchRetrieveCatalogObjects()
    {
        await TestBatchUpsertCatalogObjects();

        var response = await _client.Catalog.BatchGetAsync(
            new BatchGetCatalogObjectsRequest
            {
                ObjectIds = [_catalogModifierId!, _catalogModifierListId!, _catalogTaxId!],
            }
        );

        var objects = response.Objects?.ToArray() ?? throw new Exception("Objects are null");
        Assert.That(objects, Has.Length.EqualTo(3));
        var respObjectIds = objects
            .Select(obj => JsonUtils.SerializeToElement(obj.Value).GetProperty("id").GetString())
            .ToHashSet();
        Assert.That(
            respObjectIds,
            Is.EquivalentTo(
                new HashSet<string> { _catalogModifierId!, _catalogModifierListId!, _catalogTaxId! }
            )
        );
    }

    [Test]
    public async Task TestUpdateItemTaxes()
    {
        await TestBatchUpsertCatalogObjects();

        var updateRequest = new UpdateItemTaxesRequest
        {
            ItemIds = [_catalogObjectId!],
            TaxesToEnable = [_catalogTaxId!],
        };
        var response = await _client.Catalog.UpdateItemTaxesAsync(updateRequest);

        Assert.That(response.UpdatedAt, Is.Not.Null);
        Assert.That(response.Errors, Is.Null);
    }

    [Test]
    public async Task TestUpdateItemModifierLists()
    {
        await TestBatchUpsertCatalogObjects();

        var updateRequest = new UpdateItemModifierListsRequest
        {
            ItemIds = [_catalogObjectId!],
            ModifierListsToEnable = [_catalogModifierListId!],
        };
        var response = await _client.Catalog.UpdateItemModifierListsAsync(updateRequest);

        Assert.That(response.UpdatedAt, Is.Not.Null);
        Assert.That(response.Errors, Is.Null);
    }

    [Test]
    public async Task TestDeleteCatalogObject()
    {
        var deleteRequest = new DeleteObjectRequest { ObjectId = _catalogObjectId! };
        var response = await _client.Catalog.Object.DeleteAsync(deleteRequest);

        Assert.That(response, Is.Not.Null);
    }

    private async Task DeleteAllCatalogObjectsAsync()
    {
        var pager = await _client.Catalog.ListAsync(new ListCatalogRequest());
        var objectIds = new List<string>();

        await foreach (var catalogObject in pager)
        {
            var json = JsonUtils.SerializeToElement(catalogObject.Value);
            var id = json.GetProperty("id").GetString();
            if (id != null)
            {
                objectIds.Add(id);
            }

            if (!json.TryGetProperty("item_data", out var itemData))
                continue;
            if (!itemData.TryGetProperty("variations", out var variations))
                continue;
            if (variations.ValueKind == JsonValueKind.Null)
                continue;
            foreach (var variation in variations.EnumerateArray())
            {
                if (!variation.TryGetProperty("id", out var variationId))
                    continue;
                if (variationId.ValueKind == JsonValueKind.Null)
                    continue;
                objectIds.Add(variationId.GetString()!);
            }
        }

        foreach (var chunk in objectIds.Distinct().Chunk(200))
        {
            var batchDeleteRequest = new BatchDeleteCatalogObjectsRequest
            {
                ObjectIds = chunk.ToList(),
            };
            await _client.Catalog.BatchDeleteAsync(batchDeleteRequest);
        }
    }
}
