using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Subscriptions;

[Serializable]
public record ChangeBillingAnchorDateRequest
{
    /// <summary>
    /// The ID of the subscription to update the billing anchor date.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The anchor day for the billing cycle.
    /// </summary>
    [JsonPropertyName("monthly_billing_anchor_date")]
    public int? MonthlyBillingAnchorDate { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date when the scheduled `BILLING_ANCHOR_CHANGE` action takes
    /// place on the subscription.
    ///
    /// When this date is unspecified or falls within the current billing cycle, the billing anchor date
    /// is changed immediately.
    /// </summary>
    [JsonPropertyName("effective_date")]
    public string? EffectiveDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
