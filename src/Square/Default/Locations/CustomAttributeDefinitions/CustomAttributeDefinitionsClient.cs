using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Locations.CustomAttributeDefinitions;

public partial class CustomAttributeDefinitionsClient : ICustomAttributeDefinitionsClient
{
    private RawClient _client;

    internal CustomAttributeDefinitionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the location-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListLocationCustomAttributeDefinitionsResponse> ListInternalAsync(
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
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
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
                    Path = "v2/locations/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<ListLocationCustomAttributeDefinitionsResponse>(
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
    /// Lists the location-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributeDefinitions.ListAsync(
    ///     new Square.Default.Locations.CustomAttributeDefinitions.ListCustomAttributeDefinitionsRequest
    ///     {
    ///         VisibilityFilter = VisibilityFilter.All,
    ///         Limit = 1,
    ///         Cursor = "cursor",
    ///     }
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
            ListLocationCustomAttributeDefinitionsResponse,
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
                response => response.Cursor,
                response => response.CustomAttributeDefinitions?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a location-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to define a custom attribute that can be associated with locations.
    /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
    /// for a custom attribute. After the definition is created, you can call
    /// [UpsertLocationCustomAttribute](api-endpoint:LocationCustomAttributes-UpsertLocationCustomAttribute) or
    /// [BulkUpsertLocationCustomAttributes](api-endpoint:LocationCustomAttributes-BulkUpsertLocationCustomAttributes)
    /// to set the custom attribute for locations.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributeDefinitions.CreateAsync(
    ///     new CreateLocationCustomAttributeDefinitionRequest
    ///     {
    ///         CustomAttributeDefinition = new CustomAttributeDefinition
    ///         {
    ///             Key = "bestseller",
    ///             Schema = new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 {
    ///                     "$ref",
    ///                     "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
    ///                 },
    ///             },
    ///             Name = "Bestseller",
    ///             Description = "Bestselling item at location",
    ///             Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateLocationCustomAttributeDefinitionResponse> CreateAsync(
        CreateLocationCustomAttributeDefinitionRequest request,
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
                    Path = "v2/locations/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<CreateLocationCustomAttributeDefinitionResponse>(
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
    /// Retrieves a location-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributeDefinitions.GetAsync(
    ///     new Square.Default.Locations.CustomAttributeDefinitions.GetCustomAttributeDefinitionsRequest
    ///     {
    ///         Key = "key",
    ///         Version = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<RetrieveLocationCustomAttributeDefinitionResponse> GetAsync(
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
                        "v2/locations/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<RetrieveLocationCustomAttributeDefinitionResponse>(
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
    /// Updates a location-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
    /// `schema` for a `Selection` data type.
    /// Only the definition owner can update a custom attribute definition.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributeDefinitions.UpdateAsync(
    ///     new UpdateLocationCustomAttributeDefinitionRequest
    ///     {
    ///         Key = "key",
    ///         CustomAttributeDefinition = new CustomAttributeDefinition
    ///         {
    ///             Description = "Update the description as desired.",
    ///             Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateLocationCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateLocationCustomAttributeDefinitionRequest request,
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
                        "v2/locations/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<UpdateLocationCustomAttributeDefinitionResponse>(
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
    /// Deletes a location-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// Deleting a custom attribute definition also deletes the corresponding custom attribute from
    /// all locations.
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    /// <example><code>
    /// await client.Default.Locations.CustomAttributeDefinitions.DeleteAsync(
    ///     new Square.Default.Locations.CustomAttributeDefinitions.DeleteCustomAttributeDefinitionsRequest
    ///     {
    ///         Key = "key",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteLocationCustomAttributeDefinitionResponse> DeleteAsync(
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
                        "v2/locations/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<DeleteLocationCustomAttributeDefinitionResponse>(
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
