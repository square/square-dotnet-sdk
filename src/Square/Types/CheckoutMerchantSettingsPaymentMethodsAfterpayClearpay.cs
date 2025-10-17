using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The settings allowed for AfterpayClearpay.
/// </summary>
[Serializable]
public record CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Afterpay is shown as an option for order totals falling within the configured range.
    /// </summary>
    [JsonPropertyName("order_eligibility_range")]
    public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange? OrderEligibilityRange { get; set; }

    /// <summary>
    /// Afterpay is shown as an option for item totals falling within the configured range.
    /// </summary>
    [JsonPropertyName("item_eligibility_range")]
    public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange? ItemEligibilityRange { get; set; }

    /// <summary>
    /// Indicates whether the payment method is enabled for the account.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

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
