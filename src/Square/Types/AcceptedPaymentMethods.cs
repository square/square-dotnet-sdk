using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record AcceptedPaymentMethods : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether Apple Pay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("apple_pay")]
    public bool? ApplePay { get; set; }

    /// <summary>
    /// Whether Google Pay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("google_pay")]
    public bool? GooglePay { get; set; }

    /// <summary>
    /// Whether Cash App Pay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("cash_app_pay")]
    public bool? CashAppPay { get; set; }

    /// <summary>
    /// Whether Afterpay/Clearpay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("afterpay_clearpay")]
    public bool? AfterpayClearpay { get; set; }

    /// <summary>
    /// Whether ACH bank transfer payments are accepted at checkout.
    /// When enabled, buyers can pay directly from their bank account via Plaid.
    /// This payment method is supported only for seller locations in the United States.
    /// When omitted from CreatePaymentLink, ACH is enabled for eligible one-time USD
    /// payments unless the seller has disabled ACH in their merchant settings.
    /// Set this field to false to disable ACH for the link. Existing links retain
    /// their saved setting when this field is omitted from an update.
    /// </summary>
    [JsonPropertyName("bank_account")]
    public bool? BankAccount { get; set; }

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
