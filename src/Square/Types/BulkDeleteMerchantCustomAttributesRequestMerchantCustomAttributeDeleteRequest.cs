using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an individual delete request in a [BulkDeleteMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkDeleteMerchantCustomAttributes)
/// request. An individual request contains an optional ID of the associated custom attribute definition
/// and optional key of the associated custom attribute definition.
/// </summary>
public record BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
{
    /// <summary>
    /// The key of the associated custom attribute definition.
    /// Represented as a qualified key if the requesting app is not the definition owner.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
