using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DestinationDetailsCardRefundDetails
{
    /// <summary>
    /// The card's non-confidential details.
    /// </summary>
    [JsonPropertyName("card")]
    public Card? Card { get; set; }

    /// <summary>
    /// The method used to enter the card's details for the refund. The method can be
    /// `KEYED`, `SWIPED`, `EMV`, `ON_FILE`, or `CONTACTLESS`.
    /// </summary>
    [JsonPropertyName("entry_method")]
    public string? EntryMethod { get; set; }

    /// <summary>
    /// The authorization code provided by the issuer when a refund is approved.
    /// </summary>
    [JsonPropertyName("auth_result_code")]
    public string? AuthResultCode { get; set; }

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
