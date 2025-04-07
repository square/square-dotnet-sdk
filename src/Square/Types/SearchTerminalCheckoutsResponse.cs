using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record SearchTerminalCheckoutsResponse
{
    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested search result of `TerminalCheckout` objects.
    /// </summary>
    [JsonPropertyName("checkouts")]
    public IEnumerable<TerminalCheckout>? Checkouts { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If empty,
    /// this is the final response.
    ///
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
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
