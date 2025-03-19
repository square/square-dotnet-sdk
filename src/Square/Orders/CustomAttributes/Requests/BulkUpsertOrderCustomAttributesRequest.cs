using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Orders.CustomAttributes;

public record BulkUpsertOrderCustomAttributesRequest
{
    /// <summary>
    /// A map of requests that correspond to individual upsert operations for custom attributes.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
    > Values { get; set; } =
        new Dictionary<string, BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
