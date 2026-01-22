using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a Square gift card.
/// </summary>
[Serializable]
public record GiftCard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square-assigned ID of the gift card.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The gift card type.
    /// See [Type](#type-type) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required GiftCardType Type { get; set; }

    /// <summary>
    /// The source that generated the gift card account number (GAN). The default value is `SQUARE`.
    /// See [GANSource](#type-gansource) for possible values
    /// </summary>
    [JsonPropertyName("gan_source")]
    public GiftCardGanSource? GanSource { get; set; }

    /// <summary>
    /// The current gift card state.
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public GiftCardStatus? State { get; set; }

    /// <summary>
    /// The current gift card balance. This balance is always greater than or equal to zero.
    /// </summary>
    [JsonPropertyName("balance_money")]
    public Money? BalanceMoney { get; set; }

    /// <summary>
    /// The gift card account number (GAN). Buyers can use the GAN to make purchases or check
    /// the gift card balance.
    /// </summary>
    [JsonPropertyName("gan")]
    public string? Gan { get; set; }

    /// <summary>
    /// The timestamp when the gift card was created, in RFC 3339 format.
    /// In the case of a digital gift card, it is the time when you create a card
    /// (using the Square Point of Sale application, Seller Dashboard, or Gift Cards API).
    /// In the case of a plastic gift card, it is the time when Square associates the card with the
    /// seller at the time of activation.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The IDs of the [customer profiles](entity:Customer) to whom this gift card is linked.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

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
