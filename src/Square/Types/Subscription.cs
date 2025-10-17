using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a subscription purchased by a customer.
///
/// For more information, see
/// [Manage Subscriptions](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions).
/// </summary>
[Serializable]
public record Subscription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square-assigned ID of the subscription.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the location associated with the subscription.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the subscribed-to [subscription plan variation](entity:CatalogSubscriptionPlanVariation).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("plan_variation_id")]
    public string? PlanVariationId { get; set; }

    /// <summary>
    /// The ID of the subscribing [customer](entity:Customer) profile.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) to start the subscription.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) to cancel the subscription,
    /// when the subscription status changes to `CANCELED` and the subscription billing stops.
    ///
    /// If this field is not set, the subscription ends according its subscription plan.
    ///
    /// This field cannot be updated, other than being cleared.
    /// </summary>
    [JsonPropertyName("canceled_date")]
    public string? CanceledDate { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date up to when the subscriber is invoiced for the
    /// subscription.
    ///
    /// After the invoice is sent for a given billing period,
    /// this date will be the last day of the billing period.
    /// For example,
    /// suppose for the month of May a subscriber gets an invoice
    /// (or charged the card) on May 1. For the monthly billing scenario,
    /// this date is then set to May 31.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("charged_through_date")]
    public string? ChargedThroughDate { get; set; }

    /// <summary>
    /// The current status of the subscription.
    /// See [SubscriptionStatus](#type-subscriptionstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public SubscriptionStatus? Status { get; set; }

    /// <summary>
    /// The tax amount applied when billing the subscription. The
    /// percentage is expressed in decimal form, using a `'.'` as the decimal
    /// separator and without a `'%'` sign. For example, a value of `7.5`
    /// corresponds to 7.5%.
    /// </summary>
    [JsonPropertyName("tax_percentage")]
    public string? TaxPercentage { get; set; }

    /// <summary>
    /// The IDs of the [invoices](entity:Invoice) created for the
    /// subscription, listed in order when the invoices were created
    /// (newest invoices appear first).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("invoice_ids")]
    public IEnumerable<string>? InvoiceIds { get; set; }

    /// <summary>
    /// A custom price which overrides the cost of a subscription plan variation with `STATIC` pricing.
    /// This field does not affect itemized subscriptions with `RELATIVE` pricing. Instead,
    /// you should edit the Subscription's [order template](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions#phases-and-order-templates).
    /// </summary>
    [JsonPropertyName("price_override_money")]
    public Money? PriceOverrideMoney { get; set; }

    /// <summary>
    /// The version of the object. When updating an object, the version
    /// supplied must match the version in the database, otherwise the write will
    /// be rejected as conflicting.
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; set; }

    /// <summary>
    /// The timestamp when the subscription was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The ID of the [subscriber's](entity:Customer) [card](entity:Card)
    /// used to charge for the subscription.
    /// </summary>
    [JsonPropertyName("card_id")]
    public string? CardId { get; set; }

    /// <summary>
    /// Timezone that will be used in date calculations for the subscription.
    /// Defaults to the timezone of the location based on `location_id`.
    /// Format: the IANA Timezone Database identifier for the location timezone (for example, `America/Los_Angeles`).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// The origination details of the subscription.
    /// </summary>
    [JsonPropertyName("source")]
    public SubscriptionSource? Source { get; set; }

    /// <summary>
    /// The list of scheduled actions on this subscription. It is set only in the response from
    /// [RetrieveSubscription](api-endpoint:Subscriptions-RetrieveSubscription) with the query parameter
    /// of `include=actions` or from
    /// [SearchSubscriptions](api-endpoint:Subscriptions-SearchSubscriptions) with the input parameter
    /// of `include:["actions"]`.
    /// </summary>
    [JsonPropertyName("actions")]
    public IEnumerable<SubscriptionAction>? Actions { get; set; }

    /// <summary>
    /// The day of the month on which the subscription will issue invoices and publish orders.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("monthly_billing_anchor_date")]
    public int? MonthlyBillingAnchorDate { get; set; }

    /// <summary>
    /// array of phases for this subscription
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("phases")]
    public IEnumerable<Phase>? Phases { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date when the subscription enters a terminal state.
    /// </summary>
    [JsonPropertyName("completed_date")]
    public string? CompletedDate { get; set; }

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
