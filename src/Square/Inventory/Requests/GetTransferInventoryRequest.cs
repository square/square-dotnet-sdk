using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Inventory;

[Serializable]
public record GetTransferInventoryRequest
{
    [JsonIgnore]
    public required string TransferId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
