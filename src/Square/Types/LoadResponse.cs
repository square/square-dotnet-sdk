using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record LoadResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("pivotQuery")]
    public Dictionary<string, object?>? PivotQuery { get; set; }

    [JsonPropertyName("slowQuery")]
    public bool? SlowQuery { get; set; }

    [JsonPropertyName("queryType")]
    public string? QueryType { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<LoadResult> Results { get; set; } = new List<LoadResult>();

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
