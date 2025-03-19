using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Catalog;

public record UpdateItemTaxesRequest
{
    /// <summary>
    /// IDs for the CatalogItems associated with the CatalogTax objects being updated.
    /// No more than 1,000 IDs may be provided.
    /// </summary>
    [JsonPropertyName("item_ids")]
    public IEnumerable<string> ItemIds { get; set; } = new List<string>();

    /// <summary>
    /// IDs of the CatalogTax objects to enable.
    /// At least one of `taxes_to_enable` or `taxes_to_disable` must be specified.
    /// </summary>
    [JsonPropertyName("taxes_to_enable")]
    public IEnumerable<string>? TaxesToEnable { get; set; }

    /// <summary>
    /// IDs of the CatalogTax objects to disable.
    /// At least one of `taxes_to_enable` or `taxes_to_disable` must be specified.
    /// </summary>
    [JsonPropertyName("taxes_to_disable")]
    public IEnumerable<string>? TaxesToDisable { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
