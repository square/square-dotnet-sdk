using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public record CreatePaymentLinkRequest
{
    /// <summary>
    /// A unique string that identifies this `CreatePaymentLinkRequest` request.
    /// If you do not provide a unique string (or provide an empty string as the value),
    /// the endpoint treats each request as independent.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// A description of the payment link. You provide this optional description that is useful in your
    /// application context. It is not used anywhere.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Describes an ad hoc item and price for which to generate a quick pay checkout link.
    /// For more information,
    /// see [Quick Pay Checkout](https://developer.squareup.com/docs/checkout-api/quick-pay-checkout).
    /// </summary>
    [JsonPropertyName("quick_pay")]
    public QuickPay? QuickPay { get; set; }

    /// <summary>
    /// Describes the `Order` for which to create a checkout link.
    /// For more information,
    /// see [Square Order Checkout](https://developer.squareup.com/docs/checkout-api/square-order-checkout).
    /// </summary>
    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    /// <summary>
    /// Describes optional fields to add to the resulting checkout page.
    /// For more information,
    /// see [Optional Checkout Configurations](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations).
    /// </summary>
    [JsonPropertyName("checkout_options")]
    public CheckoutOptions? CheckoutOptions { get; set; }

    /// <summary>
    /// Describes fields to prepopulate in the resulting checkout page.
    /// For more information, see [Prepopulate the shipping address](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations#prepopulate-the-shipping-address).
    /// </summary>
    [JsonPropertyName("pre_populated_data")]
    public PrePopulatedData? PrePopulatedData { get; set; }

    /// <summary>
    /// A note for the payment. After processing the payment, Square adds this note to the resulting `Payment`.
    /// </summary>
    [JsonPropertyName("payment_note")]
    public string? PaymentNote { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
