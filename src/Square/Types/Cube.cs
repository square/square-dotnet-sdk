using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record Cube : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public required CubeType Type { get; set; }

    [JsonPropertyName("meta")]
    public Dictionary<string, object?>? Meta { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("measures")]
    public IEnumerable<Measure> Measures { get; set; } = new List<Measure>();

    [JsonPropertyName("dimensions")]
    public IEnumerable<Dimension> Dimensions { get; set; } = new List<Dimension>();

    [JsonPropertyName("segments")]
    public IEnumerable<Segment> Segments { get; set; } = new List<Segment>();

    [JsonPropertyName("joins")]
    public IEnumerable<CubeJoin>? Joins { get; set; }

    [JsonPropertyName("folders")]
    public IEnumerable<Folder>? Folders { get; set; }

    [JsonPropertyName("nestedFolders")]
    public IEnumerable<NestedFolder>? NestedFolders { get; set; }

    [JsonPropertyName("hierarchies")]
    public IEnumerable<Hierarchy>? Hierarchies { get; set; }

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
