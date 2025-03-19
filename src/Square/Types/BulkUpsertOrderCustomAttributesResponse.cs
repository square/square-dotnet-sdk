using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from a bulk upsert of order custom attributes.
/// </summary>
public record BulkUpsertOrderCustomAttributesResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A map of responses that correspond to individual upsert operations for custom attributes.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, UpsertOrderCustomAttributeResponse> Values { get; set; } =
        new Dictionary<string, UpsertOrderCustomAttributeResponse>();

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
