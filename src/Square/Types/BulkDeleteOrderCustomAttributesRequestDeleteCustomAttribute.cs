using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents one delete within the bulk operation.
/// </summary>
[Serializable]
public record BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
