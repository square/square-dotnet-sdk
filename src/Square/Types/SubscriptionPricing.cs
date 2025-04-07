using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes the pricing for the subscription.
/// </summary>
public record SubscriptionPricing
{
    /// <summary>
    /// RELATIVE or STATIC
    /// See [SubscriptionPricingType](#type-subscriptionpricingtype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public SubscriptionPricingType? Type { get; set; }

    /// <summary>
    /// The ids of the discount catalog objects
    /// </summary>
    [JsonPropertyName("discount_ids")]
    public IEnumerable<string>? DiscountIds { get; set; }

    /// <summary>
    /// The price of the subscription, if STATIC
    /// </summary>
    [JsonPropertyName("price_money")]
    public Money? PriceMoney { get; set; }

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
