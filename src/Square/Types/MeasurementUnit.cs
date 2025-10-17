using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a unit of measurement to use with a quantity, such as ounces
/// or inches. Exactly one of the following fields are required: `custom_unit`,
/// `area_unit`, `length_unit`, `volume_unit`, and `weight_unit`.
/// </summary>
[Serializable]
public record MeasurementUnit : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A custom unit of measurement defined by the seller using the Point of Sale
    /// app or ad-hoc as an order line item.
    /// </summary>
    [JsonPropertyName("custom_unit")]
    public MeasurementUnitCustom? CustomUnit { get; set; }

    /// <summary>
    /// Represents a standard area unit.
    /// See [MeasurementUnitArea](#type-measurementunitarea) for possible values
    /// </summary>
    [JsonPropertyName("area_unit")]
    public MeasurementUnitArea? AreaUnit { get; set; }

    /// <summary>
    /// Represents a standard length unit.
    /// See [MeasurementUnitLength](#type-measurementunitlength) for possible values
    /// </summary>
    [JsonPropertyName("length_unit")]
    public MeasurementUnitLength? LengthUnit { get; set; }

    /// <summary>
    /// Represents a standard volume unit.
    /// See [MeasurementUnitVolume](#type-measurementunitvolume) for possible values
    /// </summary>
    [JsonPropertyName("volume_unit")]
    public MeasurementUnitVolume? VolumeUnit { get; set; }

    /// <summary>
    /// Represents a standard unit of weight or mass.
    /// See [MeasurementUnitWeight](#type-measurementunitweight) for possible values
    /// </summary>
    [JsonPropertyName("weight_unit")]
    public MeasurementUnitWeight? WeightUnit { get; set; }

    /// <summary>
    /// Reserved for API integrations that lack the ability to specify a real measurement unit
    /// See [MeasurementUnitGeneric](#type-measurementunitgeneric) for possible values
    /// </summary>
    [JsonPropertyName("generic_unit")]
    public string? GenericUnit { get; set; }

    /// <summary>
    /// Represents a standard unit of time.
    /// See [MeasurementUnitTime](#type-measurementunittime) for possible values
    /// </summary>
    [JsonPropertyName("time_unit")]
    public MeasurementUnitTime? TimeUnit { get; set; }

    /// <summary>
    /// Represents the type of the measurement unit.
    /// See [MeasurementUnitUnitType](#type-measurementunitunittype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public MeasurementUnitUnitType? Type { get; set; }

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
