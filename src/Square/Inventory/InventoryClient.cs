using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Inventory;

public partial class InventoryClient
{
    private RawClient _client;

    internal InventoryClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns historical physical counts and adjustments based on the
    /// provided filter criteria.
    ///
    /// Results are paginated and sorted in ascending order according their
    /// `occurred_at` timestamp (oldest first).
    ///
    /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
    /// that cannot be handled by other, simpler endpoints.
    /// </summary>
    private async Task<BatchGetInventoryChangesResponse> BatchGetChangesInternalAsync(
        BatchRetrieveInventoryChangesRequest request,
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
                    Path = "v2/inventory/changes/batch-retrieve",
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
                return JsonUtils.Deserialize<BatchGetInventoryChangesResponse>(responseBody)!;
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
    /// Returns current counts for the provided
    /// [CatalogObject](entity:CatalogObject)s at the requested
    /// [Location](entity:Location)s.
    ///
    /// Results are paginated and sorted in descending order according to their
    /// `calculated_at` timestamp (newest first).
    ///
    /// When `updated_after` is specified, only counts that have changed since that
    /// time (based on the server timestamp for the most recent change) are
    /// returned. This allows clients to perform a "sync" operation, for example
    /// in response to receiving a Webhook notification.
    /// </summary>
    private async Task<BatchGetInventoryCountsResponse> BatchGetCountsInternalAsync(
        BatchGetInventoryCountsRequest request,
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
                    Path = "v2/inventory/counts/batch-retrieve",
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
                return JsonUtils.Deserialize<BatchGetInventoryCountsResponse>(responseBody)!;
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
    /// Retrieves the current calculated stock count for a given
    /// [CatalogObject](entity:CatalogObject) at a given set of
    /// [Location](entity:Location)s. Responses are paginated and unsorted.
    /// For more sophisticated queries, use a batch endpoint.
    /// </summary>
    private async Task<GetInventoryCountResponse> GetInternalAsync(
        GetInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.LocationIds != null)
        {
            _query["location_ids"] = request.LocationIds;
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/inventory/{0}",
                        ValueConvert.ToPathParameterString(request.CatalogObjectId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryCountResponse>(responseBody)!;
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
    /// Returns a set of physical counts and inventory adjustments for the
    /// provided [CatalogObject](entity:CatalogObject) at the requested
    /// [Location](entity:Location)s.
    ///
    /// You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges)
    /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
    ///
    /// Results are paginated and sorted in descending order according to their
    /// `occurred_at` timestamp (newest first).
    ///
    /// There are no limits on how far back the caller can page. This endpoint can be
    /// used to display recent changes for a specific item. For more
    /// sophisticated queries, use a batch endpoint.
    /// </summary>
    private async Task<GetInventoryChangesResponse> ChangesInternalAsync(
        ChangesInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.LocationIds != null)
        {
            _query["location_ids"] = request.LocationIds;
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/inventory/{0}/changes",
                        ValueConvert.ToPathParameterString(request.CatalogObjectId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryChangesResponse>(responseBody)!;
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
    /// Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.DeprecatedGetAdjustmentAsync(
    ///     new DeprecatedGetAdjustmentInventoryRequest { AdjustmentId = "adjustment_id" }
    /// );
    /// </code></example>
    public async Task<GetInventoryAdjustmentResponse> DeprecatedGetAdjustmentAsync(
        DeprecatedGetAdjustmentInventoryRequest request,
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
                    Path = string.Format(
                        "v2/inventory/adjustment/{0}",
                        ValueConvert.ToPathParameterString(request.AdjustmentId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryAdjustmentResponse>(responseBody)!;
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
    /// Returns the [InventoryAdjustment](entity:InventoryAdjustment) object
    /// with the provided `adjustment_id`.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.GetAdjustmentAsync(
    ///     new GetAdjustmentInventoryRequest { AdjustmentId = "adjustment_id" }
    /// );
    /// </code></example>
    public async Task<GetInventoryAdjustmentResponse> GetAdjustmentAsync(
        GetAdjustmentInventoryRequest request,
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
                    Path = string.Format(
                        "v2/inventory/adjustments/{0}",
                        ValueConvert.ToPathParameterString(request.AdjustmentId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryAdjustmentResponse>(responseBody)!;
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
    /// Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.DeprecatedBatchChangeAsync(
    ///     new BatchChangeInventoryRequest
    ///     {
    ///         IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
    ///         Changes = new List&lt;InventoryChange&gt;()
    ///         {
    ///             new InventoryChange
    ///             {
    ///                 Type = InventoryChangeType.PhysicalCount,
    ///                 PhysicalCount = new InventoryPhysicalCount
    ///                 {
    ///                     ReferenceId = "1536bfbf-efed-48bf-b17d-a197141b2a92",
    ///                     CatalogObjectId = "W62UWFY35CWMYGVWK6TWJDNI",
    ///                     State = InventoryState.InStock,
    ///                     LocationId = "C6W5YS5QM06F5",
    ///                     Quantity = "53",
    ///                     TeamMemberId = "LRK57NSQ5X7PUD05",
    ///                     OccurredAt = "2016-11-16T22:25:24.878Z",
    ///                 },
    ///             },
    ///         },
    ///         IgnoreUnchangedCounts = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchChangeInventoryResponse> DeprecatedBatchChangeAsync(
        BatchChangeInventoryRequest request,
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
                    Path = "v2/inventory/batch-change",
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
                return JsonUtils.Deserialize<BatchChangeInventoryResponse>(responseBody)!;
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
    /// Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.DeprecatedBatchGetChangesAsync(
    ///     new BatchRetrieveInventoryChangesRequest
    ///     {
    ///         CatalogObjectIds = new List&lt;string&gt;() { "W62UWFY35CWMYGVWK6TWJDNI" },
    ///         LocationIds = new List&lt;string&gt;() { "C6W5YS5QM06F5" },
    ///         Types = new List&lt;InventoryChangeType&gt;() { InventoryChangeType.PhysicalCount },
    ///         States = new List&lt;InventoryState&gt;() { InventoryState.InStock },
    ///         UpdatedAfter = "2016-11-01T00:00:00.000Z",
    ///         UpdatedBefore = "2016-12-01T00:00:00.000Z",
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchGetInventoryChangesResponse> DeprecatedBatchGetChangesAsync(
        BatchRetrieveInventoryChangesRequest request,
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
                    Path = "v2/inventory/batch-retrieve-changes",
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
                return JsonUtils.Deserialize<BatchGetInventoryChangesResponse>(responseBody)!;
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
    /// Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.DeprecatedBatchGetCountsAsync(
    ///     new BatchGetInventoryCountsRequest
    ///     {
    ///         CatalogObjectIds = new List&lt;string&gt;() { "W62UWFY35CWMYGVWK6TWJDNI" },
    ///         LocationIds = new List&lt;string&gt;() { "59TNP9SA8VGDA" },
    ///         UpdatedAfter = "2016-11-16T00:00:00.000Z",
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchGetInventoryCountsResponse> DeprecatedBatchGetCountsAsync(
        BatchGetInventoryCountsRequest request,
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
                    Path = "v2/inventory/batch-retrieve-counts",
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
                return JsonUtils.Deserialize<BatchGetInventoryCountsResponse>(responseBody)!;
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
    /// Applies adjustments and counts to the provided item quantities.
    ///
    /// On success: returns the current calculated counts for all objects
    /// referenced in the request.
    /// On failure: returns a list of related errors.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.BatchCreateChangesAsync(
    ///     new BatchChangeInventoryRequest
    ///     {
    ///         IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
    ///         Changes = new List&lt;InventoryChange&gt;()
    ///         {
    ///             new InventoryChange
    ///             {
    ///                 Type = InventoryChangeType.PhysicalCount,
    ///                 PhysicalCount = new InventoryPhysicalCount
    ///                 {
    ///                     ReferenceId = "1536bfbf-efed-48bf-b17d-a197141b2a92",
    ///                     CatalogObjectId = "W62UWFY35CWMYGVWK6TWJDNI",
    ///                     State = InventoryState.InStock,
    ///                     LocationId = "C6W5YS5QM06F5",
    ///                     Quantity = "53",
    ///                     TeamMemberId = "LRK57NSQ5X7PUD05",
    ///                     OccurredAt = "2016-11-16T22:25:24.878Z",
    ///                 },
    ///             },
    ///         },
    ///         IgnoreUnchangedCounts = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchChangeInventoryResponse> BatchCreateChangesAsync(
        BatchChangeInventoryRequest request,
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
                    Path = "v2/inventory/changes/batch-create",
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
                return JsonUtils.Deserialize<BatchChangeInventoryResponse>(responseBody)!;
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
    /// Returns historical physical counts and adjustments based on the
    /// provided filter criteria.
    ///
    /// Results are paginated and sorted in ascending order according their
    /// `occurred_at` timestamp (oldest first).
    ///
    /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
    /// that cannot be handled by other, simpler endpoints.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.BatchGetChangesAsync(
    ///     new BatchRetrieveInventoryChangesRequest
    ///     {
    ///         CatalogObjectIds = new List&lt;string&gt;() { "W62UWFY35CWMYGVWK6TWJDNI" },
    ///         LocationIds = new List&lt;string&gt;() { "C6W5YS5QM06F5" },
    ///         Types = new List&lt;InventoryChangeType&gt;() { InventoryChangeType.PhysicalCount },
    ///         States = new List&lt;InventoryState&gt;() { InventoryState.InStock },
    ///         UpdatedAfter = "2016-11-01T00:00:00.000Z",
    ///         UpdatedBefore = "2016-12-01T00:00:00.000Z",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<InventoryChange>> BatchGetChangesAsync(
        BatchRetrieveInventoryChangesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            BatchRetrieveInventoryChangesRequest,
            RequestOptions?,
            BatchGetInventoryChangesResponse,
            string?,
            InventoryChange
        >
            .CreateInstanceAsync(
                request,
                options,
                BatchGetChangesInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Changes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns current counts for the provided
    /// [CatalogObject](entity:CatalogObject)s at the requested
    /// [Location](entity:Location)s.
    ///
    /// Results are paginated and sorted in descending order according to their
    /// `calculated_at` timestamp (newest first).
    ///
    /// When `updated_after` is specified, only counts that have changed since that
    /// time (based on the server timestamp for the most recent change) are
    /// returned. This allows clients to perform a "sync" operation, for example
    /// in response to receiving a Webhook notification.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.BatchGetCountsAsync(
    ///     new BatchGetInventoryCountsRequest
    ///     {
    ///         CatalogObjectIds = new List&lt;string&gt;() { "W62UWFY35CWMYGVWK6TWJDNI" },
    ///         LocationIds = new List&lt;string&gt;() { "59TNP9SA8VGDA" },
    ///         UpdatedAfter = "2016-11-16T00:00:00.000Z",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<InventoryCount>> BatchGetCountsAsync(
        BatchGetInventoryCountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            BatchGetInventoryCountsRequest,
            RequestOptions?,
            BatchGetInventoryCountsResponse,
            string?,
            InventoryCount
        >
            .CreateInstanceAsync(
                request,
                options,
                BatchGetCountsInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Counts?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.DeprecatedGetPhysicalCountAsync(
    ///     new DeprecatedGetPhysicalCountInventoryRequest { PhysicalCountId = "physical_count_id" }
    /// );
    /// </code></example>
    public async Task<GetInventoryPhysicalCountResponse> DeprecatedGetPhysicalCountAsync(
        DeprecatedGetPhysicalCountInventoryRequest request,
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
                    Path = string.Format(
                        "v2/inventory/physical-count/{0}",
                        ValueConvert.ToPathParameterString(request.PhysicalCountId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryPhysicalCountResponse>(responseBody)!;
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
    /// Returns the [InventoryPhysicalCount](entity:InventoryPhysicalCount)
    /// object with the provided `physical_count_id`.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.GetPhysicalCountAsync(
    ///     new GetPhysicalCountInventoryRequest { PhysicalCountId = "physical_count_id" }
    /// );
    /// </code></example>
    public async Task<GetInventoryPhysicalCountResponse> GetPhysicalCountAsync(
        GetPhysicalCountInventoryRequest request,
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
                    Path = string.Format(
                        "v2/inventory/physical-counts/{0}",
                        ValueConvert.ToPathParameterString(request.PhysicalCountId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryPhysicalCountResponse>(responseBody)!;
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
    /// Returns the [InventoryTransfer](entity:InventoryTransfer) object
    /// with the provided `transfer_id`.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.GetTransferAsync(
    ///     new GetTransferInventoryRequest { TransferId = "transfer_id" }
    /// );
    /// </code></example>
    public async Task<GetInventoryTransferResponse> GetTransferAsync(
        GetTransferInventoryRequest request,
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
                    Path = string.Format(
                        "v2/inventory/transfers/{0}",
                        ValueConvert.ToPathParameterString(request.TransferId)
                    ),
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
                return JsonUtils.Deserialize<GetInventoryTransferResponse>(responseBody)!;
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
    /// Retrieves the current calculated stock count for a given
    /// [CatalogObject](entity:CatalogObject) at a given set of
    /// [Location](entity:Location)s. Responses are paginated and unsorted.
    /// For more sophisticated queries, use a batch endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.GetAsync(
    ///     new GetInventoryRequest
    ///     {
    ///         CatalogObjectId = "catalog_object_id",
    ///         LocationIds = "location_ids",
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<InventoryCount>> GetAsync(
        GetInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            GetInventoryRequest,
            RequestOptions?,
            GetInventoryCountResponse,
            string?,
            InventoryCount
        >
            .CreateInstanceAsync(
                request,
                options,
                GetInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Counts?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns a set of physical counts and inventory adjustments for the
    /// provided [CatalogObject](entity:CatalogObject) at the requested
    /// [Location](entity:Location)s.
    ///
    /// You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges)
    /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
    ///
    /// Results are paginated and sorted in descending order according to their
    /// `occurred_at` timestamp (newest first).
    ///
    /// There are no limits on how far back the caller can page. This endpoint can be
    /// used to display recent changes for a specific item. For more
    /// sophisticated queries, use a batch endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Inventory.ChangesAsync(
    ///     new ChangesInventoryRequest
    ///     {
    ///         CatalogObjectId = "catalog_object_id",
    ///         LocationIds = "location_ids",
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<InventoryChange>> ChangesAsync(
        ChangesInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ChangesInventoryRequest,
            RequestOptions?,
            GetInventoryChangesResponse,
            string?,
            InventoryChange
        >
            .CreateInstanceAsync(
                request,
                options,
                ChangesInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Changes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
