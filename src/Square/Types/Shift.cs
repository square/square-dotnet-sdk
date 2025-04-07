using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A record of the hourly rate, start, and end times for a single work shift
/// for an employee. This might include a record of the start and end times for breaks
/// taken during the shift.
/// </summary>
public record Shift
{
    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the employee this shift belongs to. DEPRECATED at version 2020-08-26. Use `team_member_id` instead.
    /// </summary>
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// The ID of the location this shift occurred at. The location should be based on
    /// where the employee clocked in.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The read-only convenience value that is calculated from the location based
    /// on the `location_id`. Format: the IANA timezone database identifier for the
    /// location timezone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// RFC 3339; shifted to the location timezone + offset. Precision up to the
    /// minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("start_at")]
    public required string StartAt { get; set; }

    /// <summary>
    /// RFC 3339; shifted to the timezone + offset. Precision up to the minute is
    /// respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

    /// <summary>
    /// Job and pay related information. If the wage is not set on create, it defaults to a wage
    /// of zero. If the title is not set on create, it defaults to the name of the role the employee
    /// is assigned to, if any.
    /// </summary>
    [JsonPropertyName("wage")]
    public ShiftWage? Wage { get; set; }

    /// <summary>
    /// A list of all the paid or unpaid breaks that were taken during this shift.
    /// </summary>
    [JsonPropertyName("breaks")]
    public IEnumerable<Break>? Breaks { get; set; }

    /// <summary>
    /// Describes the working state of the current `Shift`.
    /// See [ShiftStatus](#type-shiftstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public ShiftStatus? Status { get; set; }

    /// <summary>
    /// Used for resolving concurrency issues. The request fails if the version
    /// provided does not match the server version at the time of the request. If not provided,
    /// Square executes a blind write; potentially overwriting data from another
    /// write.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format; presented in UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format; presented in UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the team member this shift belongs to. Replaced `employee_id` at version "2020-08-26".
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The tips declared by the team member for the shift.
    /// </summary>
    [JsonPropertyName("declared_cash_tip_money")]
    public Money? DeclaredCashTipMoney { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
