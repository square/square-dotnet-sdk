using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.GiftCards.Activities;

public partial interface IActivitiesClient
{
    /// <summary>
    /// Lists gift card activities. By default, you get gift card activities for all
    /// gift cards in the seller's account. You can optionally specify query parameters to
    /// filter the list. For example, you can get a list of gift card activities for a gift card,
    /// for all gift cards in a specific region, or for activities within a time window.
    /// </summary>
    Task<Pager<GiftCardActivity>> ListAsync(
        ListActivitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a gift card activity to manage the balance or state of a [gift card](entity:GiftCard).
    /// For example, create an `ACTIVATE` activity to activate a gift card with an initial balance before first use.
    /// </summary>
    Task<CreateGiftCardActivityResponse> CreateAsync(
        CreateGiftCardActivityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
