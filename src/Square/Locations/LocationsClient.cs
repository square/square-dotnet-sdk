using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;
using Square.Locations.CustomAttributeDefinitions;
using Square.Locations.CustomAttributes;
using Square.Locations.Transactions;

namespace Square.Locations;

public partial class LocationsClient
{
    private RawClient _client;

    internal LocationsClient(RawClient client)
    {
        _client = client;
        CustomAttributeDefinitions = new CustomAttributeDefinitionsClient(_client);
        CustomAttributes = new CustomAttributesClient(_client);
        Transactions = new TransactionsClient(_client);
    }

    public CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }

    public CustomAttributesClient CustomAttributes { get; }

    public TransactionsClient Transactions { get; }

    /// <summary>
    /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),
    /// including those with an inactive status. Locations are listed alphabetically by `name`.
    /// </summary>
    /// <example><code>
    /// await client.Locations.ListAsync();
    /// </code></example>
    public async Task<ListLocationsResponse> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/locations",
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
                return JsonUtils.Deserialize<ListLocationsResponse>(responseBody)!;
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
    /// Creates a [location](https://developer.squareup.com/docs/locations-api).
    /// Creating new locations allows for separate configuration of receipt layouts, item prices,
    /// and sales reports. Developers can use locations to separate sales activity through applications
    /// that integrate with Square from sales activity elsewhere in a seller's account.
    /// Locations created programmatically with the Locations API last forever and
    /// are visible to the seller for their own management. Therefore, ensure that
    /// each location has a sensible and unique name.
    /// </summary>
    /// <example><code>
    /// await client.Locations.CreateAsync(
    ///     new CreateLocationRequest
    ///     {
    ///         Location = new Location
    ///         {
    ///             Name = "Midtown",
    ///             Address = new Address
    ///             {
    ///                 AddressLine1 = "1234 Peachtree St. NE",
    ///                 Locality = "Atlanta",
    ///                 AdministrativeDistrictLevel1 = "GA",
    ///                 PostalCode = "30309",
    ///             },
    ///             Description = "Midtown Atlanta store",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateLocationResponse> CreateAsync(
        CreateLocationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/locations",
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
                return JsonUtils.Deserialize<CreateLocationResponse>(responseBody)!;
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
    /// Retrieves details of a single location. Specify "main"
    /// as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
    /// </summary>
    /// <example><code>
    /// await client.Locations.GetAsync(new GetLocationsRequest { LocationId = "location_id" });
    /// </code></example>
    public async Task<GetLocationResponse> GetAsync(
        GetLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/locations/{0}",
                        ValueConvert.ToPathParameterString(request.LocationId)
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
                return JsonUtils.Deserialize<GetLocationResponse>(responseBody)!;
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
    /// Updates a [location](https://developer.squareup.com/docs/locations-api).
    /// </summary>
    /// <example><code>
    /// await client.Locations.UpdateAsync(
    ///     new UpdateLocationRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Location = new Location
    ///         {
    ///             BusinessHours = new BusinessHours
    ///             {
    ///                 Periods = new List&lt;BusinessHoursPeriod&gt;()
    ///                 {
    ///                     new BusinessHoursPeriod
    ///                     {
    ///                         DayOfWeek = DayOfWeek.Fri,
    ///                         StartLocalTime = "07:00",
    ///                         EndLocalTime = "18:00",
    ///                     },
    ///                     new BusinessHoursPeriod
    ///                     {
    ///                         DayOfWeek = DayOfWeek.Sat,
    ///                         StartLocalTime = "07:00",
    ///                         EndLocalTime = "18:00",
    ///                     },
    ///                     new BusinessHoursPeriod
    ///                     {
    ///                         DayOfWeek = DayOfWeek.Sun,
    ///                         StartLocalTime = "09:00",
    ///                         EndLocalTime = "15:00",
    ///                     },
    ///                 },
    ///             },
    ///             Description = "Midtown Atlanta store - Open weekends",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateLocationResponse> UpdateAsync(
        UpdateLocationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/locations/{0}",
                        ValueConvert.ToPathParameterString(request.LocationId)
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
                return JsonUtils.Deserialize<UpdateLocationResponse>(responseBody)!;
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
    /// Links a `checkoutId` to a `checkout_page_url` that customers are
    /// directed to in order to provide their payment information using a
    /// payment processing workflow hosted on connect.squareup.com.
    ///
    ///
    /// NOTE: The Checkout API has been updated with new features.
    /// For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
    /// </summary>
    /// <example><code>
    /// await client.Locations.CheckoutsAsync(
    ///     new CreateCheckoutRequest
    ///     {
    ///         LocationId = "location_id",
    ///         IdempotencyKey = "86ae1696-b1e3-4328-af6d-f1e04d947ad6",
    ///         Order = new CreateOrderRequest
    ///         {
    ///             Order = new Order
    ///             {
    ///                 LocationId = "location_id",
    ///                 ReferenceId = "reference_id",
    ///                 CustomerId = "customer_id",
    ///                 LineItems = new List&lt;OrderLineItem&gt;()
    ///                 {
    ///                     new OrderLineItem
    ///                     {
    ///                         Name = "Printed T Shirt",
    ///                         Quantity = "2",
    ///                         AppliedTaxes = new List&lt;OrderLineItemAppliedTax&gt;()
    ///                         {
    ///                             new OrderLineItemAppliedTax
    ///                             {
    ///                                 TaxUid = "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
    ///                             },
    ///                         },
    ///                         AppliedDiscounts = new List&lt;OrderLineItemAppliedDiscount&gt;()
    ///                         {
    ///                             new OrderLineItemAppliedDiscount
    ///                             {
    ///                                 DiscountUid = "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
    ///                             },
    ///                         },
    ///                         BasePriceMoney = new Money { Amount = 1500, Currency = Currency.Usd },
    ///                     },
    ///                     new OrderLineItem
    ///                     {
    ///                         Name = "Slim Jeans",
    ///                         Quantity = "1",
    ///                         BasePriceMoney = new Money { Amount = 2500, Currency = Currency.Usd },
    ///                     },
    ///                     new OrderLineItem
    ///                     {
    ///                         Name = "Woven Sweater",
    ///                         Quantity = "3",
    ///                         BasePriceMoney = new Money { Amount = 3500, Currency = Currency.Usd },
    ///                     },
    ///                 },
    ///                 Taxes = new List&lt;OrderLineItemTax&gt;()
    ///                 {
    ///                     new OrderLineItemTax
    ///                     {
    ///                         Uid = "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
    ///                         Type = OrderLineItemTaxType.Inclusive,
    ///                         Percentage = "7.75",
    ///                         Scope = OrderLineItemTaxScope.LineItem,
    ///                     },
    ///                 },
    ///                 Discounts = new List&lt;OrderLineItemDiscount&gt;()
    ///                 {
    ///                     new OrderLineItemDiscount
    ///                     {
    ///                         Uid = "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
    ///                         Type = OrderLineItemDiscountType.FixedAmount,
    ///                         AmountMoney = new Money { Amount = 100, Currency = Currency.Usd },
    ///                         Scope = OrderLineItemDiscountScope.LineItem,
    ///                     },
    ///                 },
    ///             },
    ///             IdempotencyKey = "12ae1696-z1e3-4328-af6d-f1e04d947gd4",
    ///         },
    ///         AskForShippingAddress = true,
    ///         MerchantSupportEmail = "merchant+support@website.com",
    ///         PrePopulateBuyerEmail = "example@email.com",
    ///         PrePopulateShippingAddress = new Address
    ///         {
    ///             AddressLine1 = "1455 Market St.",
    ///             AddressLine2 = "Suite 600",
    ///             Locality = "San Francisco",
    ///             AdministrativeDistrictLevel1 = "CA",
    ///             PostalCode = "94103",
    ///             Country = Country.Us,
    ///             FirstName = "Jane",
    ///             LastName = "Doe",
    ///         },
    ///         RedirectUrl = "https://merchant.website.com/order-confirm",
    ///         AdditionalRecipients = new List&lt;ChargeRequestAdditionalRecipient&gt;()
    ///         {
    ///             new ChargeRequestAdditionalRecipient
    ///             {
    ///                 LocationId = "057P5VYJ4A5X1",
    ///                 Description = "Application fees",
    ///                 AmountMoney = new Money { Amount = 60, Currency = Currency.Usd },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateCheckoutResponse> CheckoutsAsync(
        CreateCheckoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "v2/locations/{0}/checkouts",
                        ValueConvert.ToPathParameterString(request.LocationId)
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
                return JsonUtils.Deserialize<CreateCheckoutResponse>(responseBody)!;
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
