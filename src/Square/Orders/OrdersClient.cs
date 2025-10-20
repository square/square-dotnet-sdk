using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Orders;

public partial class OrdersClient
{
    private RawClient _client;

    internal OrdersClient(RawClient client)
    {
        _client = client;
        CustomAttributeDefinitions =
            new Square.Orders.CustomAttributeDefinitions.CustomAttributeDefinitionsClient(_client);
        CustomAttributes = new Square.Orders.CustomAttributes.CustomAttributesClient(_client);
    }

    public Square.Orders.CustomAttributeDefinitions.CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }

    public Square.Orders.CustomAttributes.CustomAttributesClient CustomAttributes { get; }

    /// <summary>
    /// Creates a new [order](entity:Order) that can include information about products for
    /// purchase and settings to apply to the purchase.
    ///
    /// To pay for a created order, see
    /// [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
    ///
    /// You can modify open orders using the [UpdateOrder](api-endpoint:Orders-UpdateOrder) endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CreateAsync(
    ///     new CreateOrderRequest
    ///     {
    ///         Order = new Order
    ///         {
    ///             LocationId = "057P5VYJ4A5X1",
    ///             ReferenceId = "my-order-001",
    ///             LineItems = new List&lt;OrderLineItem&gt;()
    ///             {
    ///                 new OrderLineItem
    ///                 {
    ///                     Name = "New York Strip Steak",
    ///                     Quantity = "1",
    ///                     BasePriceMoney = new Money { Amount = 1599, Currency = Currency.Usd },
    ///                 },
    ///                 new OrderLineItem
    ///                 {
    ///                     Quantity = "2",
    ///                     CatalogObjectId = "BEMYCSMIJL46OCDV4KYIKXIB",
    ///                     Modifiers = new List&lt;OrderLineItemModifier&gt;()
    ///                     {
    ///                         new OrderLineItemModifier { CatalogObjectId = "CHQX7Y4KY6N5KINJKZCFURPZ" },
    ///                     },
    ///                     AppliedDiscounts = new List&lt;OrderLineItemAppliedDiscount&gt;()
    ///                     {
    ///                         new OrderLineItemAppliedDiscount { DiscountUid = "one-dollar-off" },
    ///                     },
    ///                 },
    ///             },
    ///             Taxes = new List&lt;OrderLineItemTax&gt;()
    ///             {
    ///                 new OrderLineItemTax
    ///                 {
    ///                     Uid = "state-sales-tax",
    ///                     Name = "State Sales Tax",
    ///                     Percentage = "9",
    ///                     Scope = OrderLineItemTaxScope.Order,
    ///                 },
    ///             },
    ///             Discounts = new List&lt;OrderLineItemDiscount&gt;()
    ///             {
    ///                 new OrderLineItemDiscount
    ///                 {
    ///                     Uid = "labor-day-sale",
    ///                     Name = "Labor Day Sale",
    ///                     Percentage = "5",
    ///                     Scope = OrderLineItemDiscountScope.Order,
    ///                 },
    ///                 new OrderLineItemDiscount
    ///                 {
    ///                     Uid = "membership-discount",
    ///                     CatalogObjectId = "DB7L55ZH2BGWI4H23ULIWOQ7",
    ///                     Scope = OrderLineItemDiscountScope.Order,
    ///                 },
    ///                 new OrderLineItemDiscount
    ///                 {
    ///                     Uid = "one-dollar-off",
    ///                     Name = "Sale - $1.00 off",
    ///                     AmountMoney = new Money { Amount = 100, Currency = Currency.Usd },
    ///                     Scope = OrderLineItemDiscountScope.LineItem,
    ///                 },
    ///             },
    ///         },
    ///         IdempotencyKey = "8193148c-9586-11e6-99f9-28cfe92138cf",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateOrderResponse> CreateAsync(
        CreateOrderRequest request,
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
                    Path = "v2/orders",
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
                return JsonUtils.Deserialize<CreateOrderResponse>(responseBody)!;
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
    /// Retrieves a set of [orders](entity:Order) by their IDs.
    ///
    /// If a given order ID does not exist, the ID is ignored instead of generating an error.
    /// </summary>
    /// <example><code>
    /// await client.Orders.BatchGetAsync(
    ///     new BatchGetOrdersRequest
    ///     {
    ///         LocationId = "057P5VYJ4A5X1",
    ///         OrderIds = new List&lt;string&gt;()
    ///         {
    ///             "CAISEM82RcpmcFBM0TfOyiHV3es",
    ///             "CAISENgvlJ6jLWAzERDzjyHVybY",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchGetOrdersResponse> BatchGetAsync(
        BatchGetOrdersRequest request,
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
                    Path = "v2/orders/batch-retrieve",
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
                return JsonUtils.Deserialize<BatchGetOrdersResponse>(responseBody)!;
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
    /// Enables applications to preview order pricing without creating an order.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CalculateAsync(
    ///     new CalculateOrderRequest
    ///     {
    ///         Order = new Order
    ///         {
    ///             LocationId = "D7AVYMEAPJ3A3",
    ///             LineItems = new List&lt;OrderLineItem&gt;()
    ///             {
    ///                 new OrderLineItem
    ///                 {
    ///                     Name = "Item 1",
    ///                     Quantity = "1",
    ///                     BasePriceMoney = new Money { Amount = 500, Currency = Currency.Usd },
    ///                 },
    ///                 new OrderLineItem
    ///                 {
    ///                     Name = "Item 2",
    ///                     Quantity = "2",
    ///                     BasePriceMoney = new Money { Amount = 300, Currency = Currency.Usd },
    ///                 },
    ///             },
    ///             Discounts = new List&lt;OrderLineItemDiscount&gt;()
    ///             {
    ///                 new OrderLineItemDiscount
    ///                 {
    ///                     Name = "50% Off",
    ///                     Percentage = "50",
    ///                     Scope = OrderLineItemDiscountScope.Order,
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CalculateOrderResponse> CalculateAsync(
        CalculateOrderRequest request,
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
                    Path = "v2/orders/calculate",
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
                return JsonUtils.Deserialize<CalculateOrderResponse>(responseBody)!;
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
    /// Creates a new order, in the `DRAFT` state, by duplicating an existing order. The newly created order has
    /// only the core fields (such as line items, taxes, and discounts) copied from the original order.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CloneAsync(
    ///     new CloneOrderRequest
    ///     {
    ///         OrderId = "ZAISEM52YcpmcWAzERDOyiWS123",
    ///         Version = 3,
    ///         IdempotencyKey = "UNIQUE_STRING",
    ///     }
    /// );
    /// </code></example>
    public async Task<CloneOrderResponse> CloneAsync(
        CloneOrderRequest request,
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
                    Path = "v2/orders/clone",
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
                return JsonUtils.Deserialize<CloneOrderResponse>(responseBody)!;
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
    /// Search all orders for one or more locations. Orders include all sales,
    /// returns, and exchanges regardless of how or when they entered the Square
    /// ecosystem (such as Point of Sale, Invoices, and Connect APIs).
    ///
    /// `SearchOrders` requests need to specify which locations to search and define a
    /// [SearchOrdersQuery](entity:SearchOrdersQuery) object that controls
    /// how to sort or filter the results. Your `SearchOrdersQuery` can:
    ///
    ///   Set filter criteria.
    ///   Set the sort order.
    ///   Determine whether to return results as complete `Order` objects or as
    /// [OrderEntry](entity:OrderEntry) objects.
    ///
    /// Note that details for orders processed with Square Point of Sale while in
    /// offline mode might not be transmitted to Square for up to 72 hours. Offline
    /// orders have a `created_at` value that reflects the time the order was created,
    /// not the time it was subsequently transmitted to Square.
    /// </summary>
    /// <example><code>
    /// await client.Orders.SearchAsync(
    ///     new SearchOrdersRequest
    ///     {
    ///         LocationIds = new List&lt;string&gt;() { "057P5VYJ4A5X1", "18YC4JDH91E1H" },
    ///         Query = new SearchOrdersQuery
    ///         {
    ///             Filter = new SearchOrdersFilter
    ///             {
    ///                 StateFilter = new SearchOrdersStateFilter
    ///                 {
    ///                     States = new List&lt;OrderState&gt;() { OrderState.Completed },
    ///                 },
    ///                 DateTimeFilter = new SearchOrdersDateTimeFilter
    ///                 {
    ///                     ClosedAt = new TimeRange
    ///                     {
    ///                         StartAt = "2018-03-03T20:00:00+00:00",
    ///                         EndAt = "2019-03-04T21:54:45+00:00",
    ///                     },
    ///                 },
    ///             },
    ///             Sort = new SearchOrdersSort
    ///             {
    ///                 SortField = SearchOrdersSortField.ClosedAt,
    ///                 SortOrder = SortOrder.Desc,
    ///             },
    ///         },
    ///         Limit = 3,
    ///         ReturnEntries = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchOrdersResponse> SearchAsync(
        SearchOrdersRequest request,
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
                    Path = "v2/orders/search",
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
                return JsonUtils.Deserialize<SearchOrdersResponse>(responseBody)!;
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
    /// Retrieves an [Order](entity:Order) by ID.
    /// </summary>
    /// <example><code>
    /// await client.Orders.GetAsync(new GetOrdersRequest { OrderId = "order_id" });
    /// </code></example>
    public async Task<GetOrderResponse> GetAsync(
        GetOrdersRequest request,
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
                        "v2/orders/{0}",
                        ValueConvert.ToPathParameterString(request.OrderId)
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
                return JsonUtils.Deserialize<GetOrderResponse>(responseBody)!;
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
    /// Updates an open [order](entity:Order) by adding, replacing, or deleting
    /// fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.
    ///
    /// An `UpdateOrder` request requires the following:
    ///
    /// - The `order_id` in the endpoint path, identifying the order to update.
    /// - The latest `version` of the order to update.
    /// - The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects)
    /// containing only the fields to update and the version to which the update is
    /// being applied.
    /// - If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete)
    /// identifying the fields to clear.
    ///
    /// To pay for an order, see
    /// [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
    /// </summary>
    /// <example><code>
    /// await client.Orders.UpdateAsync(
    ///     new UpdateOrderRequest
    ///     {
    ///         OrderId = "order_id",
    ///         Order = new Order
    ///         {
    ///             LocationId = "location_id",
    ///             LineItems = new List&lt;OrderLineItem&gt;()
    ///             {
    ///                 new OrderLineItem
    ///                 {
    ///                     Uid = "cookie_uid",
    ///                     Name = "COOKIE",
    ///                     Quantity = "2",
    ///                     BasePriceMoney = new Money { Amount = 200, Currency = Currency.Usd },
    ///                 },
    ///             },
    ///             Version = 1,
    ///         },
    ///         FieldsToClear = new List&lt;string&gt;() { "discounts" },
    ///         IdempotencyKey = "UNIQUE_STRING",
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateOrderResponse> UpdateAsync(
        UpdateOrderRequest request,
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
                        "v2/orders/{0}",
                        ValueConvert.ToPathParameterString(request.OrderId)
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
                return JsonUtils.Deserialize<UpdateOrderResponse>(responseBody)!;
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
    /// Pay for an [order](entity:Order) using one or more approved [payments](entity:Payment)
    /// or settle an order with a total of `0`.
    ///
    /// The total of the `payment_ids` listed in the request must be equal to the order
    /// total. Orders with a total amount of `0` can be marked as paid by specifying an empty
    /// array of `payment_ids` in the request.
    ///
    /// To be used with `PayOrder`, a payment must:
    ///
    /// - Reference the order by specifying the `order_id` when [creating the payment](api-endpoint:Payments-CreatePayment).
    /// Any approved payments that reference the same `order_id` not specified in the
    /// `payment_ids` is canceled.
    /// - Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture).
    /// Using a delayed capture payment with `PayOrder` completes the approved payment.
    /// </summary>
    /// <example><code>
    /// await client.Orders.PayAsync(
    ///     new PayOrderRequest
    ///     {
    ///         OrderId = "order_id",
    ///         IdempotencyKey = "c043a359-7ad9-4136-82a9-c3f1d66dcbff",
    ///         PaymentIds = new List&lt;string&gt;()
    ///         {
    ///             "EnZdNAlWCmfh6Mt5FMNST1o7taB",
    ///             "0LRiVlbXVwe8ozu4KbZxd12mvaB",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<PayOrderResponse> PayAsync(
        PayOrderRequest request,
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
                        "v2/orders/{0}/pay",
                        ValueConvert.ToPathParameterString(request.OrderId)
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
                return JsonUtils.Deserialize<PayOrderResponse>(responseBody)!;
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
