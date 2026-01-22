using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines a sorter used to sort results from [SearchVendors](api-endpoint:Vendors-SearchVendors).
/// </summary>
[Serializable]
public record SearchVendorsRequestSort : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Specifies the sort key to sort the returned vendors.
    /// See [Field](#type-field) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public SearchVendorsRequestSortField? Field { get; set; }

    /// <summary>
    /// Specifies the sort order for the returned vendors.
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
