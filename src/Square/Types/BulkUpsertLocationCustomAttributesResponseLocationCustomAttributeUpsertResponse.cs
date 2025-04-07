using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response for an individual upsert request in a [BulkUpsertLocationCustomAttributes](api-endpoint:LocationCustomAttributes-BulkUpsertLocationCustomAttributes) operation.
/// </summary>
public record BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse
{
    /// <summary>
    /// The ID of the location associated with the custom attribute.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

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
