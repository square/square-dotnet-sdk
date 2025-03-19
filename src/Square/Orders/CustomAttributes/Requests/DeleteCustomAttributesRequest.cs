using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Orders.CustomAttributes;

public record DeleteCustomAttributesRequest
{
    /// <summary>
    /// The ID of the target [order](entity:Order).
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <summary>
    /// The key of the custom attribute to delete.  This key must match the key of an
    /// existing custom attribute definition.
    /// </summary>
    [JsonIgnore]
    public required string CustomAttributeKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
