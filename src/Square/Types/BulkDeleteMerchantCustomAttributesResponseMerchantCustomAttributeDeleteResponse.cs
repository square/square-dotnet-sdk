using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an individual delete response in a [BulkDeleteMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkDeleteMerchantCustomAttributes)
/// request.
/// </summary>
public record BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
{
    /// <summary>
    /// Errors that occurred while processing the individual MerchantCustomAttributeDeleteRequest request
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
