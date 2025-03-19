using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response that contains loyalty events that satisfy the search
/// criteria, in order by the `created_at` date.
/// </summary>
public record SearchLoyaltyEventsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The loyalty events that satisfy the search criteria.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<LoyaltyEvent>? Events { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent
    /// request. If empty, this is the final response.
    /// For more information,
    /// see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
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
