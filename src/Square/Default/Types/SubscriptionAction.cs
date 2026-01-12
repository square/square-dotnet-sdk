using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an action as a pending change to a subscription.
/// </summary>
[Serializable]
public record SubscriptionAction : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of an action scoped to a subscription.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of the action.
    /// See [SubscriptionActionType](#type-subscriptionactiontype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public SubscriptionActionType? Type { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date when the action occurs on the subscription.
    /// </summary>
    [JsonPropertyName("effective_date")]
    public string? EffectiveDate { get; set; }

    /// <summary>
    /// The new billing anchor day value, for a `CHANGE_BILLING_ANCHOR_DATE` action.
    /// </summary>
    [JsonPropertyName("monthly_billing_anchor_date")]
    public int? MonthlyBillingAnchorDate { get; set; }

    /// <summary>
    /// A list of Phases, to pass phase-specific information used in the swap.
    /// </summary>
    [JsonPropertyName("phases")]
    public IEnumerable<Phase>? Phases { get; set; }

    /// <summary>
    /// The target subscription plan variation that a subscription switches to, for a `SWAP_PLAN` action.
    /// </summary>
    [JsonPropertyName("new_plan_variation_id")]
    public string? NewPlanVariationId { get; set; }

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
