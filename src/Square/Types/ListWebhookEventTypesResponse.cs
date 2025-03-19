using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListWebhookEventTypes](api-endpoint:WebhookSubscriptions-ListWebhookEventTypes) endpoint.
///
/// Note: if there are errors processing the request, the event types field will not be
/// present.
/// </summary>
public record ListWebhookEventTypesResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The list of event types.
    /// </summary>
    [JsonPropertyName("event_types")]
    public IEnumerable<string>? EventTypes { get; set; }

    /// <summary>
    /// Contains the metadata of a webhook event type. For more information, see [EventTypeMetadata](entity:EventTypeMetadata).
    /// </summary>
    [JsonPropertyName("metadata")]
    public IEnumerable<EventTypeMetadata>? Metadata { get; set; }

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
