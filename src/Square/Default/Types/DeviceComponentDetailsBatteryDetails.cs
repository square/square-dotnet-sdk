using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record DeviceComponentDetailsBatteryDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The battery charge percentage as displayed on the device.
    /// </summary>
    [JsonPropertyName("visible_percent")]
    public int? VisiblePercent { get; set; }

    /// <summary>
    /// The status of external_power.
    /// See [ExternalPower](#type-externalpower) for possible values
    /// </summary>
    [JsonPropertyName("external_power")]
    public DeviceComponentDetailsExternalPower? ExternalPower { get; set; }

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
