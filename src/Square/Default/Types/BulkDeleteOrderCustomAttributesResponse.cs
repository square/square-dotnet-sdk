using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a response from deleting one or more order custom attributes.
/// </summary>
[Serializable]
public record BulkDeleteOrderCustomAttributesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
