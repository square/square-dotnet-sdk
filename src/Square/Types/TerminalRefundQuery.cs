using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalRefundQuery
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
