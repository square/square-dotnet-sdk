using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Loyalty;

[Serializable]
public record RedeemLoyaltyRewardRequest
{
    /// <summary>
    /// The ID of the [loyalty reward](entity:LoyaltyReward) to redeem.
    /// </summary>
    [JsonIgnore]
    public required string RewardId { get; set; }

    /// <summary>
    /// A unique string that identifies this `RedeemLoyaltyReward` request.
    /// Keys can be any valid string, but must be unique for every request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The ID of the [location](entity:Location) where the reward is redeemed.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
