using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.CashDrawers;

public partial interface IShiftsClient
{
    /// <summary>
    /// Provides the details for all of the cash drawer shifts for a location
    /// in a date range.
    /// </summary>
    Task<Pager<CashDrawerShiftSummary>> ListAsync(
        ListShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provides the summary details for a single cash drawer shift. See
    /// [ListCashDrawerShiftEvents](api-endpoint:CashDrawers-ListCashDrawerShiftEvents) for a list of cash drawer shift events.
    /// </summary>
    Task<GetCashDrawerShiftResponse> GetAsync(
        GetShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provides a paginated list of events for a single cash drawer shift.
    /// </summary>
    Task<Pager<CashDrawerShiftEvent>> ListEventsAsync(
        ListEventsShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
