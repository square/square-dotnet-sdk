using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A record of a team member's break on a [timecard](entity:Timecard).
/// </summary>
[Serializable]
public record Break : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// RFC 3339; follows the same timezone information as the [timecard](entity:Timecard). Precision up to
    /// the minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("start_at")]
    public required string StartAt { get; set; }

    /// <summary>
    /// RFC 3339; follows the same timezone information as the [timecard](entity:Timecard). Precision up to
    /// the minute is respected; seconds are truncated.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

    /// <summary>
    /// The [BreakType](entity:BreakType) that this break was templated on.
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
    ///
    /// Example for break expected duration of 15 minutes: PT15M
    /// </summary>
    [JsonPropertyName("expected_duration")]
    public required string ExpectedDuration { get; set; }

    /// <summary>
    /// Whether this break counts towards time worked for compensation
    /// purposes.
    /// </summary>
    [JsonPropertyName("is_paid")]
    public required bool IsPaid { get; set; }

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
