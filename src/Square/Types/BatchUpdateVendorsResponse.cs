using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [BulkUpdateVendors](api-endpoint:Vendors-BulkUpdateVendors).
/// </summary>
public record BatchUpdateVendorsResponse
{
    /// <summary>
    /// Errors encountered when the request fails.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A set of [UpdateVendorResponse](entity:UpdateVendorResponse) objects encapsulating successfully created [Vendor](entity:Vendor)
    /// objects or error responses for failed attempts. The set is represented by a collection of `Vendor`-ID/`UpdateVendorResponse`-object or
    /// `Vendor`-ID/error-object pairs.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, UpdateVendorResponse>? Responses { get; set; }

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
