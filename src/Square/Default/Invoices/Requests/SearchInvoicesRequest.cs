using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record SearchInvoicesRequest
{
    /// <summary>
    /// Describes the query criteria for searching invoices.
    /// </summary>
    [JsonPropertyName("query")]
    public required InvoiceQuery Query { get; set; }

    /// <summary>
    /// The maximum number of invoices to return (200 is the maximum `limit`).
    /// If not provided, the server uses a default limit of 100 invoices.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for your original query.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
