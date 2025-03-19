using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines output parameters in a response from the
/// [ListSubscriptionEvents](api-endpoint:Subscriptions-ListSubscriptionEvents).
/// </summary>
public record ListSubscriptionEventsResponse
{
    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The retrieved subscription events.
    /// </summary>
    [JsonPropertyName("subscription_events")]
    public IEnumerable<SubscriptionEvent>? SubscriptionEvents { get; set; }

    /// <summary>
    /// When the total number of resulting subscription events exceeds the limit of a paged response,
    /// the response includes a cursor for you to use in a subsequent request to fetch the next set of events.
    /// If the cursor is unset, the response contains the last page of the results.
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
