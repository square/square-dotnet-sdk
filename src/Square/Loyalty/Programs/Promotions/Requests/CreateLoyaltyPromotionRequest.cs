using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Programs.Promotions;

public record CreateLoyaltyPromotionRequest
{
    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram) to associate with the promotion.
    /// To get the program ID, call [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram)
    /// using the `main` keyword.
    /// </summary>
    [JsonIgnore]
    public required string ProgramId { get; set; }

    /// <summary>
    /// The loyalty promotion to create.
    /// </summary>
    [JsonPropertyName("loyalty_promotion")]
    public required LoyaltyPromotion LoyaltyPromotion { get; set; }

    /// <summary>
    /// A unique identifier for this request, which is used to ensure idempotency. For more information,
    /// see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
