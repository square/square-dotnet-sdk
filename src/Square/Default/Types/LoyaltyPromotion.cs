using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a promotion for a [loyalty program](entity:LoyaltyProgram). Loyalty promotions enable buyers
/// to earn extra points on top of those earned from the base program.
///
/// A loyalty program can have a maximum of 10 loyalty promotions with an `ACTIVE` or `SCHEDULED` status.
/// </summary>
[Serializable]
public record LoyaltyPromotion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square-assigned ID of the promotion.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the promotion.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The points incentive for the promotion. This field defines whether promotion points
    /// are earned by multiplying base program points or by adding a specified number of points.
    /// </summary>
    [JsonPropertyName("incentive")]
    public required LoyaltyPromotionIncentive Incentive { get; set; }

    /// <summary>
    /// The scheduling information that defines when purchases can qualify to earn points from an `ACTIVE` promotion.
    /// </summary>
    [JsonPropertyName("available_time")]
    public required LoyaltyPromotionAvailableTimeData AvailableTime { get; set; }

    /// <summary>
    /// The number of times a buyer can earn promotion points during a specified interval.
    /// If not specified, buyers can trigger the promotion an unlimited number of times.
    /// </summary>
    [JsonPropertyName("trigger_limit")]
    public LoyaltyPromotionTriggerLimit? TriggerLimit { get; set; }

    /// <summary>
    /// The current status of the promotion.
    /// See [LoyaltyPromotionStatus](#type-loyaltypromotionstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public LoyaltyPromotionStatus? Status { get; set; }

    /// <summary>
    /// The timestamp of when the promotion was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the promotion was canceled, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

    /// <summary>
    /// The timestamp when the promotion was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram) associated with the promotion.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public string? LoyaltyProgramId { get; set; }

    /// <summary>
    /// The minimum purchase amount required to earn promotion points. If specified, this amount is positive.
    /// </summary>
    [JsonPropertyName("minimum_spend_amount_money")]
    public Money? MinimumSpendAmountMoney { get; set; }

    /// <summary>
    /// The IDs of any qualifying `ITEM_VARIATION` [catalog objects](entity:CatalogObject). If specified,
    /// the purchase must include at least one of these items to qualify for the promotion.
    ///
    /// This option is valid only if the base loyalty program uses a `VISIT` or `SPEND` accrual rule.
    /// With `SPEND` accrual rules, make sure that qualifying promotional items are not excluded.
    ///
    /// You can specify `qualifying_item_variation_ids` or `qualifying_category_ids` for a given promotion, but not both.
    /// </summary>
    [JsonPropertyName("qualifying_item_variation_ids")]
    public IEnumerable<string>? QualifyingItemVariationIds { get; set; }

    /// <summary>
    /// The IDs of any qualifying `CATEGORY` [catalog objects](entity:CatalogObject). If specified,
    /// the purchase must include at least one item from one of these categories to qualify for the promotion.
    ///
    /// This option is valid only if the base loyalty program uses a `VISIT` or `SPEND` accrual rule.
    /// With `SPEND` accrual rules, make sure that qualifying promotional items are not excluded.
    ///
    /// You can specify `qualifying_category_ids` or `qualifying_item_variation_ids` for a promotion, but not both.
    /// </summary>
    [JsonPropertyName("qualifying_category_ids")]
    public IEnumerable<string>? QualifyingCategoryIds { get; set; }

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
