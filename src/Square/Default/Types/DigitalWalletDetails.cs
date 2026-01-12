using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Additional details about `WALLET` type payments. Contains only non-confidential information.
/// </summary>
[Serializable]
public record DigitalWalletDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
