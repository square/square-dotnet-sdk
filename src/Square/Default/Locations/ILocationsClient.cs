using Square;
using Square.Default;
using Square.Default.Locations.Transactions;

namespace Square.Default.Locations;

public partial interface ILocationsClient
{
    public Square.Default.Locations.CustomAttributeDefinitions.CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }
    public Square.Default.Locations.CustomAttributes.CustomAttributesClient CustomAttributes { get; }
    public TransactionsClient Transactions { get; }

    /// <summary>
    /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),
    /// including those with an inactive status. Locations are listed alphabetically by `name`.
    /// </summary>
    Task<ListLocationsResponse> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a [location](https://developer.squareup.com/docs/locations-api).
    /// Creating new locations allows for separate configuration of receipt layouts, item prices,
    /// and sales reports. Developers can use locations to separate sales activity through applications
    /// that integrate with Square from sales activity elsewhere in a seller's account.
    /// Locations created programmatically with the Locations API last forever and
    /// are visible to the seller for their own management. Therefore, ensure that
    /// each location has a sensible and unique name.
    /// </summary>
    Task<CreateLocationResponse> CreateAsync(
        CreateLocationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details of a single location. Specify "main"
    /// as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
    /// </summary>
    Task<GetLocationResponse> GetAsync(
        GetLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a [location](https://developer.squareup.com/docs/locations-api).
    /// </summary>
    Task<UpdateLocationResponse> UpdateAsync(
        UpdateLocationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Links a `checkoutId` to a `checkout_page_url` that customers are
    /// directed to in order to provide their payment information using a
    /// payment processing workflow hosted on connect.squareup.com.
    ///
    ///
    /// NOTE: The Checkout API has been updated with new features.
    /// For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
    /// </summary>
    Task<CreateCheckoutResponse> CheckoutsAsync(
        CreateCheckoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
