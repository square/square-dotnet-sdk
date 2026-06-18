using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Columnar data format - members list paired with one primitive array per column. Returned when `responseFormat=columnar` is requested.
/// </summary>
[Serializable]
public record LoadResultDataColumnar : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Ordered list of member names. Element `i` of `columns` holds the values for `members[i]` across all rows.
    /// </summary>
    [JsonPropertyName("members")]
    public IEnumerable<string> Members { get; set; } = new List<string>();

    /// <summary>
    /// One array per member, in the same order as `members`. Each inner array contains the primitive value of that member for every row (null, boolean, number, string).
    /// </summary>
    [JsonPropertyName("columns")]
    public IEnumerable<IEnumerable<object>> Columns { get; set; } = new List<IEnumerable<object>>();

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
