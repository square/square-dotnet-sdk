using Square;
using Square.Core;

namespace Square.Default;

public partial interface IMerchantsClient
{
    public Square.Default.Merchants.CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }
    public Square.Default.Merchants.CustomAttributesClient CustomAttributes { get; }

    /// <summary>
    /// Provides details about the merchant associated with a given access token.
    ///
    /// The access token used to connect your application to a Square seller is associated
    /// with a single merchant. That means that `ListMerchants` returns a list
    /// with a single `Merchant` object. You can specify your personal access token
    /// to get your own merchant information or specify an OAuth token to get the
    /// information for the merchant that granted your application access.
    ///
    /// If you know the merchant ID, you can also use the [RetrieveMerchant](api-endpoint:Merchants-RetrieveMerchant)
    /// endpoint to retrieve the merchant information.
    /// </summary>
    Task<Pager<Merchant>> ListAsync(
        ListMerchantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the `Merchant` object for the given `merchant_id`.
    /// </summary>
    Task<GetMerchantResponse> GetAsync(
        GetMerchantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
