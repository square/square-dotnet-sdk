using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents shift details for draft and published versions of a [scheduled shift](entity:ScheduledShift),
/// such as job ID, team member assignment, and start and end times.
/// </summary>
[Serializable]
public record ScheduledShiftDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the [team member](entity:TeamMember) scheduled for the shift.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The ID of the [location](entity:Location) the shift is scheduled for.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the [job](entity:Job) the shift is scheduled for.
    /// </summary>
    [JsonPropertyName("job_id")]
    public string? JobId { get; set; }

    /// <summary>
    /// The start time of the shift, in RFC 3339 format in the time zone &plus;
    /// offset of the shift location specified in `location_id`. Precision up to the minute
    /// is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("start_at")]
    public string? StartAt { get; set; }

    /// <summary>
    /// The end time for the shift, in RFC 3339 format in the time zone &plus;
    /// offset of the shift location specified in `location_id`. Precision up to the minute
    /// is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

    /// <summary>
    /// Optional notes for the shift.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// Indicates whether the draft shift version is deleted. If set to `true` when the shift
    /// is published, the entire scheduled shift (including the published shift) is deleted and
    /// cannot be accessed using any endpoint.
    /// </summary>
    [JsonPropertyName("is_deleted")]
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// The time zone of the shift location, calculated based on the `location_id`. This field
    /// is provided for convenience.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

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
