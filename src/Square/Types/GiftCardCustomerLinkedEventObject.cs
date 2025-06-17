using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the gift card and customer ID associated with a
/// `gift_card.customer_linked` event.
/// </summary>
public record GiftCardCustomerLinkedEventObject
{
    /// <summary>
    /// The gift card with the updated `customer_ids` field.
    /// </summary>
    [JsonPropertyName("gift_card")]
    public GiftCard? GiftCard { get; set; }

    /// <summary>
    /// The ID of the linked [customer](entity:Customer).
    /// </summary>
    [JsonPropertyName("linked_customer_id")]
    public string? LinkedCustomerId { get; set; }

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
