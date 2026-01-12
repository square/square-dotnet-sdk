using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The custom attribute filters in a set of [customer filters](entity:CustomerFilter) used in a search query. Use this filter
/// to search based on [custom attributes](entity:CustomAttribute) that are assigned to customer profiles. For more information, see
/// [Search by custom attribute](https://developer.squareup.com/docs/customers-api/use-the-api/search-customers#search-by-custom-attribute).
/// </summary>
[Serializable]
public record CustomerCustomAttributeFilters : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The custom attribute filters. Each filter must specify `key` and include the `filter` field with a type-specific filter,
    /// the `updated_at` field, or both. The provided keys must be unique within the list of custom attribute filters.
    /// </summary>
    [JsonPropertyName("filters")]
    public IEnumerable<CustomerCustomAttributeFilter>? Filters { get; set; }

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
