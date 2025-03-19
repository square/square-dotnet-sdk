using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes delivery details of an order fulfillment.
/// </summary>
public record FulfillmentDeliveryDetails
{
    /// <summary>
    /// The contact information for the person to receive the fulfillment.
    /// </summary>
    [JsonPropertyName("recipient")]
    public FulfillmentRecipient? Recipient { get; set; }

    /// <summary>
    /// Indicates the fulfillment delivery schedule type. If `SCHEDULED`, then
    /// `deliver_at` is required. If `ASAP`, then `prep_time_duration` is required. The default is `SCHEDULED`.
    /// See [OrderFulfillmentDeliveryDetailsScheduleType](#type-orderfulfillmentdeliverydetailsscheduletype) for possible values
    /// </summary>
    [JsonPropertyName("schedule_type")]
    public FulfillmentDeliveryDetailsOrderFulfillmentDeliveryDetailsScheduleType? ScheduleType { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was placed.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    ///
    /// Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("placed_at")]
    public string? PlacedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// that represents the start of the delivery period.
    /// When the fulfillment `schedule_type` is `ASAP`, the field is automatically
    /// set to the current time plus the `prep_time_duration`.
    /// Otherwise, the application can set this field while the fulfillment `state` is
    /// `PROPOSED`, `RESERVED`, or `PREPARED` (any time before the
    /// terminal state such as `COMPLETED`, `CANCELED`, and `FAILED`).
    ///
    /// The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("deliver_at")]
    public string? DeliverAt { get; set; }

    /// <summary>
    /// The duration of time it takes to prepare and deliver this fulfillment.
    /// The duration must be in RFC 3339 format (for example, "P1W3D").
    /// </summary>
    [JsonPropertyName("prep_time_duration")]
    public string? PrepTimeDuration { get; set; }

    /// <summary>
    /// The time period after `deliver_at` in which to deliver the order.
    /// Applications can set this field when the fulfillment `state` is
    /// `PROPOSED`, `RESERVED`, or `PREPARED` (any time before the terminal state
    /// such as `COMPLETED`, `CANCELED`, and `FAILED`).
    ///
    /// The duration must be in RFC 3339 format (for example, "P1W3D").
    /// </summary>
    [JsonPropertyName("delivery_window_duration")]
    public string? DeliveryWindowDuration { get; set; }

    /// <summary>
    /// Provides additional instructions about the delivery fulfillment.
    /// It is displayed in the Square Point of Sale application and set by the API.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicates when the seller completed the fulfillment.
    /// This field is automatically set when  fulfillment `state` changes to `COMPLETED`.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicates when the seller started processing the fulfillment.
    /// This field is automatically set when the fulfillment `state` changes to `RESERVED`.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("in_progress_at")]
    public string? InProgressAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was rejected. This field is
    /// automatically set when the fulfillment `state` changes to `FAILED`.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("rejected_at")]
    public string? RejectedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the seller marked the fulfillment as ready for
    /// courier pickup. This field is automatically set when the fulfillment `state` changes
    /// to PREPARED.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("ready_at")]
    public string? ReadyAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was delivered to the recipient.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("delivered_at")]
    public string? DeliveredAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was canceled. This field is automatically
    /// set when the fulfillment `state` changes to `CANCELED`.
    ///
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

    /// <summary>
    /// The delivery cancellation reason. Max length: 100 characters.
    /// </summary>
    [JsonPropertyName("cancel_reason")]
    public string? CancelReason { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when an order can be picked up by the courier for delivery.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("courier_pickup_at")]
    public string? CourierPickupAt { get; set; }

    /// <summary>
    /// The time period after `courier_pickup_at` in which the courier should pick up the order.
    /// The duration must be in RFC 3339 format (for example, "P1W3D").
    /// </summary>
    [JsonPropertyName("courier_pickup_window_duration")]
    public string? CourierPickupWindowDuration { get; set; }

    /// <summary>
    /// Whether the delivery is preferred to be no contact.
    /// </summary>
    [JsonPropertyName("is_no_contact_delivery")]
    public bool? IsNoContactDelivery { get; set; }

    /// <summary>
    /// A note to provide additional instructions about how to deliver the order.
    /// </summary>
    [JsonPropertyName("dropoff_notes")]
    public string? DropoffNotes { get; set; }

    /// <summary>
    /// The name of the courier provider.
    /// </summary>
    [JsonPropertyName("courier_provider_name")]
    public string? CourierProviderName { get; set; }

    /// <summary>
    /// The support phone number of the courier.
    /// </summary>
    [JsonPropertyName("courier_support_phone_number")]
    public string? CourierSupportPhoneNumber { get; set; }

    /// <summary>
    /// The identifier for the delivery created by Square.
    /// </summary>
    [JsonPropertyName("square_delivery_id")]
    public string? SquareDeliveryId { get; set; }

    /// <summary>
    /// The identifier for the delivery created by the third-party courier service.
    /// </summary>
    [JsonPropertyName("external_delivery_id")]
    public string? ExternalDeliveryId { get; set; }

    /// <summary>
    /// The flag to indicate the delivery is managed by a third party (ie DoorDash), which means
    /// we may not receive all recipient information for PII purposes.
    /// </summary>
    [JsonPropertyName("managed_delivery")]
    public bool? ManagedDelivery { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
