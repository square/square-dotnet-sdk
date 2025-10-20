using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Sets the sort order of search results.
/// </summary>
[Serializable]
public record TimecardSort : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The field to sort on.
    /// See [TimecardSortField](#type-timecardsortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public TimecardSortField? Field { get; set; }

    /// <summary>
    /// The order in which results are returned. Defaults to DESC.
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("order")]
    public SortOrder? Order { get; set; }

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
