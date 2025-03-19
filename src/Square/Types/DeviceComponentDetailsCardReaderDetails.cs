using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceComponentDetailsCardReaderDetails
{
    /// <summary>
    /// The version of the card reader.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

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
