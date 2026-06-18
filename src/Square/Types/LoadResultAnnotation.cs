using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record LoadResultAnnotation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("measures")]
    public Dictionary<string, object?> Measures { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("dimensions")]
    public Dictionary<string, object?> Dimensions { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("segments")]
    public Dictionary<string, object?> Segments { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("timeDimensions")]
    public Dictionary<string, object?> TimeDimensions { get; set; } =
        new Dictionary<string, object?>();

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
