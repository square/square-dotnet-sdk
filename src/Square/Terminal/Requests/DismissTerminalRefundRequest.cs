using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Terminal;

public record DismissTerminalRefundRequest
{
    /// <summary>
    /// Unique ID for the `TerminalRefund` associated with the refund to be dismissed.
    /// </summary>
    [JsonIgnore]
    public required string TerminalRefundId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
