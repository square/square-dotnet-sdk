using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The wrapper object for the component entries of a given component type.
/// </summary>
[Serializable]
public record Component : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of this component. Each component type has expected properties expressed
    /// in a structured format within its corresponding `*_details` field.
    /// See [ComponentType](#type-componenttype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required ComponentComponentType Type { get; set; }

    /// <summary>
    /// Structured data for an `Application`, set for Components of type `APPLICATION`.
    /// </summary>
    [JsonPropertyName("application_details")]
    public DeviceComponentDetailsApplicationDetails? ApplicationDetails { get; set; }

    /// <summary>
    /// Structured data for a `CardReader`, set for Components of type `CARD_READER`.
    /// </summary>
    [JsonPropertyName("card_reader_details")]
    public DeviceComponentDetailsCardReaderDetails? CardReaderDetails { get; set; }

    /// <summary>
    /// Structured data for a `Battery`, set for Components of type `BATTERY`.
    /// </summary>
    [JsonPropertyName("battery_details")]
    public DeviceComponentDetailsBatteryDetails? BatteryDetails { get; set; }

    /// <summary>
    /// Structured data for a `WiFi` interface, set for Components of type `WIFI`.
    /// </summary>
    [JsonPropertyName("wifi_details")]
    public DeviceComponentDetailsWiFiDetails? WifiDetails { get; set; }

    /// <summary>
    /// Structured data for an `Ethernet` interface, set for Components of type `ETHERNET`.
    /// </summary>
    [JsonPropertyName("ethernet_details")]
    public DeviceComponentDetailsEthernetDetails? EthernetDetails { get; set; }

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
