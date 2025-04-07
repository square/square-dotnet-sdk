using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response that contains a list of `GiftCard` objects. If the request resulted in errors,
/// the response contains a set of `Error` objects.
/// </summary>
public record ListGiftCardsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested gift cards or an empty object if none are found.
    /// </summary>
    [JsonPropertyName("gift_cards")]
    public IEnumerable<GiftCard>? GiftCards { get; set; }

    /// <summary>
    /// When a response is truncated, it includes a cursor that you can use in a
    /// subsequent request to retrieve the next set of gift cards. If a cursor is not present, this is
    /// the final response.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
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
