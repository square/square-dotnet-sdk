using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an [UpdateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-UpdateCustomerCustomAttributeDefinition) response.
/// Either `custom_attribute_definition` or `errors` is present in the response.
/// </summary>
public record UpdateCustomerCustomAttributeDefinitionResponse
{
    /// <summary>
    /// The updated custom attribute definition.
    /// </summary>
    [JsonPropertyName("custom_attribute_definition")]
    public CustomAttributeDefinition? CustomAttributeDefinition { get; set; }

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
