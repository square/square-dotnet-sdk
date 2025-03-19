using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Refunds;

public record ListRefundsRequest
{
    /// <summary>
    /// Indicates the start of the time range to retrieve each `PaymentRefund` for, in RFC 3339
    /// format.  The range is determined using the `created_at` field for each `PaymentRefund`.
    ///
    /// Default: The current time minus one year.
    /// </summary>
    [JsonIgnore]
    public string? BeginTime { get; set; }

    /// <summary>
    /// Indicates the end of the time range to retrieve each `PaymentRefund` for, in RFC 3339
    /// format.  The range is determined using the `created_at` field for each `PaymentRefund`.
    ///
    /// Default: The current time.
    /// </summary>
    [JsonIgnore]
    public string? EndTime { get; set; }

    /// <summary>
    /// The order in which results are listed by `PaymentRefund.created_at`:
    /// - `ASC` - Oldest to newest.
    /// - `DESC` - Newest to oldest (default).
    /// </summary>
    [JsonIgnore]
    public string? SortOrder { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Limit results to the location supplied. By default, results are returned
    /// for all locations associated with the seller.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// If provided, only refunds with the given status are returned.
    /// For a list of refund status values, see [PaymentRefund](entity:PaymentRefund).
    ///
    /// Default: If omitted, refunds are returned regardless of their status.
    /// </summary>
    [JsonIgnore]
    public string? Status { get; set; }

    /// <summary>
    /// If provided, only returns refunds whose payments have the indicated source type.
    /// Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`.
    /// For information about these payment source types, see
    /// [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
    ///
    /// Default: If omitted, refunds are returned regardless of the source type.
    /// </summary>
    [JsonIgnore]
    public string? SourceType { get; set; }

    /// <summary>
    /// The maximum number of results to be returned in a single page.
    ///
    /// It is possible to receive fewer results than the specified limit on a given page.
    ///
    /// If the supplied value is greater than 100, no more than 100 results are returned.
    ///
    /// Default: 100
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Indicates the start of the time range to retrieve each `PaymentRefund` for, in RFC 3339
    /// format.  The range is determined using the `updated_at` field for each `PaymentRefund`.
    ///
    /// Default: If omitted, the time range starts at `begin_time`.
    /// </summary>
    [JsonIgnore]
    public string? UpdatedAtBeginTime { get; set; }

    /// <summary>
    /// Indicates the end of the time range to retrieve each `PaymentRefund` for, in RFC 3339
    /// format.  The range is determined using the `updated_at` field for each `PaymentRefund`.
    ///
    /// Default: The current time.
    /// </summary>
    [JsonIgnore]
    public string? UpdatedAtEndTime { get; set; }

    /// <summary>
    /// The field used to sort results by. The default is `CREATED_AT`.
    /// </summary>
    [JsonIgnore]
    public ListPaymentRefundsRequestSortField? SortField { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
