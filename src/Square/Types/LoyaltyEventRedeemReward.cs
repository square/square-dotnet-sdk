using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Provides metadata when the event `type` is `REDEEM_REWARD`.
/// </summary>
public record LoyaltyEventRedeemReward
{
    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public required string LoyaltyProgramId { get; set; }

    /// <summary>
    /// The ID of the redeemed [loyalty reward](entity:LoyaltyReward).
    /// This field is returned only if the event source is `LOYALTY_API`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("reward_id")]
    public string? RewardId { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) that redeemed the reward.
    /// This field is returned only if the Orders API is used to process orders.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

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
