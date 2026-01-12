using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListWebhookEventTypes](api-endpoint:WebhookSubscriptions-ListWebhookEventTypes) endpoint.
///
/// Note: if there are errors processing the request, the event types field will not be
/// present.
/// </summary>
[Serializable]
public record ListWebhookEventTypesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
