using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Orders;

[Serializable]
public record CalculateOrderRequest
{
    /// <summary>
    /// The order to be calculated. Expects the entire order, not a sparse update.
    /// </summary>
    [JsonPropertyName("order")]
    public required Order Order { get; set; }

    /// <summary>
    /// Identifies one or more loyalty reward tiers to apply during the order calculation.
    /// The discounts defined by the reward tiers are added to the order only to preview the
    /// effect of applying the specified rewards. The rewards do not correspond to actual
    /// redemptions; that is, no `reward`s are created. Therefore, the reward `id`s are
    /// random strings used only to reference the reward tier.
    /// </summary>
    [JsonPropertyName("proposed_rewards")]
    public IEnumerable<OrderReward>? ProposedRewards { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
