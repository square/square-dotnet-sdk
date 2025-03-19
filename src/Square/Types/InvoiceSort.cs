using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Identifies the sort field and sort order.
/// </summary>
public record InvoiceSort
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
