using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Cards;

public partial interface ICardsClient
{
    /// <summary>
    /// Retrieves a list of cards owned by the account making the request.
    /// A max of 25 cards will be returned.
    /// </summary>
    Task<Pager<Card>> ListAsync(
        ListCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a card on file to an existing merchant.
    /// </summary>
    Task<CreateCardResponse> CreateAsync(
        CreateCardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details for a specific Card.
    /// </summary>
    Task<GetCardResponse> GetAsync(
        GetCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disables the card, preventing any further updates or charges.
    /// Disabling an already disabled card is allowed but has no effect.
    /// </summary>
    Task<DisableCardResponse> DisableAsync(
        DisableCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
