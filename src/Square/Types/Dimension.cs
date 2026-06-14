using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using Square.Core;

namespace Square;

[Serializable]
public record Dimension : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("shortTitle")]
    public string? ShortTitle { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// When dimension is defined in View, it keeps the original path: Cube.dimension
    /// </summary>
    [JsonPropertyName("aliasMember")]
    public string? AliasMember { get; set; }

    [JsonPropertyName("granularities")]
    public IEnumerable<DimensionGranularity>? Granularities { get; set; }

    [JsonPropertyName("meta")]
    public Dictionary<string, object?>? Meta { get; set; }

    [JsonPropertyName("format")]
    public OneOf<
        SimpleFormat,
        LinkFormat,
        CustomTimeFormat,
        CustomNumericFormat
    >? Format { get; set; }

    [JsonPropertyName("formatDescription")]
    public FormatDescription? FormatDescription { get; set; }

    /// <summary>
    /// ISO 4217 currency code in uppercase (3 characters, e.g. USD, EUR)
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("order")]
    public DimensionOrder? Order { get; set; }

    /// <summary>
    /// Key reference for the dimension
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

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
