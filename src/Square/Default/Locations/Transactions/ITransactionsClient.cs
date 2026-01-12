using Square;
using Square.Default;

namespace Square.Default.Locations.Transactions;

public partial interface ITransactionsClient
{
    /// <summary>
    /// Lists transactions for a particular location.
    ///
    /// Transactions include payment information from sales and exchanges and refund
    /// information from returns and exchanges.
    ///
    /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50
    /// </summary>
    Task<ListTransactionsResponse> ListAsync(
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details for a single transaction.
    /// </summary>
    Task<GetTransactionResponse> GetAsync(
        GetTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Captures a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
    /// endpoint with a `delay_capture` value of `true`.
    ///
    ///
    /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
    /// for more information.
    /// </summary>
    Task<CaptureTransactionResponse> CaptureAsync(
        CaptureTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
    /// endpoint with a `delay_capture` value of `true`.
    ///
    ///
    /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
    /// for more information.
    /// </summary>
    Task<VoidTransactionResponse> VoidAsync(
        VoidTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
