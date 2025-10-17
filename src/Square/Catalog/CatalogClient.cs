using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Catalog.Images;
using Square.Catalog.Object;
using Square.Core;

namespace Square.Catalog;

public partial class CatalogClient
{
    private RawClient _client;

    internal CatalogClient(RawClient client)
    {
        _client = client;
        Images = new ImagesClient(_client);
        Object = new ObjectClient(_client);
    }

    public ImagesClient Images { get; }

    public ObjectClient Object { get; }

    /// <summary>
    /// Returns a list of all [CatalogObject](entity:CatalogObject)s of the specified types in the catalog.
    ///
    /// The `types` parameter is specified as a comma-separated list of the [CatalogObjectType](entity:CatalogObjectType) values,
    /// for example, "`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`".
    ///
    /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve
    /// deleted catalog items, use [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects)
    /// and set the `include_deleted_objects` attribute value to `true`.
    /// </summary>
    private async Task<ListCatalogResponse> ListInternalAsync(
        ListCatalogRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Types != null)
        {
            _query["types"] = request.Types;
        }
        if (request.CatalogVersion != null)
        {
            _query["catalog_version"] = request.CatalogVersion.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/catalog/list",
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ListCatalogResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Deletes a set of [CatalogItem](entity:CatalogItem)s based on the
    /// provided list of target IDs and returns a set of successfully deleted IDs in
    /// the response. Deletion is a cascading event such that all children of the
    /// targeted object are also deleted. For example, deleting a CatalogItem will
    /// also delete all of its [CatalogItemVariation](entity:CatalogItemVariation)
    /// children.
    ///
    /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted
    /// IDs can be deleted. The response will only include IDs that were
    /// actually deleted.
    ///
    /// To ensure consistency, only one delete request is processed at a time per seller account.
    /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched)
    /// delete requests are rejected with the `429` error code.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.BatchDeleteAsync(
    ///     new BatchDeleteCatalogObjectsRequest
    ///     {
    ///         ObjectIds = new List&lt;string&gt;() { "W62UWFY35CWMYGVWK6TWJDNI", "AA27W3M2GGTF3H6AVPNB77CK" },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchDeleteCatalogObjectsResponse> BatchDeleteAsync(
        BatchDeleteCatalogObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/batch-delete",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<BatchDeleteCatalogObjectsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Returns a set of objects based on the provided ID.
    /// Each [CatalogItem](entity:CatalogItem) returned in the set includes all of its
    /// child information including: all of its
    /// [CatalogItemVariation](entity:CatalogItemVariation) objects, references to
    /// its [CatalogModifierList](entity:CatalogModifierList) objects, and the ids of
    /// any [CatalogTax](entity:CatalogTax) objects that apply to it.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.BatchGetAsync(
    ///     new BatchGetCatalogObjectsRequest
    ///     {
    ///         ObjectIds = new List&lt;string&gt;() { "W62UWFY35CWMYGVWK6TWJDNI", "AA27W3M2GGTF3H6AVPNB77CK" },
    ///         IncludeRelatedObjects = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchGetCatalogObjectsResponse> BatchGetAsync(
        BatchGetCatalogObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/batch-retrieve",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<BatchGetCatalogObjectsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Creates or updates up to 10,000 target objects based on the provided
    /// list of objects. The target objects are grouped into batches and each batch is
    /// inserted/updated in an all-or-nothing manner. If an object within a batch is
    /// malformed in some way, or violates a database constraint, the entire batch
    /// containing that item will be disregarded. However, other batches in the same
    /// request may still succeed. Each batch may contain up to 1,000 objects, and
    /// batches will be processed in order as long as the total object count for the
    /// request (items, variations, modifier lists, discounts, and taxes) is no more
    /// than 10,000.
    ///
    /// To ensure consistency, only one update request is processed at a time per seller account.
    /// While one (batch or non-batch) update request is being processed, other (batched and non-batched)
    /// update requests are rejected with the `429` error code.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.BatchUpsertAsync(
    ///     new BatchUpsertCatalogObjectsRequest
    ///     {
    ///         IdempotencyKey = "789ff020-f723-43a9-b4b5-43b5dc1fa3dc",
    ///         Batches = new List&lt;CatalogObjectBatch&gt;()
    ///         {
    ///             new CatalogObjectBatch
    ///             {
    ///                 Objects = new List&lt;CatalogObject&gt;()
    ///                 {
    ///                     new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
    ///                     new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
    ///                     new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
    ///                     new CatalogObject(new CatalogObject.Tax(new CatalogObjectTax { Id = "id" })),
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchUpsertCatalogObjectsResponse> BatchUpsertAsync(
        BatchUpsertCatalogObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/batch-upsert",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<BatchUpsertCatalogObjectsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves information about the Square Catalog API, such as batch size
    /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.InfoAsync();
    /// </code></example>
    public async Task<CatalogInfoResponse> InfoAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/catalog/info",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CatalogInfoResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Returns a list of all [CatalogObject](entity:CatalogObject)s of the specified types in the catalog.
    ///
    /// The `types` parameter is specified as a comma-separated list of the [CatalogObjectType](entity:CatalogObjectType) values,
    /// for example, "`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`".
    ///
    /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve
    /// deleted catalog items, use [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects)
    /// and set the `include_deleted_objects` attribute value to `true`.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.ListAsync(
    ///     new ListCatalogRequest
    ///     {
    ///         Cursor = "cursor",
    ///         Types = "types",
    ///         CatalogVersion = 1000000,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<CatalogObject>> ListAsync(
        ListCatalogRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCatalogRequest,
            RequestOptions?,
            ListCatalogResponse,
            string?,
            CatalogObject
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Objects?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Searches for [CatalogObject](entity:CatalogObject) of any type by matching supported search attribute values,
    /// excluding custom attribute values on items or item variations, against one or more of the specified query filters.
    ///
    /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems)
    /// endpoint in the following aspects:
    ///
    /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
    /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
    /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
    /// - The both endpoints have different call conventions, including the query filter formats.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.SearchAsync(
    ///     new SearchCatalogObjectsRequest
    ///     {
    ///         ObjectTypes = new List&lt;CatalogObjectType&gt;() { CatalogObjectType.Item },
    ///         Query = new CatalogQuery
    ///         {
    ///             PrefixQuery = new CatalogQueryPrefix
    ///             {
    ///                 AttributeName = "name",
    ///                 AttributePrefix = "tea",
    ///             },
    ///         },
    ///         Limit = 100,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchCatalogObjectsResponse> SearchAsync(
        SearchCatalogObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/search",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<SearchCatalogObjectsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Searches for catalog items or item variations by matching supported search attribute values, including
    /// custom attribute values, against one or more of the specified query filters.
    ///
    /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects)
    /// endpoint in the following aspects:
    ///
    /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
    /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
    /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
    /// - The both endpoints use different call conventions, including the query filter formats.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.SearchItemsAsync(
    ///     new SearchCatalogItemsRequest
    ///     {
    ///         TextFilter = "red",
    ///         CategoryIds = new List&lt;string&gt;() { "WINE_CATEGORY_ID" },
    ///         StockLevels = new List&lt;SearchCatalogItemsRequestStockLevel&gt;()
    ///         {
    ///             SearchCatalogItemsRequestStockLevel.Out,
    ///             SearchCatalogItemsRequestStockLevel.Low,
    ///         },
    ///         EnabledLocationIds = new List&lt;string&gt;() { "ATL_LOCATION_ID" },
    ///         Limit = 100,
    ///         SortOrder = SortOrder.Asc,
    ///         ProductTypes = new List&lt;CatalogItemProductType&gt;() { CatalogItemProductType.Regular },
    ///         CustomAttributeFilters = new List&lt;CustomAttributeFilter&gt;()
    ///         {
    ///             new CustomAttributeFilter
    ///             {
    ///                 CustomAttributeDefinitionId = "VEGAN_DEFINITION_ID",
    ///                 BoolFilter = true,
    ///             },
    ///             new CustomAttributeFilter
    ///             {
    ///                 CustomAttributeDefinitionId = "BRAND_DEFINITION_ID",
    ///                 StringFilter = "Dark Horse",
    ///             },
    ///             new CustomAttributeFilter
    ///             {
    ///                 Key = "VINTAGE",
    ///                 NumberFilter = new Square.Range { Min = "min", Max = "max" },
    ///             },
    ///             new CustomAttributeFilter { CustomAttributeDefinitionId = "VARIETAL_DEFINITION_ID" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchCatalogItemsResponse> SearchItemsAsync(
        SearchCatalogItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/search-catalog-items",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<SearchCatalogItemsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Updates the [CatalogModifierList](entity:CatalogModifierList) objects
    /// that apply to the targeted [CatalogItem](entity:CatalogItem) without having
    /// to perform an upsert on the entire item.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.UpdateItemModifierListsAsync(
    ///     new UpdateItemModifierListsRequest
    ///     {
    ///         ItemIds = new List&lt;string&gt;() { "H42BRLUJ5KTZTTMPVSLFAACQ", "2JXOBJIHCWBQ4NZ3RIXQGJA6" },
    ///         ModifierListsToEnable = new List&lt;string&gt;()
    ///         {
    ///             "H42BRLUJ5KTZTTMPVSLFAACQ",
    ///             "2JXOBJIHCWBQ4NZ3RIXQGJA6",
    ///         },
    ///         ModifierListsToDisable = new List&lt;string&gt;() { "7WRC16CJZDVLSNDQ35PP6YAD" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(
        UpdateItemModifierListsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/update-item-modifier-lists",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpdateItemModifierListsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Updates the [CatalogTax](entity:CatalogTax) objects that apply to the
    /// targeted [CatalogItem](entity:CatalogItem) without having to perform an
    /// upsert on the entire item.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.UpdateItemTaxesAsync(
    ///     new UpdateItemTaxesRequest
    ///     {
    ///         ItemIds = new List&lt;string&gt;() { "H42BRLUJ5KTZTTMPVSLFAACQ", "2JXOBJIHCWBQ4NZ3RIXQGJA6" },
    ///         TaxesToEnable = new List&lt;string&gt;() { "4WRCNHCJZDVLSNDQ35PP6YAD" },
    ///         TaxesToDisable = new List&lt;string&gt;() { "AQCEGCEBBQONINDOHRGZISEX" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateItemTaxesResponse> UpdateItemTaxesAsync(
        UpdateItemTaxesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/update-item-taxes",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpdateItemTaxesResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
