using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Customers.CustomAttributes;

public partial class CustomAttributesClient
{
    private RawClient _client;

    internal CustomAttributesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a customer profile.
    ///
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    ///
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListCustomerCustomAttributesResponse> ListInternalAsync(
        ListCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
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
                        "v2/customers/{0}/custom-attributes",
                        ValueConvert.ToPathParameterString(request.CustomerId)
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
                return JsonUtils.Deserialize<ListCustomerCustomAttributesResponse>(responseBody)!;
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
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a customer profile.
    ///
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    ///
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributes.ListAsync(
    ///     new ListCustomAttributesRequest
    ///     {
    ///         CustomerId = "customer_id",
    ///         Limit = 1,
    ///         Cursor = "cursor",
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
            ListCustomerCustomAttributesResponse,
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
                response => response?.Cursor,
                response => response?.CustomAttributes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with a customer profile.
    ///
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    ///
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributes.GetAsync(
    ///     new GetCustomAttributesRequest
    ///     {
    ///         CustomerId = "customer_id",
    ///         Key = "key",
    ///         WithDefinition = true,
    ///         Version = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<GetCustomerCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.WithDefinition != null)
        {
            _query["with_definition"] = JsonUtils.Serialize(request.WithDefinition.Value);
        }
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
                        "v2/customers/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.CustomerId),
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
                return JsonUtils.Deserialize<GetCustomerCustomAttributeResponse>(responseBody)!;
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
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for a customer profile.
    ///
    /// Use this endpoint to set the value of a custom attribute for a specified customer profile.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which
    /// is created using the [CreateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-CreateCustomerCustomAttributeDefinition) endpoint.
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributes.UpsertAsync(
    ///     new UpsertCustomerCustomAttributeRequest
    ///     {
    ///         CustomerId = "customer_id",
    ///         Key = "key",
    ///         CustomAttribute = new CustomAttribute { Value = "Dune" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertCustomerCustomAttributeResponse> UpsertAsync(
        UpsertCustomerCustomAttributeRequest request,
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
                        "v2/customers/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.CustomerId),
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
                return JsonUtils.Deserialize<UpsertCustomerCustomAttributeResponse>(responseBody)!;
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
    /// await client.Customers.CustomAttributes.DeleteAsync(
    ///     new DeleteCustomAttributesRequest { CustomerId = "customer_id", Key = "key" }
    /// );
    /// </code></example>
    public async Task<DeleteCustomerCustomAttributeResponse> DeleteAsync(
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
                        "v2/customers/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.CustomerId),
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
                return JsonUtils.Deserialize<DeleteCustomerCustomAttributeResponse>(responseBody)!;
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
