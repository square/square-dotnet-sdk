using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Orders;

[Serializable]
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
