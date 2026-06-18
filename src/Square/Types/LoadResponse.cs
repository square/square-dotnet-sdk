using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using Square.Core;

namespace Square;

[Serializable]
public record LoadResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dataSource")]
    public string? DataSource { get; set; }

    [JsonPropertyName("annotation")]
    public LoadResultAnnotation? Annotation { get; set; }

    [JsonPropertyName("data")]
    public OneOf<
        IEnumerable<Dictionary<string, object?>>,
        LoadResultDataCompact,
        LoadResultDataColumnar
    >? Data { get; set; }

    [JsonPropertyName("lastRefreshTime")]
    public string? LastRefreshTime { get; set; }

    [JsonPropertyName("query")]
    public Dictionary<string, object?>? Query { get; set; }

    [JsonPropertyName("slowQuery")]
    public bool? SlowQuery { get; set; }

    [JsonPropertyName("external")]
    public bool? External { get; set; }

    [JsonPropertyName("dbType")]
    public string? DbType { get; set; }

    [JsonPropertyName("refreshKeyValues")]
    public IEnumerable<Dictionary<string, object?>>? RefreshKeyValues { get; set; }

    [JsonPropertyName("pivotQuery")]
    public Dictionary<string, object?>? PivotQuery { get; set; }

    [JsonPropertyName("queryType")]
    public string? QueryType { get; set; }

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
