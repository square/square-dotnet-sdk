using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Orders.CustomAttributes;

[Serializable]
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
