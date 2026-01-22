using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributes;

public partial class CustomAttributesClient : ICustomAttributesClient
{
    private RawClient _client;

    internal CustomAttributesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a merchant.
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListMerchantCustomAttributesResponse> ListInternalAsync(
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
                        "v2/merchants/{0}/custom-attributes",
                        ValueConvert.ToPathParameterString(request.MerchantId)
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
                return JsonUtils.Deserialize<ListMerchantCustomAttributesResponse>(responseBody)!;
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
    /// Deletes [custom attributes](entity:CustomAttribute) for a merchant as a bulk operation.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributes.BatchDeleteAsync(
    ///     new BulkDeleteMerchantCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
    ///         &gt;()
    ///         {
    ///             {
    ///                 "id1",
    ///                 new BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
    ///                 {
    ///                     Key = "alternative_seller_name",
    ///                 }
    ///             },
    ///             {
    ///                 "id2",
    ///                 new BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
    ///                 {
    ///                     Key = "has_seen_tutorial",
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkDeleteMerchantCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteMerchantCustomAttributesRequest request,
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
                    Path = "v2/merchants/custom-attributes/bulk-delete",
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
                return JsonUtils.Deserialize<BulkDeleteMerchantCustomAttributesResponse>(
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
    /// Creates or updates [custom attributes](entity:CustomAttribute) for a merchant as a bulk operation.
    /// Use this endpoint to set the value of one or more custom attributes for a merchant.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which is
    /// created using the [CreateMerchantCustomAttributeDefinition](api-endpoint:MerchantCustomAttributes-CreateMerchantCustomAttributeDefinition) endpoint.
    /// This `BulkUpsertMerchantCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides a merchant ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributes.BatchUpsertAsync(
    ///     new BulkUpsertMerchantCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
    ///         &gt;()
    ///         {
    ///             {
    ///                 "id1",
    ///                 new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
    ///                 {
    ///                     MerchantId = "DM7VKY8Q63GNP",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "alternative_seller_name",
    ///                         Value = "Ultimate Sneaker Store",
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "id2",
    ///                 new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
    ///                 {
    ///                     MerchantId = "DM7VKY8Q63GNP",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "has_seen_tutorial",
    ///                         Value = true,
    ///                     },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkUpsertMerchantCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertMerchantCustomAttributesRequest request,
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
                    Path = "v2/merchants/custom-attributes/bulk-upsert",
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
                return JsonUtils.Deserialize<BulkUpsertMerchantCustomAttributesResponse>(
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
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a merchant.
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributes.ListAsync(
    ///     new Square.Merchants.CustomAttributes.ListCustomAttributesRequest
    ///     {
    ///         MerchantId = "merchant_id",
    ///         VisibilityFilter = VisibilityFilter.All,
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
            ListMerchantCustomAttributesResponse,
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
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with a merchant.
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributes.GetAsync(
    ///     new Square.Merchants.CustomAttributes.GetCustomAttributesRequest
    ///     {
    ///         MerchantId = "merchant_id",
    ///         Key = "key",
    ///         WithDefinition = true,
    ///         Version = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<RetrieveMerchantCustomAttributeResponse> GetAsync(
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
                        "v2/merchants/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.MerchantId),
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
                return JsonUtils.Deserialize<RetrieveMerchantCustomAttributeResponse>(
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
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for a merchant.
    /// Use this endpoint to set the value of a custom attribute for a specified merchant.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which
    /// is created using the [CreateMerchantCustomAttributeDefinition](api-endpoint:MerchantCustomAttributes-CreateMerchantCustomAttributeDefinition) endpoint.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributes.UpsertAsync(
    ///     new UpsertMerchantCustomAttributeRequest
    ///     {
    ///         MerchantId = "merchant_id",
    ///         Key = "key",
    ///         CustomAttribute = new CustomAttribute { Value = "Ultimate Sneaker Store" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertMerchantCustomAttributeResponse> UpsertAsync(
        UpsertMerchantCustomAttributeRequest request,
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
                        "v2/merchants/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.MerchantId),
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
                return JsonUtils.Deserialize<UpsertMerchantCustomAttributeResponse>(responseBody)!;
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
    /// Deletes a [custom attribute](entity:CustomAttribute) associated with a merchant.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributes.DeleteAsync(
    ///     new Square.Merchants.CustomAttributes.DeleteCustomAttributesRequest
    ///     {
    ///         MerchantId = "merchant_id",
    ///         Key = "key",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteMerchantCustomAttributeResponse> DeleteAsync(
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
                        "v2/merchants/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.MerchantId),
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
                return JsonUtils.Deserialize<DeleteMerchantCustomAttributeResponse>(responseBody)!;
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
