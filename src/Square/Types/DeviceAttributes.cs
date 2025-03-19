using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceAttributes
{
    /// <summary>
    /// The device type.
    /// See [DeviceType](#type-devicetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "TERMINAL";

    /// <summary>
    /// The maker of the device.
    /// </summary>
    [JsonPropertyName("manufacturer")]
    public required string Manufacturer { get; set; }

    /// <summary>
    /// The specific model of the device.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// A seller-specified name for the device.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The manufacturer-supplied identifier for the device (where available). In many cases,
    /// this identifier will be a serial number.
    /// </summary>
    [JsonPropertyName("manufacturers_id")]
    public string? ManufacturersId { get; set; }

    /// <summary>
    /// The RFC 3339-formatted value of the most recent update to the device information.
    /// (Could represent any field update on the device.)
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The current version of software installed on the device.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// The merchant_token identifying the merchant controlling the device.
    /// </summary>
    [JsonPropertyName("merchant_token")]
    public string? MerchantToken { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
