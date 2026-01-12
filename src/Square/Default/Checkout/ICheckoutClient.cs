using Square;
using Square.Default;
using Square.Default.Checkout.PaymentLinks;

namespace Square.Default.Checkout;

public partial interface ICheckoutClient
{
    public PaymentLinksClient PaymentLinks { get; }

    /// <summary>
    /// Retrieves the location-level settings for a Square-hosted checkout page.
    /// </summary>
    Task<RetrieveLocationSettingsResponse> RetrieveLocationSettingsAsync(
        RetrieveLocationSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the location-level settings for a Square-hosted checkout page.
    /// </summary>
    Task<UpdateLocationSettingsResponse> UpdateLocationSettingsAsync(
        UpdateLocationSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the merchant-level settings for a Square-hosted checkout page.
    /// </summary>
    Task<RetrieveMerchantSettingsResponse> RetrieveMerchantSettingsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the merchant-level settings for a Square-hosted checkout page.
    /// </summary>
    Task<UpdateMerchantSettingsResponse> UpdateMerchantSettingsAsync(
        UpdateMerchantSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
