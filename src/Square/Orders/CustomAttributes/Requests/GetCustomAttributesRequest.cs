using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Orders.CustomAttributes;

public record GetCustomAttributesRequest
{
    /// <summary>
    /// The ID of the target [order](entity:Order).
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <summary>
    /// The key of the custom attribute to retrieve.  This key must match the key of an
    /// existing custom attribute definition.
    /// </summary>
    [JsonIgnore]
    public required string CustomAttributeKey { get; set; }

    /// <summary>
    /// To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control, include this optional field and specify the current version of the custom attribute.
    /// </summary>
    [JsonIgnore]
    public int? Version { get; set; }

    /// <summary>
    /// Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each
    /// custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,
    /// information about the data type, or other definition details. The default value is `false`.
    /// </summary>
    [JsonIgnore]
    public bool? WithDefinition { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
