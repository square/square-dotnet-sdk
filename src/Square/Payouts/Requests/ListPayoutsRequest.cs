using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Payouts;

public record ListPayoutsRequest
{
    /// <summary>
    /// The ID of the location for which to list the payouts.
    /// By default, payouts are returned for the default (main) location associated with the seller.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// If provided, only payouts with the given status are returned.
    /// </summary>
    [JsonIgnore]
    public PayoutStatus? Status { get; set; }

    /// <summary>
    /// The timestamp for the beginning of the payout creation time, in RFC 3339 format.
    /// Inclusive. Default: The current time minus one year.
    /// </summary>
    [JsonIgnore]
    public string? BeginTime { get; set; }

    /// <summary>
    /// The timestamp for the end of the payout creation time, in RFC 3339 format.
    /// Default: The current time.
    /// </summary>
    [JsonIgnore]
    public string? EndTime { get; set; }

    /// <summary>
    /// The order in which payouts are listed.
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// If request parameters change between requests, subsequent results may contain duplicates or missing records.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of results to be returned in a single page.
    /// It is possible to receive fewer results than the specified limit on a given page.
    /// The default value of 100 is also the maximum allowed value. If the provided value is
    /// greater than 100, it is ignored and the default value is used instead.
    /// Default: `100`
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
