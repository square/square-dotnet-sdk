using Square;
using Square.Default;

namespace Square.Default.Labor.Shifts;

public partial interface IShiftsClient
{
    /// <summary>
    /// Creates a new `Shift`.
    ///
    /// A `Shift` represents a complete workday for a single team member.
    /// You must provide the following values in your request to this
    /// endpoint:
    ///
    /// - `location_id`
    /// - `team_member_id`
    /// - `start_at`
    ///
    /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
    /// - The `status` of the new `Shift` is `OPEN` and the team member has another
    /// shift with an `OPEN` status.
    /// - The `start_at` date is in the future.
    /// - The `start_at` or `end_at` date overlaps another shift for the same team member.
    /// - The `Break` instances are set in the request and a break `start_at`
    /// is before the `Shift.start_at`, a break `end_at` is after
    /// the `Shift.end_at`, or both.
    /// </summary>
    Task<CreateShiftResponse> CreateAsync(
        CreateShiftRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of `Shift` records for a business.
    /// The list to be returned can be filtered by:
    /// - Location IDs
    /// - Team member IDs
    /// - Shift status (`OPEN` or `CLOSED`)
    /// - Shift start
    /// - Shift end
    /// - Workday details
    ///
    /// The list can be sorted by:
    /// - `START_AT`
    /// - `END_AT`
    /// - `CREATED_AT`
    /// - `UPDATED_AT`
    /// </summary>
    Task<SearchShiftsResponse> SearchAsync(
        SearchShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single `Shift` specified by `id`.
    /// </summary>
    Task<GetShiftResponse> GetAsync(
        GetShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing `Shift`.
    ///
    /// When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have
    /// the `end_at` property set to a valid RFC-3339 datetime string.
    ///
    /// When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`
    /// set on each `Break`.
    /// </summary>
    Task<UpdateShiftResponse> UpdateAsync(
        UpdateShiftRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a `Shift`.
    /// </summary>
    Task<DeleteShiftResponse> DeleteAsync(
        DeleteShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
