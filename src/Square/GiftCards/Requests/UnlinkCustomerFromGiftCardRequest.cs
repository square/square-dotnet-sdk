using System.Text.Json.Serialization;
using Square.Core;

namespace Square.GiftCards;

[Serializable]
public record UnlinkCustomerFromGiftCardRequest
{
    /// <summary>
    /// The ID of the gift card to be unlinked.
    /// </summary>
    [JsonIgnore]
    public required string GiftCardId { get; set; }

    /// <summary>
    /// The ID of the customer to unlink from the gift card.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
