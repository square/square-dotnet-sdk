using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record ReceiveTransferOrderRequest
{
    /// <summary>
    /// The ID of the transfer order to receive items for
    /// </summary>
    [JsonIgnore]
    public required string TransferOrderId { get; set; }

    /// <summary>
    /// A unique key to make this request idempotent
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The receipt details
    /// </summary>
    [JsonPropertyName("receipt")]
    public required TransferOrderGoodsReceipt Receipt { get; set; }

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
