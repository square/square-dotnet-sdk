using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes query criteria for searching invoices.
/// </summary>
[Serializable]
public record InvoiceQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Query filters to apply in searching invoices.
    /// For more information, see [Search for invoices](https://developer.squareup.com/docs/invoices-api/retrieve-list-search-invoices#search-invoices).
    /// </summary>
    [JsonPropertyName("filter")]
    public required InvoiceFilter Filter { get; set; }

    /// <summary>
    /// Describes the sort order for the search result.
    /// </summary>
    [JsonPropertyName("sort")]
    public InvoiceSort? Sort { get; set; }

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
