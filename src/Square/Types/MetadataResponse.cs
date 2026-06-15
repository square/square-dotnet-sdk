using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record MetadataResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("cubes")]
    public IEnumerable<Cube>? Cubes { get; set; }

    [JsonPropertyName("compilerId")]
    public string? CompilerId { get; set; }

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
