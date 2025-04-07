using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CheckoutMerchantSettingsPaymentMethods
{
    [JsonPropertyName("apple_pay")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? ApplePay { get; set; }

    [JsonPropertyName("google_pay")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? GooglePay { get; set; }

    [JsonPropertyName("cash_app")]
    public CheckoutMerchantSettingsPaymentMethodsPaymentMethod? CashApp { get; set; }

    [JsonPropertyName("afterpay_clearpay")]
    public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay? AfterpayClearpay { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
