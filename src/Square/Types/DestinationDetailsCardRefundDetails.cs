using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record DestinationDetailsCardRefundDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
