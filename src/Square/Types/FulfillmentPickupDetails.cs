using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains details necessary to fulfill a pickup order.
/// </summary>
public record FulfillmentPickupDetails
{
    /// <summary>
    /// Information about the person to pick up this fulfillment from a physical
    /// location.
    /// </summary>
    [JsonPropertyName("recipient")]
    public FulfillmentRecipient? Recipient { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when this fulfillment expires if it is not marked in progress. The timestamp must be
    /// in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z"). The expiration time can only be set
    /// up to 7 days in the future. If `expires_at` is not set, any new payments attached to the order
    /// are automatically completed.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    /// <summary>
    /// The duration of time after which an in progress pickup fulfillment is automatically moved
    /// to the `COMPLETED` state. The duration must be in RFC 3339 format (for example, "P1W3D").
    ///
    /// If not set, this pickup fulfillment remains in progress until it is canceled or completed.
    /// </summary>
    [JsonPropertyName("auto_complete_duration")]
    public string? AutoCompleteDuration { get; set; }

    /// <summary>
    /// The schedule type of the pickup fulfillment. Defaults to `SCHEDULED`.
    /// See [FulfillmentPickupDetailsScheduleType](#type-fulfillmentpickupdetailsscheduletype) for possible values
    /// </summary>
    [JsonPropertyName("schedule_type")]
    public FulfillmentPickupDetailsScheduleType? ScheduleType { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// that represents the start of the pickup window. Must be in RFC 3339 timestamp format, e.g.,
    /// "2016-09-04T23:59:33.123Z".
    ///
    /// For fulfillments with the schedule type `ASAP`, this is automatically set
    /// to the current time plus the expected duration to prepare the fulfillment.
    /// </summary>
    [JsonPropertyName("pickup_at")]
    public string? PickupAt { get; set; }

    /// <summary>
    /// The window of time in which the order should be picked up after the `pickup_at` timestamp.
    /// Must be in RFC 3339 duration format, e.g., "P1W3D". Can be used as an
    /// informational guideline for merchants.
    /// </summary>
    [JsonPropertyName("pickup_window_duration")]
    public string? PickupWindowDuration { get; set; }

    /// <summary>
    /// The duration of time it takes to prepare this fulfillment.
    /// The duration must be in RFC 3339 format (for example, "P1W3D").
    /// </summary>
    [JsonPropertyName("prep_time_duration")]
    public string? PrepTimeDuration { get; set; }

    /// <summary>
    /// A note to provide additional instructions about the pickup
    /// fulfillment displayed in the Square Point of Sale application and set by the API.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was placed. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("placed_at")]
    public string? PlacedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was marked in progress. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("accepted_at")]
    public string? AcceptedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was rejected. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("rejected_at")]
    public string? RejectedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment is marked as ready for pickup. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("ready_at")]
    public string? ReadyAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment expired. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("expired_at")]
    public string? ExpiredAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was picked up by the recipient. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("picked_up_at")]
    public string? PickedUpAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was canceled. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

    /// <summary>
    /// A description of why the pickup was canceled. The maximum length: 100 characters.
    /// </summary>
    [JsonPropertyName("cancel_reason")]
    public string? CancelReason { get; set; }

    /// <summary>
    /// If set to `true`, indicates that this pickup order is for curbside pickup, not in-store pickup.
    /// </summary>
    [JsonPropertyName("is_curbside_pickup")]
    public bool? IsCurbsidePickup { get; set; }

    /// <summary>
    /// Specific details for curbside pickup. These details can only be populated if `is_curbside_pickup` is set to `true`.
    /// </summary>
    [JsonPropertyName("curbside_pickup_details")]
    public FulfillmentPickupDetailsCurbsidePickupDetails? CurbsidePickupDetails { get; set; }

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
