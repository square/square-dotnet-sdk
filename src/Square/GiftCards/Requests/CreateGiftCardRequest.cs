using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.GiftCards;

public record CreateGiftCardRequest
{
    /// <summary>
    /// A unique identifier for this request, used to ensure idempotency. For more information,
    /// see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The ID of the [location](entity:Location) where the gift card should be registered for
    /// reporting purposes. Gift cards can be redeemed at any of the seller's locations.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The gift card to create. The `type` field is required for this request. The `gan_source`
    /// and `gan` fields are included as follows:
    ///
    /// To direct Square to generate a 16-digit GAN, omit `gan_source` and `gan`.
    ///
    /// To provide a custom GAN, include `gan_source` and `gan`.
    /// - For `gan_source`, specify `OTHER`.
    /// - For `gan`, provide a custom GAN containing 8 to 20 alphanumeric characters. The GAN must be
    /// unique for the seller and cannot start with the same bank identification number (BIN) as major
    /// credit cards. Do not use GANs that are easy to guess (such as 12345678) because they greatly
    /// increase the risk of fraud. It is the responsibility of the developer to ensure the security
    /// of their custom GANs. For more information, see
    /// [Custom GANs](https://developer.squareup.com/docs/gift-cards/using-gift-cards-api#custom-gans).
    ///
    /// To register an unused, physical gift card that the seller previously ordered from Square,
    /// include `gan` and provide the GAN that is printed on the gift card.
    /// </summary>
    [JsonPropertyName("gift_card")]
    public required GiftCard GiftCard { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
