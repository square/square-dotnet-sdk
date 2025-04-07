using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes query criteria for searching invoices.
/// </summary>
public record InvoiceQuery
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
