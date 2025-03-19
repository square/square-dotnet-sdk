using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to retrieve payout records entries.
/// </summary>
public record ListPayoutsResponse
{
    /// <summary>
    /// The requested list of payouts.
    /// </summary>
    [JsonPropertyName("payouts")]
    public IEnumerable<Payout>? Payouts { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If empty, this is the final response.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
