using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Provides metadata when the event `type` is `CREATE_REWARD`.
/// </summary>
public record LoyaltyEventCreateReward
{
    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public required string LoyaltyProgramId { get; set; }

    /// <summary>
    /// The Square-assigned ID of the created [loyalty reward](entity:LoyaltyReward).
    /// This field is returned only if the event source is `LOYALTY_API`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("reward_id")]
    public string? RewardId { get; set; }

    /// <summary>
    /// The loyalty points used to create the reward.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
