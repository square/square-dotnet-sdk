using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Refunds;

public record GetRefundsRequest
{
    /// <summary>
    /// The unique ID for the desired `PaymentRefund`.
    /// </summary>
    [JsonIgnore]
    public required string RefundId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
