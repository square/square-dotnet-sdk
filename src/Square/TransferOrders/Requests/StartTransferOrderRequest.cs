using System.Text.Json.Serialization;
using Square.Core;

namespace Square.TransferOrders;

public record StartTransferOrderRequest
{
    /// <summary>
    /// The ID of the transfer order to start. Must be in DRAFT status.
    /// </summary>
    [JsonIgnore]
    public required string TransferOrderId { get; set; }

    /// <summary>
    /// A unique string that identifies this UpdateTransferOrder request. Keys can be
    /// any valid string but must be unique for every UpdateTransferOrder request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Version for optimistic concurrency
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
