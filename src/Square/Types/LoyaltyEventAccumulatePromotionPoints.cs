using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Provides metadata when the event `type` is `ACCUMULATE_PROMOTION_POINTS`.
/// </summary>
public record LoyaltyEventAccumulatePromotionPoints
{
    /// <summary>
    /// The Square-assigned ID of the [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public string? LoyaltyProgramId { get; set; }

    /// <summary>
    /// The Square-assigned ID of the [loyalty promotion](entity:LoyaltyPromotion).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_promotion_id")]
    public string? LoyaltyPromotionId { get; set; }

    /// <summary>
    /// The number of points earned by the event.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) for which the buyer earned the promotion points.
    /// Only applications that use the Orders API to process orders can trigger this event.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("order_id")]
    public required string OrderId { get; set; }

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
