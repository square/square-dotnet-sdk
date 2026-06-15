using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record TimeDimension : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dimension")]
    public required string Dimension { get; set; }

    [JsonPropertyName("granularity")]
    public string? Granularity { get; set; }

    [JsonPropertyName("dateRange")]
    public Dictionary<string, object?>? DateRange { get; set; }

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
