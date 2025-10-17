using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the gift card and the customer ID associated with a
/// `gift_card.customer_linked` event.
/// </summary>
[Serializable]
public record GiftCardCustomerUnlinkedEventObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The gift card with the updated `customer_ids` field.
    /// The field is removed if the gift card is not linked to any customers.
    /// </summary>
    [JsonPropertyName("gift_card")]
    public GiftCard? GiftCard { get; set; }

    /// <summary>
    /// The ID of the unlinked [customer](entity:Customer).
    /// </summary>
    [JsonPropertyName("unlinked_customer_id")]
    public string? UnlinkedCustomerId { get; set; }

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
