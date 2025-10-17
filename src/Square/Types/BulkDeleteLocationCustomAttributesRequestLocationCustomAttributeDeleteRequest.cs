using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an individual delete request in a [BulkDeleteLocationCustomAttributes](api-endpoint:LocationCustomAttributes-BulkDeleteLocationCustomAttributes)
/// request. An individual request contains an optional ID of the associated custom attribute definition
/// and optional key of the associated custom attribute definition.
/// </summary>
[Serializable]
public record BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The key of the associated custom attribute definition.
    /// Represented as a qualified key if the requesting app is not the definition owner.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("key")]
    public string? Key { get; set; }

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
