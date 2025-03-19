using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Pricing options for an order. The options affect how the order's price is calculated.
/// They can be used, for example, to apply automatic price adjustments that are based on preconfigured
/// [pricing rules](entity:CatalogPricingRule).
/// </summary>
public record OrderPricingOptions
{
    /// <summary>
    /// The option to determine whether pricing rule-based
    /// discounts are automatically applied to an order.
    /// </summary>
    [JsonPropertyName("auto_apply_discounts")]
    public bool? AutoApplyDiscounts { get; set; }

    /// <summary>
    /// The option to determine whether rule-based taxes are automatically
    /// applied to an order when the criteria of the corresponding rules are met.
    /// </summary>
    [JsonPropertyName("auto_apply_taxes")]
    public bool? AutoApplyTaxes { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
