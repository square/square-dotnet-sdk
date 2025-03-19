using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains metadata about a particular [Event](entity:Event).
/// </summary>
public record EventMetadata
{
    /// <summary>
    /// A unique ID for the event.
    /// </summary>
    [JsonPropertyName("event_id")]
    public string? EventId { get; set; }

    /// <summary>
    /// The API version of the event. This corresponds to the default API version of the developer application at the time when the event was created.
    /// </summary>
    [JsonPropertyName("api_version")]
    public string? ApiVersion { get; set; }

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
