using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the gift card and the customer ID associated with a
/// `gift_card.customer_linked` event.
/// </summary>
public record GiftCardCustomerUnlinkedEventObject
{
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
