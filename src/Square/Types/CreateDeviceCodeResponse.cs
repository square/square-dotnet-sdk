using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CreateDeviceCodeResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The created DeviceCode object containing the device code string.
    /// </summary>
    [JsonPropertyName("device_code")]
    public DeviceCode? DeviceCode { get; set; }

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
