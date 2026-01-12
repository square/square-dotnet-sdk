using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Locations.CustomAttributes;

public partial class CustomAttributesClient : ICustomAttributesClient
{
    private RawClient _client;

    internal CustomAttributesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a location.
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListLocationCustomAttributesResponse> ListInternalAsync(
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
                        "v2/locations/{0}/custom-attributes",
                        ValueConvert.ToPathParameterString(request.LocationId)
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
                return JsonUtils.Deserialize<ListLocationCustomAttributesResponse>(responseBody)!;
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
    /// Deletes [custom attributes](entity:CustomAttribute) for locations as a bulk operation.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributes.BatchDeleteAsync(
    ///     new BulkDeleteLocationCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
    ///         &gt;()
    ///         {
    ///             {
    ///                 "id1",
    ///                 new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
    ///                 {
    ///                     Key = "bestseller",
    ///                 }
    ///             },
    ///             {
    ///                 "id2",
    ///                 new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
    ///                 {
    ///                     Key = "bestseller",
    ///                 }
    ///             },
    ///             {
    ///                 "id3",
    ///                 new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
    ///                 {
    ///                     Key = "phone-number",
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkDeleteLocationCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteLocationCustomAttributesRequest request,
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
                    Path = "v2/locations/custom-attributes/bulk-delete",
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
                return JsonUtils.Deserialize<BulkDeleteLocationCustomAttributesResponse>(
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
    /// Creates or updates [custom attributes](entity:CustomAttribute) for locations as a bulk operation.
    /// Use this endpoint to set the value of one or more custom attributes for one or more locations.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which is
    /// created using the [CreateLocationCustomAttributeDefinition](api-endpoint:LocationCustomAttributes-CreateLocationCustomAttributeDefinition) endpoint.
    /// This `BulkUpsertLocationCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides a location ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributes.BatchUpsertAsync(
    ///     new BulkUpsertLocationCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
    ///         &gt;()
    ///         {
    ///             {
    ///                 "id1",
    ///                 new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
    ///                 {
    ///                     LocationId = "L0TBCBTB7P8RQ",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "bestseller",
    ///                         Value = "hot cocoa",
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "id2",
    ///                 new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
    ///                 {
    ///                     LocationId = "L9XMD04V3STJX",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "bestseller",
    ///                         Value = "berry smoothie",
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "id3",
    ///                 new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
    ///                 {
    ///                     LocationId = "L0TBCBTB7P8RQ",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "phone-number",
    ///                         Value = "+12223334444",
    ///                     },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkUpsertLocationCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertLocationCustomAttributesRequest request,
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
                    Path = "v2/locations/custom-attributes/bulk-upsert",
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
                return JsonUtils.Deserialize<BulkUpsertLocationCustomAttributesResponse>(
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
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a location.
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributes.ListAsync(
    ///     new Square.Default.Locations.CustomAttributes.ListCustomAttributesRequest
    ///     {
    ///         LocationId = "location_id",
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
            ListLocationCustomAttributesResponse,
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
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with a location.
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributes.GetAsync(
    ///     new Square.Default.Locations.CustomAttributes.GetCustomAttributesRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Key = "key",
    ///         WithDefinition = true,
    ///         Version = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<RetrieveLocationCustomAttributeResponse> GetAsync(
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
                        "v2/locations/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.LocationId),
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
                return JsonUtils.Deserialize<RetrieveLocationCustomAttributeResponse>(
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
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for a location.
    /// Use this endpoint to set the value of a custom attribute for a specified location.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which
    /// is created using the [CreateLocationCustomAttributeDefinition](api-endpoint:LocationCustomAttributes-CreateLocationCustomAttributeDefinition) endpoint.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributes.UpsertAsync(
    ///     new UpsertLocationCustomAttributeRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Key = "key",
    ///         CustomAttribute = new CustomAttribute { Value = "hot cocoa" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertLocationCustomAttributeResponse> UpsertAsync(
        UpsertLocationCustomAttributeRequest request,
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
                        "v2/locations/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.LocationId),
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
                return JsonUtils.Deserialize<UpsertLocationCustomAttributeResponse>(responseBody)!;
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
    /// Deletes a [custom attribute](entity:CustomAttribute) associated with a location.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributes.DeleteAsync(
    ///     new Square.Default.Locations.CustomAttributes.DeleteCustomAttributesRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Key = "key",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteLocationCustomAttributeResponse> DeleteAsync(
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
                        "v2/locations/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.LocationId),
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
                return JsonUtils.Deserialize<DeleteLocationCustomAttributeResponse>(responseBody)!;
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
