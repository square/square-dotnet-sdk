using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record TerminalCheckoutQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Options for filtering returned `TerminalCheckout` objects.
    /// </summary>
    [JsonPropertyName("filter")]
    public TerminalCheckoutQueryFilter? Filter { get; set; }

    /// <summary>
    /// Option for sorting returned `TerminalCheckout` objects.
    /// </summary>
    [JsonPropertyName("sort")]
    public TerminalCheckoutQuerySort? Sort { get; set; }

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
