using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A tax applicable to an item.
/// </summary>
public record CatalogTax
{
    /// <summary>
    /// The tax's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Whether the tax is calculated based on a payment's subtotal or total.
    /// See [TaxCalculationPhase](#type-taxcalculationphase) for possible values
    /// </summary>
    [JsonPropertyName("calculation_phase")]
    public TaxCalculationPhase? CalculationPhase { get; set; }

    /// <summary>
    /// Whether the tax is `ADDITIVE` or `INCLUSIVE`.
    /// See [TaxInclusionType](#type-taxinclusiontype) for possible values
    /// </summary>
    [JsonPropertyName("inclusion_type")]
    public TaxInclusionType? InclusionType { get; set; }

    /// <summary>
    /// The percentage of the tax in decimal form, using a `'.'` as the decimal separator and without a `'%'` sign.
    /// A value of `7.5` corresponds to 7.5%. For a location-specific tax rate, contact the tax authority of the location or a tax consultant.
    /// </summary>
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    /// <summary>
    /// If `true`, the fee applies to custom amounts entered into the Square Point of Sale
    /// app that are not associated with a particular `CatalogItem`.
    /// </summary>
    [JsonPropertyName("applies_to_custom_amounts")]
    public bool? AppliesToCustomAmounts { get; set; }

    /// <summary>
    /// A Boolean flag to indicate whether the tax is displayed as enabled (`true`) in the Square Point of Sale app or not (`false`).
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The ID of a `CatalogProductSet` object. If set, the tax is applicable to all products in the product set.
    /// </summary>
    [JsonPropertyName("applies_to_product_set_id")]
    public string? AppliesToProductSetId { get; set; }

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
