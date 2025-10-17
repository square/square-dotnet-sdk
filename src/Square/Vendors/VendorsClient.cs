using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Vendors;

public partial class VendorsClient
{
    private RawClient _client;

    internal VendorsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates one or more [Vendor](entity:Vendor) objects to represent suppliers to a seller.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.BatchCreateAsync(
    ///     new BatchCreateVendorsRequest
    ///     {
    ///         Vendors = new Dictionary&lt;string, Vendor&gt;()
    ///         {
    ///             {
    ///                 "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
    ///                 new Vendor
    ///                 {
    ///                     Name = "Joe's Fresh Seafood",
    ///                     Address = new Address
    ///                     {
    ///                         AddressLine1 = "505 Electric Ave",
    ///                         AddressLine2 = "Suite 600",
    ///                         Locality = "New York",
    ///                         AdministrativeDistrictLevel1 = "NY",
    ///                         PostalCode = "10003",
    ///                         Country = Country.Us,
    ///                     },
    ///                     Contacts = new List&lt;VendorContact&gt;()
    ///                     {
    ///                         new VendorContact
    ///                         {
    ///                             Name = "Joe Burrow",
    ///                             EmailAddress = "joe@joesfreshseafood.com",
    ///                             PhoneNumber = "1-212-555-4250",
    ///                             Ordinal = 1,
    ///                         },
    ///                     },
    ///                     AccountNumber = "4025391",
    ///                     Note = "a vendor",
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchCreateVendorsResponse> BatchCreateAsync(
        BatchCreateVendorsRequest request,
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
                    Path = "v2/vendors/bulk-create",
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
                return JsonUtils.Deserialize<BatchCreateVendorsResponse>(responseBody)!;
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
    /// Retrieves one or more vendors of specified [Vendor](entity:Vendor) IDs.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.BatchGetAsync(
    ///     new BatchGetVendorsRequest
    ///     {
    ///         VendorIds = new List&lt;string&gt;() { "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4" },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchGetVendorsResponse> BatchGetAsync(
        BatchGetVendorsRequest request,
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
                    Path = "v2/vendors/bulk-retrieve",
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
                return JsonUtils.Deserialize<BatchGetVendorsResponse>(responseBody)!;
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
    /// Updates one or more of existing [Vendor](entity:Vendor) objects as suppliers to a seller.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.BatchUpdateAsync(
    ///     new BatchUpdateVendorsRequest
    ///     {
    ///         Vendors = new Dictionary&lt;string, UpdateVendorRequest&gt;()
    ///         {
    ///             {
    ///                 "FMCYHBWT1TPL8MFH52PBMEN92A",
    ///                 new UpdateVendorRequest { Vendor = new Vendor() }
    ///             },
    ///             {
    ///                 "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
    ///                 new UpdateVendorRequest { Vendor = new Vendor() }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchUpdateVendorsResponse> BatchUpdateAsync(
        BatchUpdateVendorsRequest request,
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
                    Path = "v2/vendors/bulk-update",
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
                return JsonUtils.Deserialize<BatchUpdateVendorsResponse>(responseBody)!;
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
    /// Creates a single [Vendor](entity:Vendor) object to represent a supplier to a seller.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.CreateAsync(
    ///     new CreateVendorRequest
    ///     {
    ///         IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
    ///         Vendor = new Vendor
    ///         {
    ///             Name = "Joe's Fresh Seafood",
    ///             Address = new Address
    ///             {
    ///                 AddressLine1 = "505 Electric Ave",
    ///                 AddressLine2 = "Suite 600",
    ///                 Locality = "New York",
    ///                 AdministrativeDistrictLevel1 = "NY",
    ///                 PostalCode = "10003",
    ///                 Country = Country.Us,
    ///             },
    ///             Contacts = new List&lt;VendorContact&gt;()
    ///             {
    ///                 new VendorContact
    ///                 {
    ///                     Name = "Joe Burrow",
    ///                     EmailAddress = "joe@joesfreshseafood.com",
    ///                     PhoneNumber = "1-212-555-4250",
    ///                     Ordinal = 1,
    ///                 },
    ///             },
    ///             AccountNumber = "4025391",
    ///             Note = "a vendor",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateVendorResponse> CreateAsync(
        CreateVendorRequest request,
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
                    Path = "v2/vendors/create",
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
                return JsonUtils.Deserialize<CreateVendorResponse>(responseBody)!;
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
    /// Searches for vendors using a filter against supported [Vendor](entity:Vendor) properties and a supported sorter.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.SearchAsync(new SearchVendorsRequest());
    /// </code></example>
    public async Task<SearchVendorsResponse> SearchAsync(
        SearchVendorsRequest request,
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
                    Path = "v2/vendors/search",
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
                return JsonUtils.Deserialize<SearchVendorsResponse>(responseBody)!;
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
    /// Retrieves the vendor of a specified [Vendor](entity:Vendor) ID.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.GetAsync(new GetVendorsRequest { VendorId = "vendor_id" });
    /// </code></example>
    public async Task<GetVendorResponse> GetAsync(
        GetVendorsRequest request,
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
                        "v2/vendors/{0}",
                        ValueConvert.ToPathParameterString(request.VendorId)
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
                return JsonUtils.Deserialize<GetVendorResponse>(responseBody)!;
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
    /// Updates an existing [Vendor](entity:Vendor) object as a supplier to a seller.
    /// </summary>
    /// <example><code>
    /// await client.Vendors.UpdateAsync(
    ///     new UpdateVendorsRequest
    ///     {
    ///         VendorId = "vendor_id",
    ///         Body = new UpdateVendorRequest
    ///         {
    ///             IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
    ///             Vendor = new Vendor
    ///             {
    ///                 Id = "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
    ///                 Name = "Jack's Chicken Shack",
    ///                 Version = 1,
    ///                 Status = VendorStatus.Active,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateVendorResponse> UpdateAsync(
        UpdateVendorsRequest request,
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
                        "v2/vendors/{0}",
                        ValueConvert.ToPathParameterString(request.VendorId)
                    ),
                    Body = request.Body,
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
                return JsonUtils.Deserialize<UpdateVendorResponse>(responseBody)!;
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
