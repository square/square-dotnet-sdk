using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record DeviceComponentDetailsWiFiDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    /// The mac address of the device in this network.
    /// </summary>
    [JsonPropertyName("mac_address")]
    public string? MacAddress { get; set; }

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
