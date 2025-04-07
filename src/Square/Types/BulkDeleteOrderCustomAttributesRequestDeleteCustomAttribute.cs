using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents one delete within the bulk operation.
/// </summary>
public record BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
{
    /// <summary>
    /// The key of the custom attribute to delete.  This key must match the key
    /// of an existing custom attribute definition.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The ID of the target [order](entity:Order).
    /// </summary>
    [JsonPropertyName("order_id")]
    public required string OrderId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
