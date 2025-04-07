using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListWebhookSubscriptions](api-endpoint:WebhookSubscriptions-ListWebhookSubscriptions) endpoint.
///
/// Note: if there are errors processing the request, the subscriptions field will not be
/// present.
/// </summary>
public record ListWebhookSubscriptionsResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested list of [Subscription](entity:WebhookSubscription)s.
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IEnumerable<WebhookSubscription>? Subscriptions { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If empty,
    /// this is the final response.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
