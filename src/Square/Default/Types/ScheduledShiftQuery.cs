using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents filter and sort criteria for the `query` field in a
/// [SearchScheduledShifts](api-endpoint:Labor-SearchScheduledShifts) request.
/// </summary>
[Serializable]
public record ScheduledShiftQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Filtering options for the query.
    /// </summary>
    [JsonPropertyName("filter")]
    public ScheduledShiftFilter? Filter { get; set; }

    /// <summary>
    /// Sorting options for the query.
    /// </summary>
    [JsonPropertyName("sort")]
    public ScheduledShiftSort? Sort { get; set; }

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
