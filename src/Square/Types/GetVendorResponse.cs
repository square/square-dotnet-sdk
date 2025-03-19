using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [RetrieveVendor](api-endpoint:Vendors-RetrieveVendor).
/// </summary>
public record GetVendorResponse
{
    /// <summary>
    /// Errors encountered when the request fails.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The successfully retrieved [Vendor](entity:Vendor) object.
    /// </summary>
    [JsonPropertyName("vendor")]
    public Vendor? Vendor { get; set; }

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
