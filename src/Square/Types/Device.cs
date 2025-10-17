using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record Device : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
