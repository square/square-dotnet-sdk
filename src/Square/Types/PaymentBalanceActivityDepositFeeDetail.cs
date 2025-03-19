using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record PaymentBalanceActivityDepositFeeDetail
{
    /// <summary>
    /// The ID of the payout that triggered this deposit fee activity.
    /// </summary>
    [JsonPropertyName("payout_id")]
    public string? PayoutId { get; set; }

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
