using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`
/// </summary>
public record TenderCardDetails
{
    /// <summary>
    /// The credit card payment's current state (such as `AUTHORIZED` or
    /// `CAPTURED`). See [TenderCardDetailsStatus](entity:TenderCardDetailsStatus)
    /// for possible values.
    /// See [TenderCardDetailsStatus](#type-tendercarddetailsstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TenderCardDetailsStatus? Status { get; set; }

    /// <summary>
    /// The credit card's non-confidential details.
    /// </summary>
    [JsonPropertyName("card")]
    public Card? Card { get; set; }

    /// <summary>
    /// The method used to enter the card's details for the transaction.
    /// See [TenderCardDetailsEntryMethod](#type-tendercarddetailsentrymethod) for possible values
    /// </summary>
    [JsonPropertyName("entry_method")]
    public TenderCardDetailsEntryMethod? EntryMethod { get; set; }

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
