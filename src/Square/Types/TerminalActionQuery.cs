using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record TerminalActionQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Options for filtering returned `TerminalAction`s
    /// </summary>
    [JsonPropertyName("filter")]
    public TerminalActionQueryFilter? Filter { get; set; }

    /// <summary>
    /// Option for sorting returned `TerminalAction` objects.
    /// </summary>
    [JsonPropertyName("sort")]
    public TerminalActionQuerySort? Sort { get; set; }

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
