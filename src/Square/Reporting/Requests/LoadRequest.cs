using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record LoadRequest
{
    [JsonPropertyName("queryType")]
    public string? QueryType { get; set; }

    [JsonPropertyName("cache")]
    public CacheMode? Cache { get; set; }

    [JsonPropertyName("query")]
    public Query? Query { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
