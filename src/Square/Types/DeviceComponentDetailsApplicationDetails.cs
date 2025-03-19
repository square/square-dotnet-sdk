using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceComponentDetailsApplicationDetails
{
    /// <summary>
    /// The type of application.
    /// See [ApplicationType](#type-applicationtype) for possible values
    /// </summary>
    [JsonPropertyName("application_type")]
    public string? ApplicationType { get; set; }

    /// <summary>
    /// The version of the application.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// The location_id of the session for the application.
    /// </summary>
    [JsonPropertyName("session_location")]
    public string? SessionLocation { get; set; }

    /// <summary>
    /// The id of the device code that was used to log in to the device.
    /// </summary>
    [JsonPropertyName("device_code_id")]
    public string? DeviceCodeId { get; set; }

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
