using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceComponentDetailsEthernetDetails
{
    /// <summary>
    /// A boolean to represent whether the Ethernet interface is currently active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// The string representation of the device’s IPv4 address.
    /// </summary>
    [JsonPropertyName("ip_address_v4")]
    public string? IpAddressV4 { get; set; }

    /// <summary>
    /// The mac address of the device in this network.
    /// </summary>
    [JsonPropertyName("mac_address")]
    public string? MacAddress { get; set; }

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
