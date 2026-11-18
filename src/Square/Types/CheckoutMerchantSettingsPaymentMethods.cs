using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record CheckoutMerchantSettingsPaymentMethods : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Apple Pay.
    /// </summary>
    [JsonPropertyName("apple_pay")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? ApplePay { get; set; }

    /// <summary>
    /// Google Pay.
    /// </summary>
    [JsonPropertyName("google_pay")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? GooglePay { get; set; }

    /// <summary>
    /// Cash App Pay.
    /// </summary>
    [JsonPropertyName("cash_app")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? CashApp { get; set; }

    /// <summary>
    /// Bank account (ACH). Enabled by default for eligible sellers who have
    /// not saved an ACH preference. A saved enabled or disabled choice takes precedence.
    /// </summary>
    [JsonPropertyName("bank_account")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? BankAccount { get; set; }

    /// <summary>
    /// Afterpay/Clearpay.
    /// </summary>
    [JsonPropertyName("afterpay_clearpay")]
    public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay? AfterpayClearpay { get; set; }

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
