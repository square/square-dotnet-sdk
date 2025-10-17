using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [SearchScheduledShifts](api-endpoint:Labor-SearchScheduledShifts) response.
/// Either `scheduled_shifts` or `errors` is present in the response.
/// </summary>
[Serializable]
public record SearchScheduledShiftsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A paginated list of scheduled shifts that match the query conditions.
    /// </summary>
    [JsonPropertyName("scheduled_shifts")]
    public IEnumerable<ScheduledShift>? ScheduledShifts { get; set; }

    /// <summary>
    /// The pagination cursor used to retrieve the next page of results. This field is present
    /// only if additional results are available.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
