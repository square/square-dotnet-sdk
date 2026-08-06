using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributeDefinitions;

public partial class CustomAttributeDefinitionsClient : ICustomAttributeDefinitionsClient
{
    private RawClient _client;

    internal CustomAttributeDefinitionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the merchant-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListMerchantCustomAttributeDefinitionsResponse> ListInternalAsync(
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
                    Path = "v2/merchants/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<ListMerchantCustomAttributeDefinitionsResponse>(
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
    /// Lists the merchant-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributeDefinitions.ListAsync(
    ///     new Square.Merchants.CustomAttributeDefinitions.ListCustomAttributeDefinitionsRequest
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
            ListMerchantCustomAttributeDefinitionsResponse,
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
    /// Creates a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to define a custom attribute that can be associated with a merchant connecting to your application.
    /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
    /// for a custom attribute. After the definition is created, you can call
    /// [UpsertMerchantCustomAttribute](api-endpoint:MerchantCustomAttributes-UpsertMerchantCustomAttribute) or
    /// [BulkUpsertMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkUpsertMerchantCustomAttributes)
    /// to set the custom attribute for a merchant.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributeDefinitions.CreateAsync(
    ///     new CreateMerchantCustomAttributeDefinitionRequest
    ///     {
    ///         CustomAttributeDefinition = new CustomAttributeDefinition
    ///         {
    ///             Key = "alternative_seller_name",
    ///             Schema = new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 {
    ///                     "$ref",
    ///                     "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
    ///                 },
    ///             },
    ///             Name = "Alternative Merchant Name",
    ///             Description = "This is the other name this merchant goes by.",
    ///             Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateMerchantCustomAttributeDefinitionResponse> CreateAsync(
        CreateMerchantCustomAttributeDefinitionRequest request,
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
                    Path = "v2/merchants/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<CreateMerchantCustomAttributeDefinitionResponse>(
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
    /// Retrieves a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributeDefinitions.GetAsync(
    ///     new Square.Merchants.CustomAttributeDefinitions.GetCustomAttributeDefinitionsRequest
    ///     {
    ///         Key = "key",
    ///         Version = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<RetrieveMerchantCustomAttributeDefinitionResponse> GetAsync(
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
                        "v2/merchants/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<RetrieveMerchantCustomAttributeDefinitionResponse>(
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
    /// Updates a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
    /// `schema` for a `Selection` data type.
    /// Only the definition owner can update a custom attribute definition.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributeDefinitions.UpdateAsync(
    ///     new UpdateMerchantCustomAttributeDefinitionRequest
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
    public async Task<UpdateMerchantCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateMerchantCustomAttributeDefinitionRequest request,
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
                        "v2/merchants/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<UpdateMerchantCustomAttributeDefinitionResponse>(
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
    /// Deletes a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// Deleting a custom attribute definition also deletes the corresponding custom attribute from
    /// the merchant.
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.CustomAttributeDefinitions.DeleteAsync(
    ///     new Square.Merchants.CustomAttributeDefinitions.DeleteCustomAttributeDefinitionsRequest
    ///     {
    ///         Key = "key",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteMerchantCustomAttributeDefinitionResponse> DeleteAsync(
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
                        "v2/merchants/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<DeleteMerchantCustomAttributeDefinitionResponse>(
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
