using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a response from a bulk upsert of order custom attributes.
/// </summary>
[Serializable]
public record BulkUpsertOrderCustomAttributesResponse : IJsonOnDeserialized
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
    /// A map of responses that correspond to individual upsert operations for custom attributes.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, UpsertOrderCustomAttributeResponse> Values { get; set; } =
        new Dictionary<string, UpsertOrderCustomAttributeResponse>();

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
