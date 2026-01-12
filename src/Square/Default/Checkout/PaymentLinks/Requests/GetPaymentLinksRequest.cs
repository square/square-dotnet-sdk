using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Checkout.PaymentLinks;

[Serializable]
public record GetPaymentLinksRequest
{
    /// <summary>
    /// The ID of link to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
