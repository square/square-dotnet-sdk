using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response for an individual upsert request in a [BulkUpsertMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkUpsertMerchantCustomAttributes) operation.
/// </summary>
public record BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse
{
    /// <summary>
    /// The ID of the merchant associated with the custom attribute.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The new or updated custom attribute.
    /// </summary>
    [JsonPropertyName("custom_attribute")]
    public CustomAttribute? CustomAttribute { get; set; }

    /// <summary>
    /// Any errors that occurred while processing the individual request.
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
