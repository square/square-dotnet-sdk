using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains the details necessary to fulfill a shipment order.
/// </summary>
public record FulfillmentShipmentDetails
{
    /// <summary>
    /// Information about the person to receive this shipment fulfillment.
    /// </summary>
    [JsonPropertyName("recipient")]
    public FulfillmentRecipient? Recipient { get; set; }

    /// <summary>
    /// The shipping carrier being used to ship this fulfillment (such as UPS, FedEx, or USPS).
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    /// <summary>
    /// A note with additional information for the shipping carrier.
    /// </summary>
    [JsonPropertyName("shipping_note")]
    public string? ShippingNote { get; set; }

    /// <summary>
    /// A description of the type of shipping product purchased from the carrier
    /// (such as First Class, Priority, or Express).
    /// </summary>
    [JsonPropertyName("shipping_type")]
    public string? ShippingType { get; set; }

    /// <summary>
    /// The reference number provided by the carrier to track the shipment's progress.
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// A link to the tracking webpage on the carrier's website.
    /// </summary>
    [JsonPropertyName("tracking_url")]
    public string? TrackingUrl { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the shipment was requested. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("placed_at")]
    public string? PlacedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when this fulfillment was moved to the `RESERVED` state, which  indicates that preparation
    /// of this shipment has begun. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("in_progress_at")]
    public string? InProgressAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when this fulfillment was moved to the `PREPARED` state, which indicates that the
    /// fulfillment is packaged. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("packaged_at")]
    public string? PackagedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the shipment is expected to be delivered to the shipping carrier.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("expected_shipped_at")]
    public string? ExpectedShippedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when this fulfillment was moved to the `COMPLETED` state, which indicates that
    /// the fulfillment has been given to the shipping carrier. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("shipped_at")]
    public string? ShippedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating the shipment was canceled.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

    /// <summary>
    /// A description of why the shipment was canceled.
    /// </summary>
    [JsonPropertyName("cancel_reason")]
    public string? CancelReason { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the shipment failed to be completed. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("failed_at")]
    public string? FailedAt { get; set; }

    /// <summary>
    /// A description of why the shipment failed to be completed.
    /// </summary>
    [JsonPropertyName("failure_reason")]
    public string? FailureReason { get; set; }

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
