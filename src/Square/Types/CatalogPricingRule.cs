using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines how discounts are automatically applied to a set of items that match the pricing rule
/// during the active time period.
/// </summary>
public record CatalogPricingRule
{
    /// <summary>
    /// User-defined name for the pricing rule. For example, "Buy one get one
    /// free" or "10% off".
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A list of unique IDs for the catalog time periods when
    /// this pricing rule is in effect. If left unset, the pricing rule is always
    /// in effect.
    /// </summary>
    [JsonPropertyName("time_period_ids")]
    public IEnumerable<string>? TimePeriodIds { get; set; }

    /// <summary>
    /// Unique ID for the `CatalogDiscount` to take off
    /// the price of all matched items.
    /// </summary>
    [JsonPropertyName("discount_id")]
    public string? DiscountId { get; set; }

    /// <summary>
    /// Unique ID for the `CatalogProductSet` that will be matched by this rule. A match rule
    /// matches within the entire cart, and can match multiple times. This field will always be set.
    /// </summary>
    [JsonPropertyName("match_products_id")]
    public string? MatchProductsId { get; set; }

    /// <summary>
    /// __Deprecated__: Please use the `exclude_products_id` field to apply
    /// an exclude set instead. Exclude sets allow better control over quantity
    /// ranges and offer more flexibility for which matched items receive a discount.
    ///
    /// `CatalogProductSet` to apply the pricing to.
    /// An apply rule matches within the subset of the cart that fits the match rules (the match set).
    /// An apply rule can only match once in the match set.
    /// If not supplied, the pricing will be applied to all products in the match set.
    /// Other products retain their base price, or a price generated by other rules.
    /// </summary>
    [JsonPropertyName("apply_products_id")]
    public string? ApplyProductsId { get; set; }

    /// <summary>
    /// `CatalogProductSet` to exclude from the pricing rule.
    /// An exclude rule matches within the subset of the cart that fits the match rules (the match set).
    /// An exclude rule can only match once in the match set.
    /// If not supplied, the pricing will be applied to all products in the match set.
    /// Other products retain their base price, or a price generated by other rules.
    /// </summary>
    [JsonPropertyName("exclude_products_id")]
    public string? ExcludeProductsId { get; set; }

    /// <summary>
    /// Represents the date the Pricing Rule is valid from. Represented in RFC 3339 full-date format (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("valid_from_date")]
    public string? ValidFromDate { get; set; }

    /// <summary>
    /// Represents the local time the pricing rule should be valid from. Represented in RFC 3339 partial-time format
    /// (HH:MM:SS). Partial seconds will be truncated.
    /// </summary>
    [JsonPropertyName("valid_from_local_time")]
    public string? ValidFromLocalTime { get; set; }

    /// <summary>
    /// Represents the date the Pricing Rule is valid until. Represented in RFC 3339 full-date format (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("valid_until_date")]
    public string? ValidUntilDate { get; set; }

    /// <summary>
    /// Represents the local time the pricing rule should be valid until. Represented in RFC 3339 partial-time format
    /// (HH:MM:SS). Partial seconds will be truncated.
    /// </summary>
    [JsonPropertyName("valid_until_local_time")]
    public string? ValidUntilLocalTime { get; set; }

    /// <summary>
    /// If an `exclude_products_id` was given, controls which subset of matched
    /// products is excluded from any discounts.
    ///
    /// Default value: `LEAST_EXPENSIVE`
    /// See [ExcludeStrategy](#type-excludestrategy) for possible values
    /// </summary>
    [JsonPropertyName("exclude_strategy")]
    public ExcludeStrategy? ExcludeStrategy { get; set; }

    /// <summary>
    /// The minimum order subtotal (before discounts or taxes are applied)
    /// that must be met before this rule may be applied.
    /// </summary>
    [JsonPropertyName("minimum_order_subtotal_money")]
    public Money? MinimumOrderSubtotalMoney { get; set; }

    /// <summary>
    /// A list of IDs of customer groups, the members of which are eligible for discounts specified in this pricing rule.
    /// Notice that a group ID is generated by the Customers API.
    /// If this field is not set, the specified discount applies to matched products sold to anyone whether the buyer
    /// has a customer profile created or not. If this `customer_group_ids_any` field is set, the specified discount
    /// applies only to matched products sold to customers belonging to the specified customer groups.
    /// </summary>
    [JsonPropertyName("customer_group_ids_any")]
    public IEnumerable<string>? CustomerGroupIdsAny { get; set; }

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
