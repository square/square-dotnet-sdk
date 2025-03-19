using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines output parameters in a response from the
/// [SearchSubscriptions](api-endpoint:Subscriptions-SearchSubscriptions) endpoint.
/// </summary>
public record SearchSubscriptionsResponse
{
    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The subscriptions matching the specified query expressions.
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IEnumerable<Subscription>? Subscriptions { get; set; }

    /// <summary>
    /// When the total number of resulting subscription exceeds the limit of a paged response,
    /// the response includes a cursor for you to use in a subsequent request to fetch the next set of results.
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
