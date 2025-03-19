using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a reward that can be applied to an order if the necessary
/// reward tier criteria are met. Rewards are created through the Loyalty API.
/// </summary>
public record OrderReward
{
    /// <summary>
    /// The identifier of the reward.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The identifier of the reward tier corresponding to this reward.
    /// </summary>
    [JsonPropertyName("reward_tier_id")]
    public required string RewardTierId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
