using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Options to include related resources of the requested `CatalogObject`s. Related resources will be included in
/// `IncludedResources` in the response.
/// </summary>
[Serializable]
public record IncludeOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Resources to include in the response.
    /// See [IncludeType](#type-includetype) for possible values
    /// </summary>
    [JsonPropertyName("include")]
    public IEnumerable<IncludeType>? Include { get; set; }

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
