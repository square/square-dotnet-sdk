using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Loyalty.Rewards;

[Serializable]
public record GetRewardsRequest
{
    /// <summary>
    /// The ID of the [loyalty reward](entity:LoyaltyReward) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string RewardId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
