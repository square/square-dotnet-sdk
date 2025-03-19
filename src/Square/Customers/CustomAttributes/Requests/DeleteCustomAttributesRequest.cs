using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.CustomAttributes;

public record DeleteCustomAttributesRequest
{
    /// <summary>
    /// The ID of the target [customer profile](entity:Customer).
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The key of the custom attribute to delete. This key must match the `key` of a custom
    /// attribute definition in the Square seller account. If the requesting application is not the
    /// definition owner, you must use the qualified key.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
