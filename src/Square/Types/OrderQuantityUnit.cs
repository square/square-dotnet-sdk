using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains the measurement unit for a quantity and a precision that
/// specifies the number of digits after the decimal point for decimal quantities.
/// </summary>
public record OrderQuantityUnit
{
    /// <summary>
    /// A [MeasurementUnit](entity:MeasurementUnit) that represents the
    /// unit of measure for the quantity.
    /// </summary>
    [JsonPropertyName("measurement_unit")]
    public MeasurementUnit? MeasurementUnit { get; set; }

    /// <summary>
    /// For non-integer quantities, represents the number of digits after the decimal point that are
    /// recorded for this quantity.
    ///
    /// For example, a precision of 1 allows quantities such as `"1.0"` and `"1.1"`, but not `"1.01"`.
    ///
    /// Min: 0. Max: 5.
    /// </summary>
    [JsonPropertyName("precision")]
    public int? Precision { get; set; }

    /// <summary>
    /// The catalog object ID referencing the
    /// [CatalogMeasurementUnit](entity:CatalogMeasurementUnit).
    ///
    /// This field is set when this is a catalog-backed measurement unit.
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this measurement unit references.
    ///
    /// This field is set when this is a catalog-backed measurement unit.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

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
