using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record JoinSubquery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sql")]
    public required string Sql { get; set; }

    [JsonPropertyName("on")]
    public required string On { get; set; }

    [JsonPropertyName("joinType")]
    public required string JoinType { get; set; }

    [JsonPropertyName("alias")]
    public required string Alias { get; set; }

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
