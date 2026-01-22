using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the sorting criteria in a [search query](entity:CustomerQuery) that defines how to sort
/// customer profiles returned in [SearchCustomers](api-endpoint:Customers-SearchCustomers) results.
/// </summary>
[Serializable]
public record CustomerSort : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates the fields to use as the sort key, which is either the default set of fields or `created_at`.
    ///
    /// The default value is `DEFAULT`.
    /// See [CustomerSortField](#type-customersortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public CustomerSortField? Field { get; set; }

    /// <summary>
    /// Indicates the order in which results should be sorted based on the
    /// sort field value. Strings use standard alphabetic comparison
    /// to determine order. Strings representing numbers are sorted as strings.
    ///
    /// The default value is `ASC`.
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
