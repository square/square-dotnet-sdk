using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Contains query criteria for the search.
/// </summary>
[Serializable]
public record SearchOrdersQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Criteria to filter results by.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchOrdersFilter? Filter { get; set; }

    /// <summary>
    /// Criteria to sort results by.
    /// </summary>
    [JsonPropertyName("sort")]
    public SearchOrdersSort? Sort { get; set; }

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
