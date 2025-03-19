using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public record ListPaymentLinksRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// If a cursor is not provided, the endpoint returns the first page of the results.
    /// For more  information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// A limit on the number of results to return per page. The limit is advisory and
    /// the implementation might return more or less results. If the supplied limit is negative, zero, or
    /// greater than the maximum limit of 1000, it is ignored.
    ///
    /// Default value: `100`
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
