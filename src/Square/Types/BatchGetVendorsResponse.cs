using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [BulkRetrieveVendors](api-endpoint:Vendors-BulkRetrieveVendors).
/// </summary>
public record BatchGetVendorsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The set of [RetrieveVendorResponse](entity:RetrieveVendorResponse) objects encapsulating successfully retrieved [Vendor](entity:Vendor)
    /// objects or error responses for failed attempts. The set is represented by
    /// a collection of `Vendor`-ID/`Vendor`-object or `Vendor`-ID/error-object pairs.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, GetVendorResponse>? Responses { get; set; }

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
