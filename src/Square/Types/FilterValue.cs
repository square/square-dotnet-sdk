using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A filter to select resources based on an exact field value. For any given
/// value, the value can only be in one property. Depending on the field, either
/// all properties can be set or only a subset will be available.
///
/// Refer to the documentation of the field.
/// </summary>
[Serializable]
public record FilterValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of terms that must be present on the field of the resource.
    /// </summary>
    [JsonPropertyName("all")]
    public IEnumerable<string>? All { get; set; }

    /// <summary>
    /// A list of terms where at least one of them must be present on the
    /// field of the resource.
    /// </summary>
    [JsonPropertyName("any")]
    public IEnumerable<string>? Any { get; set; }

    /// <summary>
    /// A list of terms that must not be present on the field the resource
    /// </summary>
    [JsonPropertyName("none")]
    public IEnumerable<string>? None { get; set; }

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
