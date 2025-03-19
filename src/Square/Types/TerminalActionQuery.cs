using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalActionQuery
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
