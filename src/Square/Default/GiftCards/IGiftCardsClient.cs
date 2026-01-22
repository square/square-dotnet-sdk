using Square;
using Square.Core;
using Square.Default.GiftCards;

namespace Square.Default;

public partial interface IGiftCardsClient
{
    public ActivitiesClient Activities { get; }

    /// <summary>
    /// Lists all gift cards. You can specify optional filters to retrieve
    /// a subset of the gift cards. Results are sorted by `created_at` in ascending order.
    /// </summary>
    Task<Pager<GiftCard>> ListAsync(
        ListGiftCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a digital gift card or registers a physical (plastic) gift card. The resulting gift card
    /// has a `PENDING` state. To activate a gift card so that it can be redeemed for purchases, call
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) and create an `ACTIVATE`
    /// activity with the initial balance. Alternatively, you can use [RefundPayment](api-endpoint:Refunds-RefundPayment)
    /// to refund a payment to the new gift card.
    /// </summary>
    Task<CreateGiftCardResponse> CreateAsync(
        CreateGiftCardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a gift card using the gift card account number (GAN).
    /// </summary>
    Task<GetGiftCardFromGanResponse> GetFromGanAsync(
        GetGiftCardFromGanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a gift card using a secure payment token that represents the gift card.
    /// </summary>
    Task<GetGiftCardFromNonceResponse> GetFromNonceAsync(
        GetGiftCardFromNonceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Links a customer to a gift card, which is also referred to as adding a card on file.
    /// </summary>
    Task<LinkCustomerToGiftCardResponse> LinkCustomerAsync(
        LinkCustomerToGiftCardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unlinks a customer from a gift card, which is also referred to as removing a card on file.
    /// </summary>
    Task<UnlinkCustomerFromGiftCardResponse> UnlinkCustomerAsync(
        UnlinkCustomerFromGiftCardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a gift card using the gift card ID.
    /// </summary>
    Task<GetGiftCardResponse> GetAsync(
        GetGiftCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
