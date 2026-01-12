using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Orders.CustomAttributes;

public partial class CustomAttributesClient : ICustomAttributesClient
{
    private RawClient _client;

    internal CustomAttributesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with an order.
    ///
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    ///
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListOrderCustomAttributesResponse> ListInternalAsync(
        ListCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.VisibilityFilter != null)
        {
            _query["visibility_filter"] = request.VisibilityFilter.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.WithDefinitions != null)
        {
            _query["with_definitions"] = JsonUtils.Serialize(request.WithDefinitions.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/orders/{0}/custom-attributes",
                        ValueConvert.ToPathParameterString(request.OrderId)
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
                return JsonUtils.Deserialize<ListOrderCustomAttributesResponse>(responseBody)!;
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
    /// Deletes order [custom attributes](entity:CustomAttribute) as a bulk operation.
    ///
    /// Use this endpoint to delete one or more custom attributes from one or more orders.
    /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
    /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)
    ///
    /// This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete
    /// requests and returns a map of individual delete responses. Each delete request has a unique ID
    /// and provides an order ID and custom attribute. Each delete response is returned with the ID
    /// of the corresponding request.
    ///
    /// To delete a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Orders.CustomAttributes.BatchDeleteAsync(
    ///     new BulkDeleteOrderCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
    ///         &gt;()
    ///         {
    ///             {
    ///                 "cover-count",
    ///                 new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
    ///                 {
    ///                     Key = "cover-count",
    ///                     OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
    ///                 }
    ///             },
    ///             {
    ///                 "table-number",
    ///                 new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
    ///                 {
    ///                     Key = "table-number",
    ///                     OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkDeleteOrderCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteOrderCustomAttributesRequest request,
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
                    Path = "v2/orders/custom-attributes/bulk-delete",
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
                return JsonUtils.Deserialize<BulkDeleteOrderCustomAttributesResponse>(
                    responseBody
                )!;
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
    /// Creates or updates order [custom attributes](entity:CustomAttribute) as a bulk operation.
    ///
    /// Use this endpoint to delete one or more custom attributes from one or more orders.
    /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
    /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)
    ///
    /// This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides an order ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Orders.CustomAttributes.BatchUpsertAsync(
    ///     new BulkUpsertOrderCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
    ///         &gt;()
    ///         {
    ///             {
    ///                 "cover-count",
    ///                 new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
    ///                 {
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "cover-count",
    ///                         Value = "6",
    ///                         Version = 2,
    ///                     },
    ///                     OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
    ///                 }
    ///             },
    ///             {
    ///                 "table-number",
    ///                 new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
    ///                 {
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "table-number",
    ///                         Value = "11",
    ///                         Version = 4,
    ///                     },
    ///                     OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkUpsertOrderCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertOrderCustomAttributesRequest request,
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
                    Path = "v2/orders/custom-attributes/bulk-upsert",
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
                return JsonUtils.Deserialize<BulkUpsertOrderCustomAttributesResponse>(
                    responseBody
                )!;
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
    /// Lists the [custom attributes](entity:CustomAttribute) associated with an order.
    ///
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    ///
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Orders.CustomAttributes.ListAsync(
    ///     new Square.Default.Orders.CustomAttributes.ListCustomAttributesRequest
    ///     {
    ///         OrderId = "order_id",
    ///         VisibilityFilter = VisibilityFilter.All,
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///         WithDefinitions = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<CustomAttribute>> ListAsync(
        ListCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCustomAttributesRequest,
            RequestOptions?,
            ListOrderCustomAttributesResponse,
            string?,
            CustomAttribute
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.CustomAttributes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with an order.
    ///
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    ///
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Orders.CustomAttributes.GetAsync(
    ///     new Square.Default.Orders.CustomAttributes.GetCustomAttributesRequest
    ///     {
    ///         OrderId = "order_id",
    ///         CustomAttributeKey = "custom_attribute_key",
    ///         Version = 1,
    ///         WithDefinition = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<RetrieveOrderCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Version != null)
        {
            _query["version"] = request.Version.Value.ToString();
        }
        if (request.WithDefinition != null)
        {
            _query["with_definition"] = JsonUtils.Serialize(request.WithDefinition.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/orders/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.OrderId),
                        ValueConvert.ToPathParameterString(request.CustomAttributeKey)
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
                return JsonUtils.Deserialize<RetrieveOrderCustomAttributeResponse>(responseBody)!;
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
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for an order.
    ///
    /// Use this endpoint to set the value of a custom attribute for a specific order.
    /// A custom attribute is based on a custom attribute definition in a Square seller account. (To create a
    /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Orders.CustomAttributes.UpsertAsync(
    ///     new UpsertOrderCustomAttributeRequest
    ///     {
    ///         OrderId = "order_id",
    ///         CustomAttributeKey = "custom_attribute_key",
    ///         CustomAttribute = new CustomAttribute
    ///         {
    ///             Key = "table-number",
    ///             Value = "42",
    ///             Version = 1,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertOrderCustomAttributeResponse> UpsertAsync(
        UpsertOrderCustomAttributeRequest request,
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
                        "v2/orders/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.OrderId),
                        ValueConvert.ToPathParameterString(request.CustomAttributeKey)
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
                return JsonUtils.Deserialize<UpsertOrderCustomAttributeResponse>(responseBody)!;
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
    /// Deletes a [custom attribute](entity:CustomAttribute) associated with a customer profile.
    ///
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Orders.CustomAttributes.DeleteAsync(
    ///     new Square.Default.Orders.CustomAttributes.DeleteCustomAttributesRequest
    ///     {
    ///         OrderId = "order_id",
    ///         CustomAttributeKey = "custom_attribute_key",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteOrderCustomAttributeResponse> DeleteAsync(
        DeleteCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/orders/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.OrderId),
                        ValueConvert.ToPathParameterString(request.CustomAttributeKey)
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
                return JsonUtils.Deserialize<DeleteOrderCustomAttributeResponse>(responseBody)!;
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
