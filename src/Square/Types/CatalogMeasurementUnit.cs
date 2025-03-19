using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the unit used to measure a `CatalogItemVariation` and
/// specifies the precision for decimal quantities.
/// </summary>
public record CatalogMeasurementUnit
{
    /// <summary>
    /// Indicates the unit used to measure the quantity of a catalog item variation.
    /// </summary>
    [JsonPropertyName("measurement_unit")]
    public MeasurementUnit? MeasurementUnit { get; set; }

    /// <summary>
    /// An integer between 0 and 5 that represents the maximum number of
    /// positions allowed after the decimal in quantities measured with this unit.
    /// For example:
    ///
    /// - if the precision is 0, the quantity can be 1, 2, 3, etc.
    /// - if the precision is 1, the quantity can be 0.1, 0.2, etc.
    /// - if the precision is 2, the quantity can be 0.01, 0.12, etc.
    ///
    /// Default: 3
    /// </summary>
    [JsonPropertyName("precision")]
    public int? Precision { get; set; }

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
