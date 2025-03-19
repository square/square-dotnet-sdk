using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public record UpdatePaymentLinkRequest
{
    /// <summary>
    /// The ID of the payment link to update.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The `payment_link` object describing the updates to apply.
    /// For more information, see [Update a payment link](https://developer.squareup.com/docs/checkout-api/manage-checkout#update-a-payment-link).
    /// </summary>
    [JsonPropertyName("payment_link")]
    public required PaymentLink PaymentLink { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
