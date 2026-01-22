using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record UpdateScheduledShiftRequest
{
    /// <summary>
    /// The ID of the scheduled shift to update.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The scheduled shift with any updates in the `draft_shift_details` field.
    /// If needed, call [ListLocations](api-endpoint:Locations-ListLocations) to get location IDs,
    /// [ListJobs](api-endpoint:Team-ListJobs) to get job IDs, and [SearchTeamMembers](api-endpoint:Team-SearchTeamMembers)
    /// to get team member IDs and current job assignments. Updates made to `published_shift_details`
    /// are ignored.
    ///
    /// If provided, the `start_at` and `end_at` timestamps must be in the time zone + offset of the
    /// shift location specified in `location_id`. Example for Pacific Standard Time: 2024-10-31T12:30:00-08:00
    ///
    /// To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control for the request, provide the current version of the shift in the `version` field.
    /// If the provided version doesn't match the server version, the request fails. If `version` is
    /// omitted, Square executes a blind write, potentially overwriting data from another publish request.
    /// </summary>
    [JsonPropertyName("scheduled_shift")]
    public required ScheduledShift ScheduledShift { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
