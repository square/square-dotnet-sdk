using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record GetTransferOrdersRequest
{
    /// <summary>
    /// The ID of the transfer order to retrieve
    /// </summary>
    [JsonIgnore]
    public required string TransferOrderId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
