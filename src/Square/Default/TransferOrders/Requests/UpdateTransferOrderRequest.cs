using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record UpdateTransferOrderRequest
{
    /// <summary>
    /// The ID of the transfer order to update
    /// </summary>
    [JsonIgnore]
    public required string TransferOrderId { get; set; }

    /// <summary>
    /// A unique string that identifies this UpdateTransferOrder request. Keys must contain only alphanumeric characters, dashes and underscores
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The transfer order updates to apply
    /// </summary>
    [JsonPropertyName("transfer_order")]
    public required UpdateTransferOrderData TransferOrder { get; set; }

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
