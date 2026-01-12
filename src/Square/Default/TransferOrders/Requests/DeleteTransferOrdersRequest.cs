using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.TransferOrders;

[Serializable]
public record DeleteTransferOrdersRequest
{
    /// <summary>
    /// The ID of the transfer order to delete
    /// </summary>
    [JsonIgnore]
    public required string TransferOrderId { get; set; }

    /// <summary>
    /// Version for optimistic concurrency
    /// </summary>
    [JsonIgnore]
    public long? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
