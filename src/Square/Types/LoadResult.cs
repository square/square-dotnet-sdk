using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using Square.Core;

namespace Square;

[Serializable]
public record LoadResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dataSource")]
    public string? DataSource { get; set; }

    [JsonPropertyName("annotation")]
    public required LoadResultAnnotation Annotation { get; set; }

    [JsonPropertyName("data")]
    public required OneOf<
        IEnumerable<Dictionary<string, object?>>,
        LoadResultDataCompact,
        LoadResultDataColumnar
    > Data { get; set; }

    [JsonPropertyName("refreshKeyValues")]
    public IEnumerable<Dictionary<string, object?>>? RefreshKeyValues { get; set; }

    [JsonPropertyName("lastRefreshTime")]
    public string? LastRefreshTime { get; set; }

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
