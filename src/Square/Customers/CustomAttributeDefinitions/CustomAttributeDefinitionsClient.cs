using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Customers.CustomAttributeDefinitions;

public partial class CustomAttributeDefinitionsClient
{
    private RawClient _client;

    internal CustomAttributeDefinitionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the customer-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    ///
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
    /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    private async Task<ListCustomerCustomAttributeDefinitionsResponse> ListInternalAsync(
        ListCustomAttributeDefinitionsRequest request,
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/customers/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<ListCustomerCustomAttributeDefinitionsResponse>(
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
    /// Lists the customer-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    ///
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
    /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributeDefinitions.ListAsync(
    ///     new ListCustomAttributeDefinitionsRequest { Limit = 1, Cursor = "cursor" }
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
            ListCustomerCustomAttributeDefinitionsResponse,
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
    /// Creates a customer-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to define a custom attribute that can be associated with customer profiles.
    ///
    /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
    /// for a custom attribute. After the definition is created, you can call
    /// [UpsertCustomerCustomAttribute](api-endpoint:CustomerCustomAttributes-UpsertCustomerCustomAttribute) or
    /// [BulkUpsertCustomerCustomAttributes](api-endpoint:CustomerCustomAttributes-BulkUpsertCustomerCustomAttributes)
    /// to set the custom attribute for customer profiles in the seller's Customer Directory.
    ///
    /// Sellers can view all custom attributes in exported customer data, including those set to
    /// `VISIBILITY_HIDDEN`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributeDefinitions.CreateAsync(
    ///     new CreateCustomerCustomAttributeDefinitionRequest
    ///     {
    ///         CustomAttributeDefinition = new CustomAttributeDefinition
    ///         {
    ///             Key = "favoritemovie",
    ///             Schema = new Dictionary&lt;string, object&gt;()
    ///             {
    ///                 {
    ///                     "$ref",
    ///                     "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
    ///                 },
    ///             },
    ///             Name = "Favorite Movie",
    ///             Description = "The favorite movie of the customer.",
    ///             Visibility = CustomAttributeDefinitionVisibility.VisibilityHidden,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateCustomerCustomAttributeDefinitionResponse> CreateAsync(
        CreateCustomerCustomAttributeDefinitionRequest request,
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
                    Path = "v2/customers/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<CreateCustomerCustomAttributeDefinitionResponse>(
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
    /// Retrieves a customer-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributeDefinitions.GetAsync(
    ///     new GetCustomAttributeDefinitionsRequest { Key = "key", Version = 1 }
    /// );
    /// </code></example>
    public async Task<GetCustomerCustomAttributeDefinitionResponse> GetAsync(
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
                        "v2/customers/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<GetCustomerCustomAttributeDefinitionResponse>(
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
    /// Updates a customer-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    ///
    /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
    /// `schema` for a `Selection` data type.
    ///
    /// Only the definition owner can update a custom attribute definition. Note that sellers can view
    /// all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributeDefinitions.UpdateAsync(
    ///     new UpdateCustomerCustomAttributeDefinitionRequest
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
    public async Task<UpdateCustomerCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateCustomerCustomAttributeDefinitionRequest request,
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
                        "v2/customers/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<UpdateCustomerCustomAttributeDefinitionResponse>(
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
    /// Deletes a customer-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// Deleting a custom attribute definition also deletes the corresponding custom attribute from
    /// all customer profiles in the seller's Customer Directory.
    ///
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributeDefinitions.DeleteAsync(
    ///     new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
    /// );
    /// </code></example>
    public async Task<DeleteCustomerCustomAttributeDefinitionResponse> DeleteAsync(
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
                        "v2/customers/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<DeleteCustomerCustomAttributeDefinitionResponse>(
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
    /// Creates or updates [custom attributes](entity:CustomAttribute) for customer profiles as a bulk operation.
    ///
    /// Use this endpoint to set the value of one or more custom attributes for one or more customer profiles.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which is
    /// created using the [CreateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-CreateCustomerCustomAttributeDefinition) endpoint.
    ///
    /// This `BulkUpsertCustomerCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides a customer ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    /// <example><code>
    /// await client.Customers.CustomAttributeDefinitions.BatchUpsertAsync(
    ///     new BatchUpsertCustomerCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;
    ///             string,
    ///             BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    ///         &gt;()
    ///         {
    ///             {
    ///                 "id1",
    ///                 new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    ///                 {
    ///                     CustomerId = "N3NCVYY3WS27HF0HKANA3R9FP8",
    ///                     CustomAttribute = new CustomAttribute { Key = "favoritemovie", Value = "Dune" },
    ///                 }
    ///             },
    ///             {
    ///                 "id2",
    ///                 new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    ///                 {
    ///                     CustomerId = "SY8EMWRNDN3TQDP2H4KS1QWMMM",
    ///                     CustomAttribute = new CustomAttribute { Key = "ownsmovie", Value = false },
    ///                 }
    ///             },
    ///             {
    ///                 "id3",
    ///                 new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    ///                 {
    ///                     CustomerId = "SY8EMWRNDN3TQDP2H4KS1QWMMM",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "favoritemovie",
    ///                         Value = "Star Wars",
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "id4",
    ///                 new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    ///                 {
    ///                     CustomerId = "N3NCVYY3WS27HF0HKANA3R9FP8",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "square:a0f1505a-2aa1-490d-91a8-8d31ff181808",
    ///                         Value = "10.5",
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "id5",
    ///                 new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    ///                 {
    ///                     CustomerId = "70548QG1HN43B05G0KCZ4MMC1G",
    ///                     CustomAttribute = new CustomAttribute
    ///                     {
    ///                         Key = "sq0ids-0evKIskIGaY45fCyNL66aw:backupemail",
    ///                         Value = "fake-email@squareup.com",
    ///                     },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchUpsertCustomerCustomAttributesResponse> BatchUpsertAsync(
        BatchUpsertCustomerCustomAttributesRequest request,
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
                    Path = "v2/customers/custom-attributes/bulk-upsert",
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
                return JsonUtils.Deserialize<BatchUpsertCustomerCustomAttributesResponse>(
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
