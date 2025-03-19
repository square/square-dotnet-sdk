using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Orders;

public record GetOrdersRequest
{
    /// <summary>
    /// The ID of the order to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
