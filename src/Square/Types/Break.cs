using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A record of an employee's break during a shift.
/// </summary>
public record Break
{
    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// RFC 3339; follows the same timezone information as `Shift`. Precision up to
    /// the minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("start_at")]
    public required string StartAt { get; set; }

    /// <summary>
    /// RFC 3339; follows the same timezone information as `Shift`. Precision up to
    /// the minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

    /// <summary>
    /// The `BreakType` that this `Break` was templated on.
    /// </summary>
    [JsonPropertyName("break_type_id")]
    public required string BreakTypeId { get; set; }

    /// <summary>
    /// A human-readable name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Format: RFC-3339 P[n]Y[n]M[n]DT[n]H[n]M[n]S. The expected length of
    /// the break.
    /// </summary>
    [JsonPropertyName("expected_duration")]
    public required string ExpectedDuration { get; set; }

    /// <summary>
    /// Whether this break counts towards time worked for compensation
    /// purposes.
    /// </summary>
    [JsonPropertyName("is_paid")]
    public required bool IsPaid { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
