using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a response from listing order custom attribute definitions.
/// </summary>
[Serializable]
public record ListOrderCustomAttributeDefinitionsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The retrieved custom attribute definitions. If no custom attribute definitions are found, Square returns an empty object (`{}`).
    /// </summary>
    [JsonPropertyName("custom_attribute_definitions")]
    public IEnumerable<CustomAttributeDefinition> CustomAttributeDefinitions { get; set; } =
        new List<CustomAttributeDefinition>();

    /// <summary>
    /// The cursor to provide in your next call to this endpoint to retrieve the next page of results for your original request.
    /// This field is present only if the request succeeded and additional results are available.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
