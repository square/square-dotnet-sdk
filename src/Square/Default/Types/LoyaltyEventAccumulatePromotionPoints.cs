using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Provides metadata when the event `type` is `ACCUMULATE_PROMOTION_POINTS`.
/// </summary>
[Serializable]
public record LoyaltyEventAccumulatePromotionPoints : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    public int? Points { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) for which the buyer earned the promotion points.
    /// Only applications that use the Orders API to process orders can trigger this event.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
