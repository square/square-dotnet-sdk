using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public record GetPaymentLinksRequest
{
    /// <summary>
    /// The ID of link to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
