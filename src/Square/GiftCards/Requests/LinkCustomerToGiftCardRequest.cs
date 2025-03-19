using System.Text.Json.Serialization;
using Square.Core;

namespace Square.GiftCards;

public record LinkCustomerToGiftCardRequest
{
    /// <summary>
    /// The ID of the gift card to be linked.
    /// </summary>
    [JsonIgnore]
    public required string GiftCardId { get; set; }

    /// <summary>
    /// The ID of the customer to link to the gift card.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
