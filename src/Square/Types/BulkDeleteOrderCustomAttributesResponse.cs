using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from deleting one or more order custom attributes.
/// </summary>
public record BulkDeleteOrderCustomAttributesResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A map of responses that correspond to individual delete requests. Each response has the same ID
    /// as the corresponding request and contains either a `custom_attribute` or an `errors` field.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, DeleteOrderCustomAttributeResponse> Values { get; set; } =
        new Dictionary<string, DeleteOrderCustomAttributeResponse>();

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
