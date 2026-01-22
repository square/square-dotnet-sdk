using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CreateTransferOrderRequest
{
    /// <summary>
    /// A unique string that identifies this CreateTransferOrder request. Keys can be
    /// any valid string but must be unique for every CreateTransferOrder request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The transfer order to create
    /// </summary>
    [JsonPropertyName("transfer_order")]
    public required CreateTransferOrderData TransferOrder { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
