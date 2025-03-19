using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response that contains a `GiftCard` object. If the request resulted in errors,
/// the response contains a set of `Error` objects.
/// </summary>
public record GetGiftCardFromNonceResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The retrieved gift card.
    /// </summary>
    [JsonPropertyName("gift_card")]
    public GiftCard? GiftCard { get; set; }

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
