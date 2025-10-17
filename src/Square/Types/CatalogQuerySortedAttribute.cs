using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query expression to specify the key to sort search results.
/// </summary>
[Serializable]
public record CatalogQuerySortedAttribute : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The attribute whose value is used as the sort key.
    /// </summary>
    [JsonPropertyName("attribute_name")]
    public required string AttributeName { get; set; }

    /// <summary>
    /// The first attribute value to be returned by the query. Ascending sorts will return only
    /// objects with this value or greater, while descending sorts will return only objects with this value
    /// or less. If unset, start at the beginning (for ascending sorts) or end (for descending sorts).
    /// </summary>
    [JsonPropertyName("initial_attribute_value")]
    public string? InitialAttributeValue { get; set; }

    /// <summary>
    /// The desired sort order, `"ASC"` (ascending) or `"DESC"` (descending).
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("sort_order")]
    public SortOrder? SortOrder { get; set; }

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
