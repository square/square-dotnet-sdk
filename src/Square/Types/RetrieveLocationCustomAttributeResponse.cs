using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [RetrieveLocationCustomAttribute](api-endpoint:LocationCustomAttributes-RetrieveLocationCustomAttribute) response.
/// Either `custom_attribute_definition` or `errors` is present in the response.
/// </summary>
public record RetrieveLocationCustomAttributeResponse
{
    /// <summary>
    /// The retrieved custom attribute. If `with_definition` was set to `true` in the request,
    /// the custom attribute definition is returned in the `definition` field.
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
