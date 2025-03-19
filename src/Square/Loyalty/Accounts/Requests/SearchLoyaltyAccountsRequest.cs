using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Accounts;

public record SearchLoyaltyAccountsRequest
{
    /// <summary>
    /// The search criteria for the request.
    /// </summary>
    [JsonPropertyName("query")]
    public SearchLoyaltyAccountsRequestLoyaltyAccountQuery? Query { get; set; }

    /// <summary>
    /// The maximum number of results to include in the response. The default value is 30.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to
    /// this endpoint. Provide this to retrieve the next set of
    /// results for the original query.
    ///
    /// For more information,
    /// see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
