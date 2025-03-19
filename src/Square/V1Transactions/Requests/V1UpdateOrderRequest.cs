using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.V1Transactions;

public record V1UpdateOrderRequest
{
    /// <summary>
    /// The ID of the order's associated location.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <summary>
    /// The action to perform on the order (COMPLETE, CANCEL, or REFUND).
    /// See [V1UpdateOrderRequestAction](#type-v1updateorderrequestaction) for possible values
    /// </summary>
    [JsonPropertyName("action")]
    public required V1UpdateOrderRequestAction Action { get; set; }

    /// <summary>
    /// The tracking number of the shipment associated with the order. Only valid if action is COMPLETE.
    /// </summary>
    [JsonPropertyName("shipped_tracking_number")]
    public string? ShippedTrackingNumber { get; set; }

    /// <summary>
    /// A merchant-specified note about the completion of the order. Only valid if action is COMPLETE.
    /// </summary>
    [JsonPropertyName("completed_note")]
    public string? CompletedNote { get; set; }

    /// <summary>
    /// A merchant-specified note about the refunding of the order. Only valid if action is REFUND.
    /// </summary>
    [JsonPropertyName("refunded_note")]
    public string? RefundedNote { get; set; }

    /// <summary>
    /// A merchant-specified note about the canceling of the order. Only valid if action is CANCEL.
    /// </summary>
    [JsonPropertyName("canceled_note")]
    public string? CanceledNote { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
