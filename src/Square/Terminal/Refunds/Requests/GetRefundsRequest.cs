using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Terminal.Refunds;

public record GetRefundsRequest
{
    /// <summary>
    /// The unique ID for the desired `TerminalRefund`.
    /// </summary>
    [JsonIgnore]
    public required string TerminalRefundId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
