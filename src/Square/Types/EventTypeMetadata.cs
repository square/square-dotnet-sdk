using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains the metadata of a webhook event type.
/// </summary>
public record EventTypeMetadata
{
    /// <summary>
    /// The event type.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    /// <summary>
    /// The API version at which the event type was introduced.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("api_version_introduced")]
    public string? ApiVersionIntroduced { get; set; }

    /// <summary>
    /// The release status of the event type.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("release_status")]
    public string? ReleaseStatus { get; set; }

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
