using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceComponentDetailsBatteryDetails
{
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
