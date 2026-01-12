using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Payouts;

public partial interface IPayoutsClient
{
    /// <summary>
    /// Retrieves a list of all payouts for the default location.
    /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    Task<Pager<Payout>> ListAsync(
        ListPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details of a specific payout identified by a payout ID.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    Task<GetPayoutResponse> GetAsync(
        GetPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of all payout entries for a specific payout.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    Task<Pager<PayoutEntry>> ListEntriesAsync(
        ListEntriesPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
