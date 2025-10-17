using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines filter criteria for a [SearchScheduledShifts](api-endpoint:Labor-SearchScheduledShifts)
/// request. Multiple filters in a query are combined as an `AND` operation.
/// </summary>
[Serializable]
public record ScheduledShiftFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Return shifts for the specified locations. When omitted, shifts for all
    /// locations are returned. If needed, call [ListLocations](api-endpoint:Locations-ListLocations)
    /// to get location IDs.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// Return shifts whose `start_at` time is within the specified
    /// time range (inclusive).
    /// </summary>
    [JsonPropertyName("start")]
    public TimeRange? Start { get; set; }

    /// <summary>
    /// Return shifts whose `end_at` time is within the specified
    /// time range (inclusive).
    /// </summary>
    [JsonPropertyName("end")]
    public TimeRange? End { get; set; }

    /// <summary>
    /// Return shifts based on a workday date range.
    /// </summary>
    [JsonPropertyName("workday")]
    public ScheduledShiftWorkday? Workday { get; set; }

    /// <summary>
    /// Return shifts assigned to specified team members. If needed, call
    /// [SearchTeamMembers](api-endpoint:Team-SearchTeamMembers) to get team member IDs.
    ///
    /// To return only the shifts assigned to the specified team members, include the
    /// `assignment_status` filter in the query. Otherwise, all unassigned shifts are
    /// returned along with shifts assigned to the specified team members.
    /// </summary>
    [JsonPropertyName("team_member_ids")]
    public IEnumerable<string>? TeamMemberIds { get; set; }

    /// <summary>
    /// Return shifts based on whether a team member is assigned. A shift is
    /// assigned if the `team_member_id` field is populated in the `draft_shift_details`
    /// or `published_shift details` field of the shift.
    ///
    /// To return only draft or published shifts, include the `scheduled_shift_statuses`
    /// filter in the query.
    /// See [ScheduledShiftFilterAssignmentStatus](#type-scheduledshiftfilterassignmentstatus) for possible values
    /// </summary>
    [JsonPropertyName("assignment_status")]
    public ScheduledShiftFilterAssignmentStatus? AssignmentStatus { get; set; }

    /// <summary>
    /// Return shifts based on the draft or published status of the shift.
    /// A shift is published if the `published_shift_details` field is present.
    ///
    /// Note that shifts with `draft_shift_details.is_deleted` set to `true` are ignored
    /// with the `DRAFT` filter.
    /// See [ScheduledShiftFilterScheduledShiftStatus](#type-scheduledshiftfilterscheduledshiftstatus) for possible values
    /// </summary>
    [JsonPropertyName("scheduled_shift_statuses")]
    public IEnumerable<ScheduledShiftFilterScheduledShiftStatus>? ScheduledShiftStatuses { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
