using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from getting an order custom attribute.
/// </summary>
public record RetrieveOrderCustomAttributeResponse
{
    /// <summary>
    /// The retrieved custom attribute. If `with_definition` was set to `true` in the request, the custom attribute definition is returned in the `definition field.
    /// </summary>
    [JsonPropertyName("custom_attribute")]
    public CustomAttribute? CustomAttribute { get; set; }

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
