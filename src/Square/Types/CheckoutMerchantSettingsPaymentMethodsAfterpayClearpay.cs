using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The settings allowed for AfterpayClearpay.
/// </summary>
public record CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay
{
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
