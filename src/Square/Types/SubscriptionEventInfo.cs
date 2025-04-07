using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Provides information about the subscription event.
/// </summary>
public record SubscriptionEventInfo
{
    /// <summary>
    /// A human-readable explanation for the event.
    /// </summary>
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /// <summary>
    /// An info code indicating the subscription event that occurred.
    /// See [InfoCode](#type-infocode) for possible values
    /// </summary>
    [JsonPropertyName("code")]
    public SubscriptionEventInfoCode? Code { get; set; }

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
