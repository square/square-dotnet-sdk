using Square;

namespace Square.Locations.Transactions;

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
}
