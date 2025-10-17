using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record DeviceMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Terminal’s remaining battery percentage, between 1-100.
    /// </summary>
    [JsonPropertyName("battery_percentage")]
    public string? BatteryPercentage { get; set; }

    /// <summary>
    /// The current charging state of the Terminal.
    /// Options: `CHARGING`, `NOT_CHARGING`
    /// </summary>
    [JsonPropertyName("charging_state")]
    public string? ChargingState { get; set; }

    /// <summary>
    /// The ID of the Square seller business location associated with the Terminal.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the Square merchant account that is currently signed-in to the Terminal.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The Terminal’s current network connection type.
    /// Options: `WIFI`, `ETHERNET`
    /// </summary>
    [JsonPropertyName("network_connection_type")]
    public string? NetworkConnectionType { get; set; }

    /// <summary>
    /// The country in which the Terminal is authorized to take payments.
    /// </summary>
    [JsonPropertyName("payment_region")]
    public string? PaymentRegion { get; set; }

    /// <summary>
    /// The unique identifier assigned to the Terminal, which can be found on the lower back
    /// of the device.
    /// </summary>
    [JsonPropertyName("serial_number")]
    public string? SerialNumber { get; set; }

    /// <summary>
    /// The current version of the Terminal’s operating system.
    /// </summary>
    [JsonPropertyName("os_version")]
    public string? OsVersion { get; set; }

    /// <summary>
    /// The current version of the application running on the Terminal.
    /// </summary>
    [JsonPropertyName("app_version")]
    public string? AppVersion { get; set; }

    /// <summary>
    /// The name of the Wi-Fi network to which the Terminal is connected.
    /// </summary>
    [JsonPropertyName("wifi_network_name")]
    public string? WifiNetworkName { get; set; }

    /// <summary>
    /// The signal strength of the Wi-FI network connection.
    /// Options: `POOR`, `FAIR`, `GOOD`, `EXCELLENT`
    /// </summary>
    [JsonPropertyName("wifi_network_strength")]
    public string? WifiNetworkStrength { get; set; }

    /// <summary>
    /// The IP address of the Terminal.
    /// </summary>
    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }

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
