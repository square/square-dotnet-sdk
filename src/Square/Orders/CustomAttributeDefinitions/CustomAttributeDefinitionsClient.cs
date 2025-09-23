using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Orders.CustomAttributeDefinitions;

public partial class CustomAttributeDefinitionsClient
{
    private RawClient _client;

    internal CustomAttributeDefinitionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the order-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    ///
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
    /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListOrderCustomAttributeDefinitionsResponse> ListInternalAsync(
        ListCustomAttributeDefinitionsRequest request,
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/orders/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<ListOrderCustomAttributeDefinitionsResponse>(
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
    /// Lists the order-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    ///
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
    /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CustomAttributeDefinitions.ListAsync(
    ///     new ListCustomAttributeDefinitionsRequest()
    /// );
    /// </code></example>
    public async Task<Pager<CustomAttributeDefinition>> ListAsync(
        ListCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCustomAttributeDefinitionsRequest,
            RequestOptions?,
            ListOrderCustomAttributeDefinitionsResponse,
            string?,
            CustomAttributeDefinition
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
                response => response?.CustomAttributeDefinitions?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates an order-related custom attribute definition.  Use this endpoint to
    /// define a custom attribute that can be associated with orders.
    ///
    /// After creating a custom attribute definition, you can set the custom attribute for orders
    /// in the Square seller account.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CustomAttributeDefinitions.CreateAsync(
    ///     new CreateOrderCustomAttributeDefinitionRequest
    ///     {
    ///         CustomAttributeDefinition = new CustomAttributeDefinition
    ///         {
    ///             Key = "cover-count",
    ///             Schema = new Dictionary&lt;string, object&gt;()
    ///             {
    ///                 {
    ///                     "$ref",
    ///                     "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
    ///                 },
    ///             },
    ///             Name = "Cover count",
    ///             Description = "The number of people seated at a table",
    ///             Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
    ///         },
    ///         IdempotencyKey = "IDEMPOTENCY_KEY",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateOrderCustomAttributeDefinitionResponse> CreateAsync(
        CreateOrderCustomAttributeDefinitionRequest request,
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
                    Path = "v2/orders/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<CreateOrderCustomAttributeDefinitionResponse>(
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
    /// Retrieves an order-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CustomAttributeDefinitions.GetAsync(
    ///     new GetCustomAttributeDefinitionsRequest { Key = "key" }
    /// );
    /// </code></example>
    public async Task<RetrieveOrderCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/orders/custom-attribute-definitions/{0}",
                        ValueConvert.ToPathParameterString(request.Key)
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
                return JsonUtils.Deserialize<RetrieveOrderCustomAttributeDefinitionResponse>(
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
    /// Updates an order-related custom attribute definition for a Square seller account.
    ///
    /// Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CustomAttributeDefinitions.UpdateAsync(
    ///     new UpdateOrderCustomAttributeDefinitionRequest
    ///     {
    ///         Key = "key",
    ///         CustomAttributeDefinition = new CustomAttributeDefinition
    ///         {
    ///             Key = "cover-count",
    ///             Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
    ///             Version = 1,
    ///         },
    ///         IdempotencyKey = "IDEMPOTENCY_KEY",
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateOrderCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateOrderCustomAttributeDefinitionRequest request,
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
                        "v2/orders/custom-attribute-definitions/{0}",
                        ValueConvert.ToPathParameterString(request.Key)
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
                return JsonUtils.Deserialize<UpdateOrderCustomAttributeDefinitionResponse>(
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
    /// Deletes an order-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    /// <example><code>
    /// await client.Orders.CustomAttributeDefinitions.DeleteAsync(
    ///     new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
    /// );
    /// </code></example>
    public async Task<DeleteOrderCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
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
                        "v2/orders/custom-attribute-definitions/{0}",
                        ValueConvert.ToPathParameterString(request.Key)
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
                return JsonUtils.Deserialize<DeleteOrderCustomAttributeDefinitionResponse>(
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
}
