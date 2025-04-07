using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an action as a pending change to a subscription.
/// </summary>
public record SubscriptionAction
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
