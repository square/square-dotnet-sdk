using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Loyalty.Rewards;

[Serializable]
public record DeleteRewardsRequest
{
    /// <summary>
    /// The ID of the [loyalty reward](entity:LoyaltyReward) to delete.
    /// </summary>
    [JsonIgnore]
    public required string RewardId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
