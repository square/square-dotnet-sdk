using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor;

public record CreateScheduledShiftRequest
{
    /// <summary>
    /// A unique identifier for the `CreateScheduledShift` request, used to ensure the
    /// [idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency)
    /// of the operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The scheduled shift with `draft_shift_details`.
    /// If needed, call [ListLocations](api-endpoint:Locations-ListLocations) to get location IDs,
    /// [ListJobs](api-endpoint:Team-ListJobs) to get job IDs, and [SearchTeamMembers](api-endpoint:Team-SearchTeamMembers)
    /// to get team member IDs and current job assignments.
    ///
    /// The `start_at` and `end_at` timestamps must be provided in the time zone + offset of the
    /// shift location specified in `location_id`. Example for Pacific Standard Time: 2024-10-31T12:30:00-08:00
    /// </summary>
    [JsonPropertyName("scheduled_shift")]
    public required ScheduledShift ScheduledShift { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
