using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Published when a [gift card activity](entity:GiftCardActivity) is updated.
/// Subscribe to this event to be notified about the following changes:
/// - An update to the `REDEEM` activity for a gift card redemption made from a Square product (such as Square Point of Sale).
/// These redemptions are initially assigned a `PENDING` state, but then change to a `COMPLETED` or `CANCELED` state.
/// - An update to the `IMPORT` activity for an imported gift card when the balance is later adjusted by Square.
/// </summary>
[Serializable]
public record GiftCardActivityUpdatedEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the Square seller associated with the event.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The type of event. For this event, the value is `gift_card.activity.updated`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The unique ID of the event, which is used for
    /// [idempotency support](https://developer.squareup.com/docs/webhooks/step4manage#webhooks-best-practices).
    /// </summary>
    [JsonPropertyName("event_id")]
    public string? EventId { get; set; }

    /// <summary>
    /// The timestamp of when the event was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The data associated with the event.
    /// </summary>
    [JsonPropertyName("data")]
    public GiftCardActivityUpdatedEventData? Data { get; set; }

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
