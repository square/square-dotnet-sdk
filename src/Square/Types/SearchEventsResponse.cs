using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [SearchEvents](api-endpoint:Events-SearchEvents) endpoint.
///
/// Note: if there are errors processing the request, the events field will not be
/// present.
/// </summary>
public record SearchEventsResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The list of [Event](entity:Event)s returned by the search.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<Event>? Events { get; set; }

    /// <summary>
    /// Contains the metadata of an event. For more information, see [Event](entity:Event).
    /// </summary>
    [JsonPropertyName("metadata")]
    public IEnumerable<EventMetadata>? Metadata { get; set; }

    /// <summary>
    /// When a response is truncated, it includes a cursor that you can use in a subsequent request to fetch the next set of events. If empty, this is the final response.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
