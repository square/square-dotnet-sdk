using NUnit.Framework;
using Square.Catalog.Object;
using Square.Inventory;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace Square.Test.Integration;

[TestFixture]
public class InventoryTests
{
    private readonly SquareClient _client = Helpers.CreateClient();
    private string? _locationId;
    private string? _itemVariationId;
    private string? _physicalCountId;

    [SetUp]
    public async Task SetUp()
    {
        _locationId = await Helpers.GetDefaultLocationIdAsync(_client);

        // Create test catalog object
        var catalogObject = new CatalogObject(
            new CatalogObjectItem
            {
                Id = "#single-item",
                PresentAtAllLocations = true,
                ItemData = new CatalogItem
                {
                    Name = "Coffee",
                    Description = "Strong coffee",
                    Abbreviation = "C",
                    Variations =
                    [
                        new CatalogObject(
                            new CatalogObjectItemVariation
                            {
                                Id = "#colombian-coffee",
                                PresentAtAllLocations = true,
                                ItemVariationData = new CatalogItemVariation
                                {
                                    Name = "Colombian Fair Trade",
                                    TrackInventory = true,
                                    PricingType = CatalogPricingType.FixedPricing,
                                    PriceMoney = new Money
                                    {
                                        Amount = 100,
                                        Currency = Currency.Usd,
                                    },
                                },
                            }
                        ),
                    ],
                },
            }
        );

        var catalogResponse = await _client.Catalog.Object.UpsertAsync(
            new UpsertCatalogObjectRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Object = catalogObject,
            }
        );
        var createdObject =
            catalogResponse.CatalogObject ?? throw new Exception("Catalog object is null.");

        var item = createdObject.AsItem().ItemData ?? throw new Exception("Item data is null.");
        var variations = item.Variations ?? throw new Exception("Variations are null or empty.");
        _itemVariationId =
            variations.First().AsItemVariation().Id
            ?? throw new Exception("Item variation ID is null.");

        // Create initial inventory adjustment
        var adjustment = new InventoryAdjustment
        {
            FromState = InventoryState.None,
            ToState = InventoryState.InStock,
            LocationId = _locationId,
            CatalogObjectId = _itemVariationId,
            Quantity = "100",
            OccurredAt = DateTimeOffset.Now.AddHours(-8).ToString("o"),
        };

        var changeRequest = new BatchChangeInventoryRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Changes =
            [
                new InventoryChange
                {
                    Type = InventoryChangeType.Adjustment,
                    Adjustment = adjustment,
                },
            ],
        };
        var response = await _client.Inventory.BatchCreateChangesAsync(changeRequest);

        var changes = response.Changes ?? throw new Exception("Changes are null.");
        var firstChange = changes.First();
        var firstAdjustment = firstChange.Adjustment ?? throw new Exception("Adjustment is null.");
        _ = firstAdjustment.Id ?? throw new Exception("Adjustment ID is null.");

        // Create physical count
        var physicalCount = new InventoryChange
        {
            Type = InventoryChangeType.PhysicalCount,
            PhysicalCount = new InventoryPhysicalCount
            {
                CatalogObjectId = _itemVariationId,
                LocationId = _locationId,
                Quantity = "1",
                State = InventoryState.InStock,
                OccurredAt = DateTimeOffset.Now.ToString("o"),
            },
        };

        var physicalCountRequest = new BatchChangeInventoryRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Changes = [physicalCount],
        };
        await _client.Inventory.BatchCreateChangesAsync(physicalCountRequest);

        var physicalChangesResponse = await _client.Inventory.BatchGetChangesAsync(
            new BatchRetrieveInventoryChangesRequest
            {
                Types = [InventoryChangeType.PhysicalCount],
                CatalogObjectIds = [_itemVariationId],
                LocationIds = [_locationId],
            }
        );
        await foreach (var physicalChange in physicalChangesResponse)
        {
            var physicalCountData =
                physicalChange.PhysicalCount ?? throw new Exception("Physical count is null.");
            _physicalCountId =
                physicalCountData.Id ?? throw new Exception("Physical count ID is null.");
            break;
        }
    }

    [Test]
    public async Task TestBatchChangeInventory()
    {
        var adjustment = new InventoryAdjustment
        {
            FromState = InventoryState.None,
            ToState = InventoryState.InStock,
            LocationId = _locationId,
            CatalogObjectId = _itemVariationId,
            Quantity = "50",
            OccurredAt = DateTimeOffset.Now.ToString("o"),
        };

        var changeRequest = new BatchChangeInventoryRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Changes =
            [
                new InventoryChange
                {
                    Type = InventoryChangeType.Adjustment,
                    Adjustment = adjustment,
                },
            ],
        };
        var response = await _client.Inventory.BatchCreateChangesAsync(changeRequest);

        Assert.Multiple(() =>
        {
            Assert.That(response.Changes, Is.Not.Null);
            Assert.That(response.Changes, Is.Not.Empty);
            var firstChange =
                response.Changes?.First() ?? throw new Exception("First change is null.");
            var firstAdjustment =
                firstChange.Adjustment ?? throw new Exception("Adjustment is null.");
            Assert.That(firstAdjustment.ToState, Is.EqualTo(InventoryState.InStock));
            Assert.That(firstAdjustment.Quantity, Is.EqualTo("50"));
        });
    }

    [Test]
    public async Task TestBatchRetrieveInventoryChanges()
    {
        var retrieveRequest = new BatchRetrieveInventoryChangesRequest
        {
            CatalogObjectIds = [_itemVariationId!],
        };
        var pager = await _client.Inventory.BatchGetChangesAsync(retrieveRequest);
        Assert.That(pager.CurrentPage.Items, Is.Not.Empty);
    }

    [Test]
    public async Task TestBatchRetrieveInventoryCounts()
    {
        var retrieveRequest = new BatchGetInventoryCountsRequest
        {
            CatalogObjectIds = [_itemVariationId!],
        };
        var pager = await _client.Inventory.BatchGetCountsAsync(retrieveRequest);
        Assert.That(pager.CurrentPage.Items, Is.Not.Empty);
    }

    [Test]
    public async Task TestRetrieveInventoryChanges()
    {
        var pager = await _client.Inventory.ChangesAsync(
            new ChangesInventoryRequest { CatalogObjectId = _itemVariationId! }
        );
        Assert.That(pager.CurrentPage.Items, Is.Not.Empty);
    }

    [Test]
    public async Task TestRetrieveInventoryCount()
    {
        var pager = await _client.Inventory.GetAsync(
            new GetInventoryRequest { CatalogObjectId = _itemVariationId! }
        );
        Assert.That(pager.CurrentPage.Items, Is.Not.Empty);
    }

    [Test]
    public async Task TestRetrieveInventoryPhysicalCount()
    {
        var response = await _client.Inventory.GetPhysicalCountAsync(
            new GetPhysicalCountInventoryRequest { PhysicalCountId = _physicalCountId! }
        );
        Assert.That(response.Count, Is.Not.Null);
    }

    [Test]
    public async Task TestRetrieveInventoryAdjustment()
    {
        var adjustment = new InventoryAdjustment
        {
            FromState = InventoryState.None,
            ToState = InventoryState.InStock,
            LocationId = _locationId,
            CatalogObjectId = _itemVariationId,
            Quantity = "10",
            OccurredAt = DateTimeOffset.Now.ToString("o"),
        };

        var changeRequest = new BatchChangeInventoryRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Changes =
            [
                new InventoryChange
                {
                    Type = InventoryChangeType.Adjustment,
                    Adjustment = adjustment,
                },
            ],
        };
        var response = await _client.Inventory.BatchCreateChangesAsync(changeRequest);

        var changes = response.Changes ?? throw new Exception("Changes are null.");
        var firstChange = changes.First();
        var firstAdjustment = firstChange.Adjustment ?? throw new Exception("Adjustment is null.");
        var adjustmentId = firstAdjustment.Id ?? throw new Exception("Adjustment ID is null.");

        var retrieveResponse = await _client.Inventory.GetAdjustmentAsync(
            new GetAdjustmentInventoryRequest { AdjustmentId = adjustmentId }
        );
        var retrieveAdjustment =
            retrieveResponse.Adjustment ?? throw new Exception("Retrieve adjustment is null.");
        var retrieveAdjustmentId =
            retrieveAdjustment.Id ?? throw new Exception("Retrieve adjustment ID is null.");

        Assert.Multiple(() =>
        {
            Assert.That(retrieveResponse.Adjustment, Is.Not.Null);
            Assert.That(retrieveAdjustmentId, Is.EqualTo(adjustmentId));
        });
    }
}
