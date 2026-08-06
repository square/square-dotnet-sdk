using System.Text.Json;
using Square;
using Square.Core;

namespace Square.TransferOrders;

public partial class TransferOrdersClient : ITransferOrdersClient
{
    private RawClient _client;

    internal TransferOrdersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Searches for transfer orders using filters. Returns a paginated list of matching
    /// [TransferOrder](entity:TransferOrder)s sorted by creation date.
    ///
    /// Common search scenarios:
    /// - Find orders for a source [Location](entity:Location)
    /// - Find orders for a destination [Location](entity:Location)
    /// - Find orders in a particular [TransferOrderStatus](entity:TransferOrderStatus)
    /// </summary>
    private async Task<SearchTransferOrdersResponse> SearchInternalAsync(
        SearchTransferOrdersRequest request,
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
                    Path = "v2/transfer-orders/search",
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
                return JsonUtils.Deserialize<SearchTransferOrdersResponse>(responseBody)!;
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
    /// Creates a new transfer order in [DRAFT](entity:TransferOrderStatus) status. A transfer order represents the intent
    /// to move [CatalogItemVariation](entity:CatalogItemVariation)s from one [Location](entity:Location) to another.
    /// The source and destination locations must be different and must belong to your Square account.
    ///
    /// In [DRAFT](entity:TransferOrderStatus) status, you can:
    /// - Add or remove items
    /// - Modify quantities
    /// - Update shipping information
    /// - Delete the entire order via [DeleteTransferOrder](api-endpoint:TransferOrders-DeleteTransferOrder)
    ///
    /// The request requires source_location_id and destination_location_id.
    /// Inventory levels are not affected until the order is started via
    /// [StartTransferOrder](api-endpoint:TransferOrders-StartTransferOrder).
    ///
    /// Common integration points:
    /// - Sync with warehouse management systems
    /// - Automate regular stock transfers
    /// - Initialize transfers from inventory optimization systems
    ///
    /// Creates a [transfer_order.created](webhook:transfer_order.created) webhook event.
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.CreateAsync(
    ///     new CreateTransferOrderRequest
    ///     {
    ///         IdempotencyKey = "65cc0586-3e82-384s-b524-3885cffd52",
    ///         TransferOrder = new CreateTransferOrderData
    ///         {
    ///             SourceLocationId = "EXAMPLE_SOURCE_LOCATION_ID_123",
    ///             DestinationLocationId = "EXAMPLE_DEST_LOCATION_ID_456",
    ///             ExpectedAt = "2025-11-09T05:00:00Z",
    ///             Notes = "Example transfer order for inventory redistribution between locations",
    ///             TrackingNumber = "TRACK123456789",
    ///             CreatedByTeamMemberId = "EXAMPLE_TEAM_MEMBER_ID_789",
    ///             LineItems = new List&lt;CreateTransferOrderLineData&gt;()
    ///             {
    ///                 new CreateTransferOrderLineData
    ///                 {
    ///                     ItemVariationId = "EXAMPLE_ITEM_VARIATION_ID_001",
    ///                     QuantityOrdered = "5",
    ///                 },
    ///                 new CreateTransferOrderLineData
    ///                 {
    ///                     ItemVariationId = "EXAMPLE_ITEM_VARIATION_ID_002",
    ///                     QuantityOrdered = "3",
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateTransferOrderResponse> CreateAsync(
        CreateTransferOrderRequest request,
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
                    Path = "v2/transfer-orders",
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
                return JsonUtils.Deserialize<CreateTransferOrderResponse>(responseBody)!;
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
    /// Searches for transfer orders using filters. Returns a paginated list of matching
    /// [TransferOrder](entity:TransferOrder)s sorted by creation date.
    ///
    /// Common search scenarios:
    /// - Find orders for a source [Location](entity:Location)
    /// - Find orders for a destination [Location](entity:Location)
    /// - Find orders in a particular [TransferOrderStatus](entity:TransferOrderStatus)
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.SearchAsync(
    ///     new SearchTransferOrdersRequest
    ///     {
    ///         Query = new TransferOrderQuery
    ///         {
    ///             Filter = new TransferOrderFilter
    ///             {
    ///                 SourceLocationIds = new List&lt;string&gt;() { "EXAMPLE_SOURCE_LOCATION_ID_123" },
    ///                 DestinationLocationIds = new List&lt;string&gt;() { "EXAMPLE_DEST_LOCATION_ID_456" },
    ///                 Statuses = new List&lt;TransferOrderStatus&gt;()
    ///                 {
    ///                     TransferOrderStatus.Started,
    ///                     TransferOrderStatus.PartiallyReceived,
    ///                 },
    ///             },
    ///             Sort = new TransferOrderSort
    ///             {
    ///                 Field = TransferOrderSortField.UpdatedAt,
    ///                 Order = SortOrder.Desc,
    ///             },
    ///         },
    ///         Cursor = "eyJsYXN0X3VwZGF0ZWRfYXQiOjE3NTMxMTg2NjQ4NzN9",
    ///         Limit = 10,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<TransferOrder>> SearchAsync(
        SearchTransferOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            SearchTransferOrdersRequest,
            RequestOptions?,
            SearchTransferOrdersResponse,
            string?,
            TransferOrder
        >
            .CreateInstanceAsync(
                request,
                options,
                SearchInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.TransferOrders?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a specific [TransferOrder](entity:TransferOrder) by ID. Returns the complete
    /// order details including:
    ///
    /// - Basic information (status, dates, notes)
    /// - Line items with ordered and received quantities
    /// - Source and destination [Location](entity:Location)s
    /// - Tracking information (if available)
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.GetAsync(
    ///     new GetTransferOrdersRequest { TransferOrderId = "transfer_order_id" }
    /// );
    /// </code></example>
    public async Task<RetrieveTransferOrderResponse> GetAsync(
        GetTransferOrdersRequest request,
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
                        "v2/transfer-orders/{0}",
                        ValueConvert.ToPathParameterString(request.TransferOrderId)
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
                return JsonUtils.Deserialize<RetrieveTransferOrderResponse>(responseBody)!;
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
    /// Updates an existing transfer order. This endpoint supports sparse updates,
    /// allowing you to modify specific fields without affecting others.
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.UpdateAsync(
    ///     new UpdateTransferOrderRequest
    ///     {
    ///         TransferOrderId = "transfer_order_id",
    ///         IdempotencyKey = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///         TransferOrder = new UpdateTransferOrderData
    ///         {
    ///             SourceLocationId = "EXAMPLE_SOURCE_LOCATION_ID_789",
    ///             DestinationLocationId = "EXAMPLE_DEST_LOCATION_ID_101",
    ///             ExpectedAt = "2025-11-10T08:00:00Z",
    ///             Notes = "Updated: Priority transfer due to low stock at destination",
    ///             TrackingNumber = "TRACK987654321",
    ///             LineItems = new List&lt;UpdateTransferOrderLineData&gt;()
    ///             {
    ///                 new UpdateTransferOrderLineData { Uid = "1", QuantityOrdered = "7" },
    ///                 new UpdateTransferOrderLineData
    ///                 {
    ///                     ItemVariationId = "EXAMPLE_NEW_ITEM_VARIATION_ID_003",
    ///                     QuantityOrdered = "2",
    ///                 },
    ///                 new UpdateTransferOrderLineData { Uid = "2", Remove = true },
    ///             },
    ///         },
    ///         Version = 1753109537351,
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateTransferOrderResponse> UpdateAsync(
        UpdateTransferOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/transfer-orders/{0}",
                        ValueConvert.ToPathParameterString(request.TransferOrderId)
                    ),
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
                return JsonUtils.Deserialize<UpdateTransferOrderResponse>(responseBody)!;
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
    /// Deletes a transfer order in [DRAFT](entity:TransferOrderStatus) status.
    /// Only draft orders can be deleted. Once an order is started via
    /// [StartTransferOrder](api-endpoint:TransferOrders-StartTransferOrder), it can no longer be deleted.
    ///
    /// Creates a [transfer_order.deleted](webhook:transfer_order.deleted) webhook event.
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.DeleteAsync(
    ///     new DeleteTransferOrdersRequest { TransferOrderId = "transfer_order_id", Version = 1000000 }
    /// );
    /// </code></example>
    public async Task<DeleteTransferOrderResponse> DeleteAsync(
        DeleteTransferOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Version != null)
        {
            _query["version"] = request.Version.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/transfer-orders/{0}",
                        ValueConvert.ToPathParameterString(request.TransferOrderId)
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
                return JsonUtils.Deserialize<DeleteTransferOrderResponse>(responseBody)!;
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
    /// Cancels a transfer order in [STARTED](entity:TransferOrderStatus) or
    /// [PARTIALLY_RECEIVED](entity:TransferOrderStatus) status. Any unreceived quantities will no
    /// longer be receivable and will be immediately returned to the source [Location](entity:Location)'s inventory.
    ///
    /// Common reasons for cancellation:
    /// - Items no longer needed at destination
    /// - Source location needs the inventory
    /// - Order created in error
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.CancelAsync(
    ///     new CancelTransferOrderRequest
    ///     {
    ///         TransferOrderId = "transfer_order_id",
    ///         IdempotencyKey = "65cc0586-3e82-4d08-b524-3885cffd52",
    ///         Version = 1753117449752,
    ///     }
    /// );
    /// </code></example>
    public async Task<CancelTransferOrderResponse> CancelAsync(
        CancelTransferOrderRequest request,
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
                    Path = string.Format(
                        "v2/transfer-orders/{0}/cancel",
                        ValueConvert.ToPathParameterString(request.TransferOrderId)
                    ),
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
                return JsonUtils.Deserialize<CancelTransferOrderResponse>(responseBody)!;
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
    /// Records receipt of [CatalogItemVariation](entity:CatalogItemVariation)s for a transfer order.
    /// This endpoint supports partial receiving - you can receive items in multiple batches.
    ///
    /// For each line item, you can specify:
    /// - Quantity received in good condition (added to destination inventory with [InventoryState](entity:InventoryState) of IN_STOCK)
    /// - Quantity damaged during transit/handling (added to destination inventory with [InventoryState](entity:InventoryState) of WASTE)
    /// - Quantity canceled (returned to source location's inventory)
    ///
    /// The order must be in [STARTED](entity:TransferOrderStatus) or [PARTIALLY_RECEIVED](entity:TransferOrderStatus) status.
    /// Received quantities are added to the destination [Location](entity:Location)'s inventory according to their condition.
    /// Canceled quantities are immediately returned to the source [Location](entity:Location)'s inventory.
    ///
    /// When all items are either received, damaged, or canceled, the order moves to
    /// [COMPLETED](entity:TransferOrderStatus) status.
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.ReceiveAsync(
    ///     new ReceiveTransferOrderRequest
    ///     {
    ///         TransferOrderId = "transfer_order_id",
    ///         IdempotencyKey = "EXAMPLE_IDEMPOTENCY_KEY_101",
    ///         Receipt = new TransferOrderGoodsReceipt
    ///         {
    ///             LineItems = new List&lt;TransferOrderGoodsReceiptLineItem&gt;()
    ///             {
    ///                 new TransferOrderGoodsReceiptLineItem
    ///                 {
    ///                     TransferOrderLineUid = "1",
    ///                     QuantityReceived = "3",
    ///                     QuantityDamaged = "1",
    ///                     QuantityCanceled = "1",
    ///                 },
    ///                 new TransferOrderGoodsReceiptLineItem
    ///                 {
    ///                     TransferOrderLineUid = "2",
    ///                     QuantityReceived = "2",
    ///                     QuantityCanceled = "1",
    ///                 },
    ///             },
    ///         },
    ///         Version = 1753118664873,
    ///     }
    /// );
    /// </code></example>
    public async Task<ReceiveTransferOrderResponse> ReceiveAsync(
        ReceiveTransferOrderRequest request,
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
                    Path = string.Format(
                        "v2/transfer-orders/{0}/receive",
                        ValueConvert.ToPathParameterString(request.TransferOrderId)
                    ),
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
                return JsonUtils.Deserialize<ReceiveTransferOrderResponse>(responseBody)!;
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
    /// Changes a [DRAFT](entity:TransferOrderStatus) transfer order to [STARTED](entity:TransferOrderStatus) status.
    /// This decrements inventory at the source [Location](entity:Location) and marks it as in-transit.
    ///
    /// The order must be in [DRAFT](entity:TransferOrderStatus) status and have all required fields populated.
    /// Once started, the order can no longer be deleted, but it can be canceled via
    /// [CancelTransferOrder](api-endpoint:TransferOrders-CancelTransferOrder).
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    /// <example><code>
    /// await client.TransferOrders.StartAsync(
    ///     new StartTransferOrderRequest
    ///     {
    ///         TransferOrderId = "transfer_order_id",
    ///         IdempotencyKey = "EXAMPLE_IDEMPOTENCY_KEY_789",
    ///         Version = 1753109537351,
    ///     }
    /// );
    /// </code></example>
    public async Task<StartTransferOrderResponse> StartAsync(
        StartTransferOrderRequest request,
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
                    Path = string.Format(
                        "v2/transfer-orders/{0}/start",
                        ValueConvert.ToPathParameterString(request.TransferOrderId)
                    ),
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
                return JsonUtils.Deserialize<StartTransferOrderResponse>(responseBody)!;
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
