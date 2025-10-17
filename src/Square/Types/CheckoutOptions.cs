using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record CheckoutOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the payment allows tipping.
    /// </summary>
    [JsonPropertyName("allow_tipping")]
    public bool? AllowTipping { get; set; }

    /// <summary>
    /// The custom fields requesting information from the buyer.
    /// </summary>
    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

    /// <summary>
    /// The ID of the subscription plan for the buyer to pay and subscribe.
    /// For more information, see [Subscription Plan Checkout](https://developer.squareup.com/docs/checkout-api/subscription-plan-checkout).
    /// </summary>
    [JsonPropertyName("subscription_plan_id")]
    public string? SubscriptionPlanId { get; set; }

    /// <summary>
    /// The confirmation page URL to redirect the buyer to after Square processes the payment.
    /// </summary>
    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// The email address that buyers can use to contact the seller.
    /// </summary>
    [JsonPropertyName("merchant_support_email")]
    public string? MerchantSupportEmail { get; set; }

    /// <summary>
    /// Indicates whether to include the address fields in the payment form.
    /// </summary>
    [JsonPropertyName("ask_for_shipping_address")]
    public bool? AskForShippingAddress { get; set; }

    /// <summary>
    /// The methods allowed for buyers during checkout.
    /// </summary>
    [JsonPropertyName("accepted_payment_methods")]
    public AcceptedPaymentMethods? AcceptedPaymentMethods { get; set; }

    /// <summary>
    /// The amount of money that the developer is taking as a fee for facilitating the payment on behalf of the seller.
    ///
    /// The amount cannot be more than 90% of the total amount of the payment.
    ///
    /// The amount must be specified in the smallest denomination of the applicable currency (for example, US dollar amounts are specified in cents). For more information, see [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/common-data-types/working-with-monetary-amounts).
    ///
    /// The fee currency code must match the currency associated with the seller that is accepting the payment. The application must be from a developer account in the same country and using the same currency code as the seller. For more information about the application fee scenario, see [Take Payments and Collect Fees](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees).
    ///
    /// To set this field, `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required. For more information, see [Permissions](https://developer.squareup.com/docs/payments-api/collect-fees/additional-considerations#permissions).
    /// </summary>
    [JsonPropertyName("app_fee_money")]
    public Money? AppFeeMoney { get; set; }

    /// <summary>
    /// The fee associated with shipping to be applied to the `Order` as a service charge.
    /// </summary>
    [JsonPropertyName("shipping_fee")]
    public ShippingFee? ShippingFee { get; set; }

    /// <summary>
    /// Indicates whether to include the `Add coupon` section for the buyer to provide a Square marketing coupon in the payment form.
    /// </summary>
    [JsonPropertyName("enable_coupon")]
    public bool? EnableCoupon { get; set; }

    /// <summary>
    /// Indicates whether to include the `REWARDS` section for the buyer to opt in to loyalty, redeem rewards in the payment form, or both.
    /// </summary>
    [JsonPropertyName("enable_loyalty")]
    public bool? EnableLoyalty { get; set; }

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
