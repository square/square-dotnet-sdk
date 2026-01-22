using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record ListPaymentsRequest
{
    /// <summary>
    /// Indicates the start of the time range to retrieve payments for, in RFC 3339 format.
    /// The range is determined using the `created_at` field for each Payment.
    /// Inclusive. Default: The current time minus one year.
    /// </summary>
    [JsonIgnore]
    public string? BeginTime { get; set; }

    /// <summary>
    /// Indicates the end of the time range to retrieve payments for, in RFC 3339 format.  The
    /// range is determined using the `created_at` field for each Payment.
    ///
    /// Default: The current time.
    /// </summary>
    [JsonIgnore]
    public string? EndTime { get; set; }

    /// <summary>
    /// The order in which results are listed by `ListPaymentsRequest.sort_field`:
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
    /// for the default (main) location associated with the seller.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// The exact amount in the `total_money` for a payment.
    /// </summary>
    [JsonIgnore]
    public long? Total { get; set; }

    /// <summary>
    /// The last four digits of a payment card.
    /// </summary>
    [JsonIgnore]
    public string? Last4 { get; set; }

    /// <summary>
    /// The brand of the payment card (for example, VISA).
    /// </summary>
    [JsonIgnore]
    public string? CardBrand { get; set; }

    /// <summary>
    /// The maximum number of results to be returned in a single page.
    /// It is possible to receive fewer results than the specified limit on a given page.
    ///
    /// The default value of 100 is also the maximum allowed value. If the provided value is
    /// greater than 100, it is ignored and the default value is used instead.
    ///
    /// Default: `100`
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Whether the payment was taken offline or not.
    /// </summary>
    [JsonIgnore]
    public bool? IsOfflinePayment { get; set; }

    /// <summary>
    /// Indicates the start of the time range for which to retrieve offline payments, in RFC 3339
    /// format for timestamps. The range is determined using the
    /// `offline_payment_details.client_created_at` field for each Payment. If set, payments without a
    /// value set in `offline_payment_details.client_created_at` will not be returned.
    ///
    /// Default: The current time.
    /// </summary>
    [JsonIgnore]
    public string? OfflineBeginTime { get; set; }

    /// <summary>
    /// Indicates the end of the time range for which to retrieve offline payments, in RFC 3339
    /// format for timestamps. The range is determined using the
    /// `offline_payment_details.client_created_at` field for each Payment. If set, payments without a
    /// value set in `offline_payment_details.client_created_at` will not be returned.
    ///
    /// Default: The current time.
    /// </summary>
    [JsonIgnore]
    public string? OfflineEndTime { get; set; }

    /// <summary>
    /// Indicates the start of the time range to retrieve payments for, in RFC 3339 format.  The
    /// range is determined using the `updated_at` field for each Payment.
    /// </summary>
    [JsonIgnore]
    public string? UpdatedAtBeginTime { get; set; }

    /// <summary>
    /// Indicates the end of the time range to retrieve payments for, in RFC 3339 format.  The
    /// range is determined using the `updated_at` field for each Payment.
    /// </summary>
    [JsonIgnore]
    public string? UpdatedAtEndTime { get; set; }

    /// <summary>
    /// The field used to sort results by. The default is `CREATED_AT`.
    /// </summary>
    [JsonIgnore]
    public ListPaymentsRequestSortField? SortField { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
