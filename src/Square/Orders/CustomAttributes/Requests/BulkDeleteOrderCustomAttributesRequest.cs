using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Orders.CustomAttributes;

public record BulkDeleteOrderCustomAttributesRequest
{
    /// <summary>
    /// A map of requests that correspond to individual delete operations for custom attributes.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
    > Values { get; set; } =
        new Dictionary<string, BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
