using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// An object that contains the gift card associated with a `gift_card.updated` event.
/// </summary>
[Serializable]
public record GiftCardUpdatedEventObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The gift card with the updated `balance_money`, `state`, or `customer_ids` field.
    /// Some events can affect both `balance_money` and `state`.
    /// </summary>
    [JsonPropertyName("gift_card")]
    public GiftCard? GiftCard { get; set; }

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
