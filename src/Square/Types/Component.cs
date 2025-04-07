using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The wrapper object for the component entries of a given component type.
/// </summary>
public record Component
{
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
