using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [BulkCreateVendors](api-endpoint:Vendors-BulkCreateVendors).
/// </summary>
public record BatchCreateVendorsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A set of [CreateVendorResponse](entity:CreateVendorResponse) objects encapsulating successfully created [Vendor](entity:Vendor)
    /// objects or error responses for failed attempts. The set is represented by
    /// a collection of idempotency-key/`Vendor`-object or idempotency-key/error-object pairs. The idempotency keys correspond to those specified
    /// in the input.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, CreateVendorResponse>? Responses { get; set; }

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
