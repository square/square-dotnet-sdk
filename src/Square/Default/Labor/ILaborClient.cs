using Square;
using Square.Default.Labor;

namespace Square.Default;

public partial interface ILaborClient
{
    public BreakTypesClient BreakTypes { get; }
    public EmployeeWagesClient EmployeeWages { get; }
    public Square.Default.Labor.ShiftsClient Shifts { get; }
    public TeamMemberWagesClient TeamMemberWages { get; }
    public WorkweekConfigsClient WorkweekConfigs { get; }

    /// <summary>
    /// Creates a scheduled shift by providing draft shift details such as job ID,
    /// team member assignment, and start and end times.
    ///
    /// The following `draft_shift_details` fields are required:
    /// - `location_id`
    /// - `job_id`
    /// - `start_at`
    /// - `end_at`
    /// </summary>
    Task<CreateScheduledShiftResponse> CreateScheduledShiftAsync(
        CreateScheduledShiftRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes 1 - 100 scheduled shifts. This endpoint takes a map of individual publish
    /// requests and returns a map of responses. When a scheduled shift is published, Square keeps
    /// the `draft_shift_details` field as is and copies it to the `published_shift_details` field.
    ///
    /// The minimum `start_at` and maximum `end_at` timestamps of all shifts in a
    /// `BulkPublishScheduledShifts` request must fall within a two-week period.
    /// </summary>
    Task<BulkPublishScheduledShiftsResponse> BulkPublishScheduledShiftsAsync(
        BulkPublishScheduledShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of scheduled shifts, with optional filter and sort settings.
    /// By default, results are sorted by `start_at` in ascending order.
    /// </summary>
    Task<SearchScheduledShiftsResponse> SearchScheduledShiftsAsync(
        SearchScheduledShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a scheduled shift by ID.
    /// </summary>
    Task<RetrieveScheduledShiftResponse> RetrieveScheduledShiftAsync(
        RetrieveScheduledShiftRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the draft shift details for a scheduled shift. This endpoint supports
    /// sparse updates, so only new, changed, or removed fields are required in the request.
    /// You must publish the shift to make updates public.
    ///
    /// You can make the following updates to `draft_shift_details`:
    /// - Change the `location_id`, `job_id`, `start_at`, and `end_at` fields.
    /// - Add, change, or clear the `team_member_id` and `notes` fields. To clear these fields,
    /// set the value to null.
    /// - Change the `is_deleted` field. To delete a scheduled shift, set `is_deleted` to true
    /// and then publish the shift.
    /// </summary>
    Task<UpdateScheduledShiftResponse> UpdateScheduledShiftAsync(
        UpdateScheduledShiftRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes a scheduled shift. When a scheduled shift is published, Square keeps the
    /// `draft_shift_details` field as is and copies it to the `published_shift_details` field.
    /// </summary>
    Task<PublishScheduledShiftResponse> PublishScheduledShiftAsync(
        PublishScheduledShiftRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new `Timecard`.
    ///
    /// A `Timecard` represents a complete workday for a single team member.
    /// You must provide the following values in your request to this
    /// endpoint:
    ///
    /// - `location_id`
    /// - `team_member_id`
    /// - `start_at`
    ///
    /// An attempt to create a new `Timecard` can result in a `BAD_REQUEST` error when:
    /// - The `status` of the new `Timecard` is `OPEN` and the team member has another
    /// timecard with an `OPEN` status.
    /// - The `start_at` date is in the future.
    /// - The `start_at` or `end_at` date overlaps another timecard for the same team member.
    /// - The `Break` instances are set in the request and a break `start_at`
    /// is before the `Timecard.start_at`, a break `end_at` is after
    /// the `Timecard.end_at`, or both.
    /// </summary>
    Task<CreateTimecardResponse> CreateTimecardAsync(
        CreateTimecardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of `Timecard` records for a business.
    /// The list to be returned can be filtered by:
    /// - Location IDs
    /// - Team member IDs
    /// - Timecard status (`OPEN` or `CLOSED`)
    /// - Timecard start
    /// - Timecard end
    /// - Workday details
    ///
    /// The list can be sorted by:
    /// - `START_AT`
    /// - `END_AT`
    /// - `CREATED_AT`
    /// - `UPDATED_AT`
    /// </summary>
    Task<SearchTimecardsResponse> SearchTimecardsAsync(
        SearchTimecardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single `Timecard` specified by `id`.
    /// </summary>
    Task<RetrieveTimecardResponse> RetrieveTimecardAsync(
        RetrieveTimecardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing `Timecard`.
    ///
    /// When adding a `Break` to a `Timecard`, any earlier `Break` instances in the `Timecard` have
    /// the `end_at` property set to a valid RFC-3339 datetime string.
    ///
    /// When closing a `Timecard`, all `Break` instances in the `Timecard` must be complete with `end_at`
    /// set on each `Break`.
    /// </summary>
    Task<UpdateTimecardResponse> UpdateTimecardAsync(
        UpdateTimecardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a `Timecard`.
    /// </summary>
    Task<DeleteTimecardResponse> DeleteTimecardAsync(
        DeleteTimecardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
