using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record GetTransferInventoryRequest
{
    /// <summary>
    /// ID of the [InventoryTransfer](entity:InventoryTransfer) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string TransferId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
