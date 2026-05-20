using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A filter based on order `source` information.
/// </summary>
[Serializable]
public record SearchOrdersSourceFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Filters by the [Source](entity:OrderSource) `name`. The filter returns any orders
    /// with a `source.name` that matches any of the listed source names.
    ///
    /// Max: 10 source names.
    /// </summary>
    [JsonPropertyName("source_names")]
    public IEnumerable<string>? SourceNames { get; set; }

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
