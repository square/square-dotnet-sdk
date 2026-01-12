using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Refunds;

[Serializable]
public record GetRefundsRequest
{
    /// <summary>
    /// The unique ID for the desired `PaymentRefund`.
    /// </summary>
    [JsonIgnore]
    public required string RefundId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
