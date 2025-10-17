using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A record of the hourly rate, start time, and end time of a single timecard (shift)
/// for a team member. This might include a record of the start and end times of breaks
/// taken during the shift.
/// </summary>
[Serializable]
public record Timecard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// **Read only** The Square-issued UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the [location](entity:Location) for this timecard. The location should be based on
    /// where the team member clocked in.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// **Read only** The time zone calculated from the location based on the `location_id`,
    /// provided as a convenience value. Format: the IANA time zone database identifier for the
    /// location time zone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// The start time of the timecard, in RFC 3339 format and shifted to the location
    /// timezone + offset. Precision up to the minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("start_at")]
    public required string StartAt { get; set; }

    /// <summary>
    /// The end time of the timecard, in RFC 3339 format and shifted to the location
    /// timezone + offset. Precision up to the minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

    /// <summary>
    /// Job and pay related information. If the wage is not set on create, it defaults to a wage
    /// of zero. If the title is not set on create, it defaults to the name of the role the team member
    /// is assigned to, if any.
    /// </summary>
    [JsonPropertyName("wage")]
    public TimecardWage? Wage { get; set; }

    /// <summary>
    /// A list of all the paid or unpaid breaks that were taken during this timecard.
    /// </summary>
    [JsonPropertyName("breaks")]
    public IEnumerable<Break>? Breaks { get; set; }

    /// <summary>
    /// Describes the working state of the timecard.
    /// See [TimecardStatus](#type-timecardstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TimecardStatus? Status { get; set; }

    /// <summary>
    /// **Read only** The current version of the timecard, which is incremented with each update.
    /// This field is used for [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control to ensure that requests don't overwrite data from another request.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The timestamp of when the timecard was created, in RFC 3339 format presented as UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the timecard was last updated, in RFC 3339 format presented as UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the [team member](entity:TeamMember) this timecard belongs to.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public required string TeamMemberId { get; set; }

    /// <summary>
    /// The cash tips declared by the team member for this timecard.
    /// </summary>
    [JsonPropertyName("declared_cash_tip_money")]
    public Money? DeclaredCashTipMoney { get; set; }

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
