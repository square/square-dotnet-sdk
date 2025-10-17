using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CreateBookingCustomAttributeDefinition](api-endpoint:BookingCustomAttributes-CreateBookingCustomAttributeDefinition) response.
/// Either `custom_attribute_definition` or `errors` is present in the response.
/// </summary>
[Serializable]
public record CreateBookingCustomAttributeDefinitionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The newly created custom attribute definition.
    /// </summary>
    [JsonPropertyName("custom_attribute_definition")]
    public CustomAttributeDefinition? CustomAttributeDefinition { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
