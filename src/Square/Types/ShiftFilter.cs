using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines a filter used in a search for `Shift` records. `AND` logic is
/// used by Square's servers to apply each filter property specified.
///
/// Deprecated at Square API version 2025-05-21. See the [migration notes](https://developer.squareup.com/docs/labor-api/what-it-does#migration-notes).
/// </summary>
[Serializable]
public record ShiftFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Fetch shifts for the specified location.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// Fetch shifts for the specified employees. DEPRECATED at version 2020-08-26. Use `team_member_ids` instead.
    /// </summary>
    [JsonPropertyName("employee_ids")]
    public IEnumerable<string>? EmployeeIds { get; set; }

    /// <summary>
    /// Fetch a `Shift` instance by `Shift.status`.
    /// See [ShiftFilterStatus](#type-shiftfilterstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public ShiftFilterStatus? Status { get; set; }

    /// <summary>
    /// Fetch `Shift` instances that start in the time range - Inclusive.
    /// </summary>
    [JsonPropertyName("start")]
    public TimeRange? Start { get; set; }

    /// <summary>
    /// Fetch the `Shift` instances that end in the time range - Inclusive.
    /// </summary>
    [JsonPropertyName("end")]
    public TimeRange? End { get; set; }

    /// <summary>
    /// Fetch the `Shift` instances based on the workday date range.
    /// </summary>
    [JsonPropertyName("workday")]
    public ShiftWorkday? Workday { get; set; }

    /// <summary>
    /// Fetch shifts for the specified team members. Replaced `employee_ids` at version "2020-08-26".
    /// </summary>
    [JsonPropertyName("team_member_ids")]
    public IEnumerable<string>? TeamMemberIds { get; set; }

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
