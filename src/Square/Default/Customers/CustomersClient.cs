using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;
using Square.Default.Customers.Groups;
using Square.Default.Customers.Segments;

namespace Square.Default.Customers;

public partial class CustomersClient : ICustomersClient
{
    private RawClient _client;

    internal CustomersClient(RawClient client)
    {
        _client = client;
        CustomAttributeDefinitions =
            new Square.Default.Customers.CustomAttributeDefinitions.CustomAttributeDefinitionsClient(
                _client
            );
        Groups = new GroupsClient(_client);
        Segments = new SegmentsClient(_client);
        Cards = new Square.Default.Customers.Cards.CardsClient(_client);
        CustomAttributes = new Square.Default.Customers.CustomAttributes.CustomAttributesClient(
            _client
        );
    }

    public Square.Default.Customers.CustomAttributeDefinitions.CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }

    public GroupsClient Groups { get; }

    public SegmentsClient Segments { get; }

    public Square.Default.Customers.Cards.CardsClient Cards { get; }

    public Square.Default.Customers.CustomAttributes.CustomAttributesClient CustomAttributes { get; }

    /// <summary>
    /// Lists customer profiles associated with a Square account.
    ///
    /// Under normal operating conditions, newly created or updated customer profiles become available
    /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated
    /// profiles can take closer to one minute or longer, especially during network incidents and outages.
    /// </summary>
    private async Task<ListCustomersResponse> ListInternalAsync(
        ListCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.SortField != null)
        {
            _query["sort_field"] = request.SortField.Value.ToString();
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
        }
        if (request.Count != null)
        {
            _query["count"] = JsonUtils.Serialize(request.Count.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/customers",
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
                return JsonUtils.Deserialize<ListCustomersResponse>(responseBody)!;
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
    /// Lists customer profiles associated with a Square account.
    ///
    /// Under normal operating conditions, newly created or updated customer profiles become available
    /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated
    /// profiles can take closer to one minute or longer, especially during network incidents and outages.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.ListAsync(
    ///     new ListCustomersRequest
    ///     {
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///         SortField = CustomerSortField.Default,
    ///         SortOrder = SortOrder.Desc,
    ///         Count = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Customer>> ListAsync(
        ListCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCustomersRequest,
            RequestOptions?,
            ListCustomersResponse,
            string?,
            Customer
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
                response => response.Customers?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a new customer for a business.
    ///
    /// You must provide at least one of the following values in your request to this
    /// endpoint:
    ///
    /// - `given_name`
    /// - `family_name`
    /// - `company_name`
    /// - `email_address`
    /// - `phone_number`
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.CreateAsync(
    ///     new CreateCustomerRequest
    ///     {
    ///         GivenName = "Amelia",
    ///         FamilyName = "Earhart",
    ///         EmailAddress = "Amelia.Earhart@example.com",
    ///         Address = new Address
    ///         {
    ///             AddressLine1 = "500 Electric Ave",
    ///             AddressLine2 = "Suite 600",
    ///             Locality = "New York",
    ///             AdministrativeDistrictLevel1 = "NY",
    ///             PostalCode = "10003",
    ///             Country = Country.Us,
    ///         },
    ///         PhoneNumber = "+1-212-555-4240",
    ///         ReferenceId = "YOUR_REFERENCE_ID",
    ///         Note = "a customer",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateCustomerResponse> CreateAsync(
        CreateCustomerRequest request,
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
                    Path = "v2/customers",
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
                return JsonUtils.Deserialize<CreateCustomerResponse>(responseBody)!;
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
    /// Creates multiple [customer profiles](entity:Customer) for a business.
    ///
    /// This endpoint takes a map of individual create requests and returns a map of responses.
    ///
    /// You must provide at least one of the following values in each create request:
    ///
    /// - `given_name`
    /// - `family_name`
    /// - `company_name`
    /// - `email_address`
    /// - `phone_number`
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.BatchCreateAsync(
    ///     new BulkCreateCustomersRequest
    ///     {
    ///         Customers = new Dictionary&lt;string, BulkCreateCustomerData&gt;()
    ///         {
    ///             {
    ///                 "8bb76c4f-e35d-4c5b-90de-1194cd9179f0",
    ///                 new BulkCreateCustomerData
    ///                 {
    ///                     GivenName = "Amelia",
    ///                     FamilyName = "Earhart",
    ///                     EmailAddress = "Amelia.Earhart@example.com",
    ///                     Address = new Address
    ///                     {
    ///                         AddressLine1 = "500 Electric Ave",
    ///                         AddressLine2 = "Suite 600",
    ///                         Locality = "New York",
    ///                         AdministrativeDistrictLevel1 = "NY",
    ///                         PostalCode = "10003",
    ///                         Country = Country.Us,
    ///                     },
    ///                     PhoneNumber = "+1-212-555-4240",
    ///                     ReferenceId = "YOUR_REFERENCE_ID",
    ///                     Note = "a customer",
    ///                 }
    ///             },
    ///             {
    ///                 "d1689f23-b25d-4932-b2f0-aed00f5e2029",
    ///                 new BulkCreateCustomerData
    ///                 {
    ///                     GivenName = "Marie",
    ///                     FamilyName = "Curie",
    ///                     EmailAddress = "Marie.Curie@example.com",
    ///                     Address = new Address
    ///                     {
    ///                         AddressLine1 = "500 Electric Ave",
    ///                         AddressLine2 = "Suite 601",
    ///                         Locality = "New York",
    ///                         AdministrativeDistrictLevel1 = "NY",
    ///                         PostalCode = "10003",
    ///                         Country = Country.Us,
    ///                     },
    ///                     PhoneNumber = "+1-212-444-4240",
    ///                     ReferenceId = "YOUR_REFERENCE_ID",
    ///                     Note = "another customer",
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkCreateCustomersResponse> BatchCreateAsync(
        BulkCreateCustomersRequest request,
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
                    Path = "v2/customers/bulk-create",
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
                return JsonUtils.Deserialize<BulkCreateCustomersResponse>(responseBody)!;
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
    /// Deletes multiple customer profiles.
    ///
    /// The endpoint takes a list of customer IDs and returns a map of responses.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.BulkDeleteCustomersAsync(
    ///     new BulkDeleteCustomersRequest
    ///     {
    ///         CustomerIds = new List&lt;string&gt;()
    ///         {
    ///             "8DDA5NZVBZFGAX0V3HPF81HHE0",
    ///             "N18CPRVXR5214XPBBA6BZQWF3C",
    ///             "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkDeleteCustomersResponse> BulkDeleteCustomersAsync(
        BulkDeleteCustomersRequest request,
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
                    Path = "v2/customers/bulk-delete",
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
                return JsonUtils.Deserialize<BulkDeleteCustomersResponse>(responseBody)!;
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
    /// Retrieves multiple customer profiles.
    ///
    /// This endpoint takes a list of customer IDs and returns a map of responses.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.BulkRetrieveCustomersAsync(
    ///     new BulkRetrieveCustomersRequest
    ///     {
    ///         CustomerIds = new List&lt;string&gt;()
    ///         {
    ///             "8DDA5NZVBZFGAX0V3HPF81HHE0",
    ///             "N18CPRVXR5214XPBBA6BZQWF3C",
    ///             "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkRetrieveCustomersResponse> BulkRetrieveCustomersAsync(
        BulkRetrieveCustomersRequest request,
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
                    Path = "v2/customers/bulk-retrieve",
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
                return JsonUtils.Deserialize<BulkRetrieveCustomersResponse>(responseBody)!;
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
    /// Updates multiple customer profiles.
    ///
    /// This endpoint takes a map of individual update requests and returns a map of responses.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.BulkUpdateCustomersAsync(
    ///     new BulkUpdateCustomersRequest
    ///     {
    ///         Customers = new Dictionary&lt;string, BulkUpdateCustomerData&gt;()
    ///         {
    ///             {
    ///                 "8DDA5NZVBZFGAX0V3HPF81HHE0",
    ///                 new BulkUpdateCustomerData
    ///                 {
    ///                     EmailAddress = "New.Amelia.Earhart@example.com",
    ///                     Note = "updated customer note",
    ///                     Version = 2,
    ///                 }
    ///             },
    ///             {
    ///                 "N18CPRVXR5214XPBBA6BZQWF3C",
    ///                 new BulkUpdateCustomerData
    ///                 {
    ///                     GivenName = "Marie",
    ///                     FamilyName = "Curie",
    ///                     Version = 0,
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkUpdateCustomersResponse> BulkUpdateCustomersAsync(
        BulkUpdateCustomersRequest request,
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
                    Path = "v2/customers/bulk-update",
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
                return JsonUtils.Deserialize<BulkUpdateCustomersResponse>(responseBody)!;
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
    /// Searches the customer profiles associated with a Square account using one or more supported query filters.
    ///
    /// Calling `SearchCustomers` without any explicit query filter returns all
    /// customer profiles ordered alphabetically based on `given_name` and
    /// `family_name`.
    ///
    /// Under normal operating conditions, newly created or updated customer profiles become available
    /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated
    /// profiles can take closer to one minute or longer, especially during network incidents and outages.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.SearchAsync(
    ///     new SearchCustomersRequest
    ///     {
    ///         Limit = 2,
    ///         Query = new CustomerQuery
    ///         {
    ///             Filter = new CustomerFilter
    ///             {
    ///                 CreationSource = new CustomerCreationSourceFilter
    ///                 {
    ///                     Values = new List&lt;CustomerCreationSource&gt;()
    ///                     {
    ///                         CustomerCreationSource.ThirdParty,
    ///                     },
    ///                     Rule = CustomerInclusionExclusion.Include,
    ///                 },
    ///                 CreatedAt = new TimeRange
    ///                 {
    ///                     StartAt = "2018-01-01T00:00:00-00:00",
    ///                     EndAt = "2018-02-01T00:00:00-00:00",
    ///                 },
    ///                 EmailAddress = new CustomerTextFilter { Fuzzy = "example.com" },
    ///                 GroupIds = new FilterValue
    ///                 {
    ///                     All = new List&lt;string&gt;() { "545AXB44B4XXWMVQ4W8SBT3HHF" },
    ///                 },
    ///             },
    ///             Sort = new CustomerSort { Field = CustomerSortField.CreatedAt, Order = SortOrder.Asc },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchCustomersResponse> SearchAsync(
        SearchCustomersRequest request,
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
                    Path = "v2/customers/search",
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
                return JsonUtils.Deserialize<SearchCustomersResponse>(responseBody)!;
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
    /// Returns details for a single customer.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.GetAsync(new GetCustomersRequest { CustomerId = "customer_id" });
    /// </code></example>
    public async Task<GetCustomerResponse> GetAsync(
        GetCustomersRequest request,
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
                        "v2/customers/{0}",
                        ValueConvert.ToPathParameterString(request.CustomerId)
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
                return JsonUtils.Deserialize<GetCustomerResponse>(responseBody)!;
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
    /// Updates a customer profile. This endpoint supports sparse updates, so only new or changed fields are required in the request.
    /// To add or update a field, specify the new value. To remove a field, specify `null`.
    ///
    /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.UpdateAsync(
    ///     new UpdateCustomerRequest
    ///     {
    ///         CustomerId = "customer_id",
    ///         EmailAddress = "New.Amelia.Earhart@example.com",
    ///         Note = "updated customer note",
    ///         Version = 2,
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateCustomerResponse> UpdateAsync(
        UpdateCustomerRequest request,
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
                        "v2/customers/{0}",
                        ValueConvert.ToPathParameterString(request.CustomerId)
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
                return JsonUtils.Deserialize<UpdateCustomerResponse>(responseBody)!;
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
    /// Deletes a customer profile from a business.
    ///
    /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
    /// </summary>
    /// <example><code>
    /// await client.Default.Customers.DeleteAsync(
    ///     new DeleteCustomersRequest { CustomerId = "customer_id", Version = 1000000 }
    /// );
    /// </code></example>
    public async Task<DeleteCustomerResponse> DeleteAsync(
        DeleteCustomersRequest request,
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
                        "v2/customers/{0}",
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
                return JsonUtils.Deserialize<DeleteCustomerResponse>(responseBody)!;
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
