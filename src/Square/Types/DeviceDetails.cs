using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about the device that took the payment.
/// </summary>
public record DeviceDetails
{
    /// <summary>
    /// The Square-issued ID of the device.
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// The Square-issued installation ID for the device.
    /// </summary>
    [JsonPropertyName("device_installation_id")]
    public string? DeviceInstallationId { get; set; }

    /// <summary>
    /// The name of the device set by the seller.
    /// </summary>
    [JsonPropertyName("device_name")]
    public string? DeviceName { get; set; }

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
