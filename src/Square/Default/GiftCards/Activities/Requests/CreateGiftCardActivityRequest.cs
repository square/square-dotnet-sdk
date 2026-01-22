using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.GiftCards;

[Serializable]
public record CreateGiftCardActivityRequest
{
    /// <summary>
    /// A unique string that identifies the `CreateGiftCardActivity` request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The activity to create for the gift card. This activity must specify `gift_card_id` or `gift_card_gan` for the target
    /// gift card, the `location_id` where the activity occurred, and the activity `type` along with the corresponding activity details.
    /// </summary>
    [JsonPropertyName("gift_card_activity")]
    public required GiftCardActivity GiftCardActivity { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
