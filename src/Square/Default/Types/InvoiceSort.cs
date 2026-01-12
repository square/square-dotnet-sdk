using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Identifies the sort field and sort order.
/// </summary>
[Serializable]
public record InvoiceSort : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The field to use for sorting.
    /// See [InvoiceSortField](#type-invoicesortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public string Field { get; set; } = "INVOICE_SORT_DATE";

    /// <summary>
    /// The order to use for sorting the results.
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
