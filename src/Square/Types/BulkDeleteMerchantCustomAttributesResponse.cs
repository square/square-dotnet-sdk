using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [BulkDeleteMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkDeleteMerchantCustomAttributes) response,
/// which contains a map of responses that each corresponds to an individual delete request.
/// </summary>
public record BulkDeleteMerchantCustomAttributesResponse
{
    /// <summary>
    /// A map of responses that correspond to individual delete requests. Each response has the
    /// same key as the corresponding request.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
    > Values { get; set; } =
        new Dictionary<
            string,
            BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
        >();

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
