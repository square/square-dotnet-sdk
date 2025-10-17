using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about the device that took the payment.
/// </summary>
[Serializable]
public record DeviceDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
