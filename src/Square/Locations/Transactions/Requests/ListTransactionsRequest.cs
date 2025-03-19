using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Locations.Transactions;

public record ListTransactionsRequest
{
    /// <summary>
    /// The ID of the location to list transactions for.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The beginning of the requested reporting period, in RFC 3339 format.
    ///
    /// See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.
    ///
    /// Default value: The current time minus one year.
    /// </summary>
    [JsonIgnore]
    public string? BeginTime { get; set; }

    /// <summary>
    /// The end of the requested reporting period, in RFC 3339 format.
    ///
    /// See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.
    ///
    /// Default value: The current time.
    /// </summary>
    [JsonIgnore]
    public string? EndTime { get; set; }

    /// <summary>
    /// The order in which results are listed in the response (`ASC` for
    /// oldest first, `DESC` for newest first).
    ///
    /// Default value: `DESC`
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for your original query.
    ///
    /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
