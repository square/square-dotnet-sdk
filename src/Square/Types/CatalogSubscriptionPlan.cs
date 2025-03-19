using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a subscription plan. A subscription plan represents what you want to sell in a subscription model, and includes references to each of the associated subscription plan variations.
/// For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
/// </summary>
public record CatalogSubscriptionPlan
{
    /// <summary>
    /// The name of the plan.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A list of SubscriptionPhase containing the [SubscriptionPhase](entity:SubscriptionPhase) for this plan.
    /// This field it required. Not including this field will throw a REQUIRED_FIELD_MISSING error
    /// </summary>
    [JsonPropertyName("phases")]
    public IEnumerable<SubscriptionPhase>? Phases { get; set; }

    /// <summary>
    /// The list of subscription plan variations available for this product
    /// </summary>
    [JsonPropertyName("subscription_plan_variations")]
    public IEnumerable<CatalogObject>? SubscriptionPlanVariations { get; set; }

    /// <summary>
    /// The list of IDs of `CatalogItems` that are eligible for subscription by this SubscriptionPlan's variations.
    /// </summary>
    [JsonPropertyName("eligible_item_ids")]
    public IEnumerable<string>? EligibleItemIds { get; set; }

    /// <summary>
    /// The list of IDs of `CatalogCategory` that are eligible for subscription by this SubscriptionPlan's variations.
    /// </summary>
    [JsonPropertyName("eligible_category_ids")]
    public IEnumerable<string>? EligibleCategoryIds { get; set; }

    /// <summary>
    /// If true, all items in the merchant's catalog are subscribable by this SubscriptionPlan.
    /// </summary>
    [JsonPropertyName("all_items")]
    public bool? AllItems { get; set; }

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
