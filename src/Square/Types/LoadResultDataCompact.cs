using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Compact data format - a single object with the members list and a dataset of primitive arrays. Returned when `responseFormat=compact` is requested.
/// </summary>
[Serializable]
public record LoadResultDataCompact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Ordered list of member names that correspond to each cell position in `dataset` rows.
    /// </summary>
    [JsonPropertyName("members")]
    public IEnumerable<string> Members { get; set; } = new List<string>();

    /// <summary>
    /// Array of rows, where each row is an array of primitive values (null, boolean, number, string) aligned with `members`.
    /// </summary>
    [JsonPropertyName("dataset")]
    public IEnumerable<IEnumerable<object>> Dataset { get; set; } = new List<IEnumerable<object>>();

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
