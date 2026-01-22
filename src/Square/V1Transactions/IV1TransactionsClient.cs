using Square;

namespace Square.V1Transactions;

public partial interface IV1TransactionsClient
{
    /// <summary>
    /// Provides summary information for a merchant's online store orders.
    /// </summary>
    Task<IEnumerable<V1Order>> V1ListOrdersAsync(
        V1ListOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provides comprehensive information for a single online store order, including the order's history.
    /// </summary>
    Task<V1Order> V1RetrieveOrderAsync(
        V1RetrieveOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:
    /// </summary>
    Task<V1Order> V1UpdateOrderAsync(
        V1UpdateOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
