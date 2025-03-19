using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public record DeletePaymentLinksRequest
{
    /// <summary>
    /// The ID of the payment link to delete.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
