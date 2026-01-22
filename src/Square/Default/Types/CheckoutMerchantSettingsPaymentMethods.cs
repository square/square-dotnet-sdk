using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CheckoutMerchantSettingsPaymentMethods : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("apple_pay")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? ApplePay { get; set; }

    [JsonPropertyName("google_pay")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? GooglePay { get; set; }

    [JsonPropertyName("cash_app")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? CashApp { get; set; }

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
