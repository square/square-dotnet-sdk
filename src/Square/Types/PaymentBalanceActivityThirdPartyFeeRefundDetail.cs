using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record PaymentBalanceActivityThirdPartyFeeRefundDetail
{
    /// <summary>
    /// The ID of the payment associated with this activity.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// The public refund id associated with this activity.
    /// </summary>
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

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
