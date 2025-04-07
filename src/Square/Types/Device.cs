using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record Device
{
    /// <summary>
    /// A synthetic identifier for the device. The identifier includes a standardized prefix and
    /// is otherwise an opaque id generated from key device fields.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// A collection of DeviceAttributes representing the device.
    /// </summary>
    [JsonPropertyName("attributes")]
    public required DeviceAttributes Attributes { get; set; }

    /// <summary>
    /// A list of components applicable to the device.
    /// </summary>
    [JsonPropertyName("components")]
    public IEnumerable<Component>? Components { get; set; }

    /// <summary>
    /// The current status of the device.
    /// </summary>
    [JsonPropertyName("status")]
    public DeviceStatus? Status { get; set; }

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
