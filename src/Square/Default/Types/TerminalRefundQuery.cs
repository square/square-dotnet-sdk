using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record TerminalRefundQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The filter for the Terminal refund query.
    /// </summary>
    [JsonPropertyName("filter")]
    public TerminalRefundQueryFilter? Filter { get; set; }

    /// <summary>
    /// The sort order for the Terminal refund query.
    /// </summary>
    [JsonPropertyName("sort")]
    public TerminalRefundQuerySort? Sort { get; set; }

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
