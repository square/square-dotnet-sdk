using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DismissTerminalRefundResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Current state of the refund to be dismissed.
    /// </summary>
    [JsonPropertyName("refund")]
    public TerminalRefund? Refund { get; set; }

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
