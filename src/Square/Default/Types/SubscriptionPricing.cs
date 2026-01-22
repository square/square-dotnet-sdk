using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Describes the pricing for the subscription.
/// </summary>
[Serializable]
public record SubscriptionPricing : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
