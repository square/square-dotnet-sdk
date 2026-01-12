using Square;
using Square.Default;

namespace Square.Default.Terminal.Refunds;

public partial interface IRefundsClient
{
    /// <summary>
    /// Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API](api:Refunds).
    /// </summary>
    Task<CreateTerminalRefundResponse> CreateAsync(
        CreateTerminalRefundRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
    /// </summary>
    Task<SearchTerminalRefundsResponse> SearchAsync(
        SearchTerminalRefundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
    /// </summary>
    Task<GetTerminalRefundResponse> GetAsync(
        GetRefundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
    /// </summary>
    Task<CancelTerminalRefundResponse> CancelAsync(
        CancelRefundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
