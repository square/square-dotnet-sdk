using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CreateSubscriptionRequest
{
    /// <summary>
    /// A unique string that identifies this `CreateSubscription` request.
    /// If you do not provide a unique string (or provide an empty string as the value),
    /// the endpoint treats each request as independent.
    ///
    /// For more information, see [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The ID of the location the subscription is associated with.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The ID of the [subscription plan variation](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations#plan-variations) created using the Catalog API.
    /// </summary>
    [JsonPropertyName("plan_variation_id")]
    public string? PlanVariationId { get; set; }

    /// <summary>
    /// The ID of the [customer](entity:Customer) subscribing to the subscription plan variation.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date to start the subscription.
    /// If it is unspecified, the subscription starts immediately.
    /// </summary>
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date when the newly created subscription is scheduled for cancellation.
    ///
    /// This date overrides the cancellation date set in the plan variation configuration.
    /// If the cancellation date is earlier than the end date of a subscription cycle, the subscription stops
    /// at the canceled date and the subscriber is sent a prorated invoice at the beginning of the canceled cycle.
    ///
    /// When the subscription plan of the newly created subscription has a fixed number of cycles and the `canceled_date`
    /// occurs before the subscription plan completes, the specified `canceled_date` sets the date when the subscription
    /// stops through the end of the last cycle.
    /// </summary>
    [JsonPropertyName("canceled_date")]
    public string? CanceledDate { get; set; }

    /// <summary>
    /// The tax to add when billing the subscription.
    /// The percentage is expressed in decimal form, using a `'.'` as the decimal
    /// separator and without a `'%'` sign. For example, a value of 7.5
    /// corresponds to 7.5%.
    /// </summary>
    [JsonPropertyName("tax_percentage")]
    public string? TaxPercentage { get; set; }

    /// <summary>
    /// A custom price which overrides the cost of a subscription plan variation with `STATIC` pricing.
    /// This field does not affect itemized subscriptions with `RELATIVE` pricing. Instead,
    /// you should edit the Subscription's [order template](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions#phases-and-order-templates).
    /// </summary>
    [JsonPropertyName("price_override_money")]
    public Money? PriceOverrideMoney { get; set; }

    /// <summary>
    /// The ID of the [subscriber's](entity:Customer) [card](entity:Card) to charge.
    /// If it is not specified, the subscriber receives an invoice via email with a link to pay for their subscription.
    /// </summary>
    [JsonPropertyName("card_id")]
    public string? CardId { get; set; }

    /// <summary>
    /// The timezone that is used in date calculations for the subscription. If unset, defaults to
    /// the location timezone. If a timezone is not configured for the location, defaults to "America/New_York".
    /// Format: the IANA Timezone Database identifier for the location timezone. For
    /// a list of time zones, see [List of tz database time zones](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones).
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// The origination details of the subscription.
    /// </summary>
    [JsonPropertyName("source")]
    public SubscriptionSource? Source { get; set; }

    /// <summary>
    /// The day-of-the-month to change the billing date to.
    /// </summary>
    [JsonPropertyName("monthly_billing_anchor_date")]
    public int? MonthlyBillingAnchorDate { get; set; }

    /// <summary>
    /// array of phases for this subscription
    /// </summary>
    [JsonPropertyName("phases")]
    public IEnumerable<Phase>? Phases { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
