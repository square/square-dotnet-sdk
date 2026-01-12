using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The range of a number value between the specified lower and upper bounds.
/// </summary>
[Serializable]
public record Range : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The lower bound of the number range. At least one of `min` or `max` must be specified.
    /// If unspecified, the results will have no minimum value.
    /// </summary>
    [JsonPropertyName("min")]
    public string? Min { get; set; }

    /// <summary>
    /// The upper bound of the number range. At least one of `min` or `max` must be specified.
    /// If unspecified, the results will have no maximum value.
    /// </summary>
    [JsonPropertyName("max")]
    public string? Max { get; set; }

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
