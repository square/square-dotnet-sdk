using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalCheckoutQuery
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
