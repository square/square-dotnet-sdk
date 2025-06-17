using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Published when a [customer](entity:Customer) is deleted.  For more information, see [Use Customer Webhooks](https://developer.squareup.com/docs/customers-api/use-the-api/customer-webhooks).
///
/// The `customer` object in the event notification does not include the following fields: `group_ids` and `segment_ids`.
/// </summary>
public record CustomerDeletedEvent
{
    /// <summary>
    /// The ID of the seller associated with the event.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The type of event. For this object, the value is `customer.deleted`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The unique ID of the event, which is used for [idempotency support](https://developer.squareup.com/docs/webhooks/step4manage#webhooks-best-practices).
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
    public CustomerDeletedEventData? Data { get; set; }

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
