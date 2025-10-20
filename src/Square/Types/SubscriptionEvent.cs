using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes changes to a subscription and the subscription status.
/// </summary>
[Serializable]
public record SubscriptionEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the subscription event.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Type of the subscription event.
    /// See [SubscriptionEventSubscriptionEventType](#type-subscriptioneventsubscriptioneventtype) for possible values
    /// </summary>
    [JsonPropertyName("subscription_event_type")]
    public required SubscriptionEventSubscriptionEventType SubscriptionEventType { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) when the subscription event occurred.
    /// </summary>
    [JsonPropertyName("effective_date")]
    public required string EffectiveDate { get; set; }

    /// <summary>
    /// The day-of-the-month the billing anchor date was changed to, if applicable.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("monthly_billing_anchor_date")]
    public int? MonthlyBillingAnchorDate { get; set; }

    /// <summary>
    /// Additional information about the subscription event.
    /// </summary>
    [JsonPropertyName("info")]
    public SubscriptionEventInfo? Info { get; set; }

    /// <summary>
    /// A list of Phases, to pass phase-specific information used in the swap.
    /// </summary>
    [JsonPropertyName("phases")]
    public IEnumerable<Phase>? Phases { get; set; }

    /// <summary>
    /// The ID of the subscription plan variation associated with the subscription.
    /// </summary>
    [JsonPropertyName("plan_variation_id")]
    public required string PlanVariationId { get; set; }

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
