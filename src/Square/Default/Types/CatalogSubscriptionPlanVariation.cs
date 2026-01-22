using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Describes a subscription plan variation. A subscription plan variation represents how the subscription for a product or service is sold.
/// For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
/// </summary>
[Serializable]
public record CatalogSubscriptionPlanVariation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the plan variation.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A list containing each [SubscriptionPhase](entity:SubscriptionPhase) for this plan variation.
    /// </summary>
    [JsonPropertyName("phases")]
    public IEnumerable<SubscriptionPhase> Phases { get; set; } = new List<SubscriptionPhase>();

    /// <summary>
    /// The id of the subscription plan, if there is one.
    /// </summary>
    [JsonPropertyName("subscription_plan_id")]
    public string? SubscriptionPlanId { get; set; }

    /// <summary>
    /// The day of the month the billing period starts.
    /// </summary>
    [JsonPropertyName("monthly_billing_anchor_date")]
    public long? MonthlyBillingAnchorDate { get; set; }

    /// <summary>
    /// Whether bills for this plan variation can be split for proration.
    /// </summary>
    [JsonPropertyName("can_prorate")]
    public bool? CanProrate { get; set; }

    /// <summary>
    /// The ID of a "successor" plan variation to this one. If the field is set, and this object is disabled at all
    /// locations, it indicates that this variation is deprecated and the object identified by the successor ID be used in
    /// its stead.
    /// </summary>
    [JsonPropertyName("successor_plan_variation_id")]
    public string? SuccessorPlanVariationId { get; set; }

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
