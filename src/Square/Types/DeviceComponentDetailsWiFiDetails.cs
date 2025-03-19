using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceComponentDetailsWiFiDetails
{
    /// <summary>
    /// A boolean to represent whether the WiFI interface is currently active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// The name of the connected WIFI network.
    /// </summary>
    [JsonPropertyName("ssid")]
    public string? Ssid { get; set; }

    /// <summary>
    /// The string representation of the device’s IPv4 address.
    /// </summary>
    [JsonPropertyName("ip_address_v4")]
    public string? IpAddressV4 { get; set; }

    /// <summary>
    /// The security protocol for a secure connection (e.g. WPA2). None provided if the connection
    /// is unsecured.
    /// </summary>
    [JsonPropertyName("secure_connection")]
    public string? SecureConnection { get; set; }

    /// <summary>
    /// A representation of signal strength of the WIFI network connection.
    /// </summary>
    [JsonPropertyName("signal_strength")]
    public DeviceComponentDetailsMeasurement? SignalStrength { get; set; }

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
