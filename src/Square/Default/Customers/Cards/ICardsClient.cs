using Square;
using Square.Default;

namespace Square.Default.Customers.Cards;

public partial interface ICardsClient
{
    /// <summary>
    /// Adds a card on file to an existing customer.
    ///
    /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
    /// calls with the same card nonce return the same card record that was created
    /// with the provided nonce during the _first_ call.
    /// </summary>
    Task<CreateCustomerCardResponse> CreateAsync(
        CreateCustomerCardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a card on file from a customer.
    /// </summary>
    Task<DeleteCustomerCardResponse> DeleteAsync(
        DeleteCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
