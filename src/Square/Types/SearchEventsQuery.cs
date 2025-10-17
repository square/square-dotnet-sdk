using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains query criteria for the search.
/// </summary>
[Serializable]
public record SearchEventsQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Criteria to filter events by.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchEventsFilter? Filter { get; set; }

    /// <summary>
    /// Criteria to sort events by.
    /// </summary>
    [JsonPropertyName("sort")]
    public SearchEventsSort? Sort { get; set; }

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
