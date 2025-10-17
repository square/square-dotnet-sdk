using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains the measurement unit for a quantity and a precision that
/// specifies the number of digits after the decimal point for decimal quantities.
/// </summary>
[Serializable]
public record OrderQuantityUnit : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
