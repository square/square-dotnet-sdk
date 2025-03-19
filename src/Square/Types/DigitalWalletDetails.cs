using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about `WALLET` type payments. Contains only non-confidential information.
/// </summary>
public record DigitalWalletDetails
{
    /// <summary>
    /// The status of the `WALLET` payment. The status can be `AUTHORIZED`, `CAPTURED`, `VOIDED`, or
    /// `FAILED`.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The brand used for the `WALLET` payment. The brand can be `CASH_APP`, `PAYPAY`, `ALIPAY`,
    /// `RAKUTEN_PAY`, `AU_PAY`, `D_BARAI`, `MERPAY`, `WECHAT_PAY` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    /// <summary>
    /// Brand-specific details for payments with the `brand` of `CASH_APP`.
    /// </summary>
    [JsonPropertyName("cash_app_details")]
    public CashAppDetails? CashAppDetails { get; set; }

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
