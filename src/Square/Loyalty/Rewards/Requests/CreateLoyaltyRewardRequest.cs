using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Rewards;

public record CreateLoyaltyRewardRequest
{
    /// <summary>
    /// The reward to create.
    /// </summary>
    [JsonPropertyName("reward")]
    public required LoyaltyReward Reward { get; set; }

    /// <summary>
    /// A unique string that identifies this `CreateLoyaltyReward` request.
    /// Keys can be any valid string, but must be unique for every request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
