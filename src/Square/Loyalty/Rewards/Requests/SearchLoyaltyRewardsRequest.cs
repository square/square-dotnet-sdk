using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Rewards;

public record SearchLoyaltyRewardsRequest
{
    /// <summary>
    /// The search criteria for the request.
    /// If empty, the endpoint retrieves all loyalty rewards in the loyalty program.
    /// </summary>
    [JsonPropertyName("query")]
    public SearchLoyaltyRewardsRequestLoyaltyRewardQuery? Query { get; set; }

    /// <summary>
    /// The maximum number of results to return in the response. The default value is 30.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to
    /// this endpoint. Provide this to retrieve the next set of
    /// results for the original query.
    /// For more information,
    /// see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
