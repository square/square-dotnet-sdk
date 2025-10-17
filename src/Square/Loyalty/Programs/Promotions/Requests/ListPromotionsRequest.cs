using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Programs.Promotions;

[Serializable]
public record ListPromotionsRequest
{
    /// <summary>
    /// The ID of the base [loyalty program](entity:LoyaltyProgram). To get the program ID,
    /// call [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) using the `main` keyword.
    /// </summary>
    [JsonIgnore]
    public required string ProgramId { get; set; }

    /// <summary>
    /// The status to filter the results by. If a status is provided, only loyalty promotions
    /// with the specified status are returned. Otherwise, all loyalty promotions associated with
    /// the loyalty program are returned.
    /// </summary>
    [JsonIgnore]
    public LoyaltyPromotionStatus? Status { get; set; }

    /// <summary>
    /// The cursor returned in the paged response from the previous call to this endpoint.
    /// Provide this cursor to retrieve the next page of results for your original request.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The maximum number of results to return in a single paged response.
    /// The minimum value is 1 and the maximum value is 30. The default value is 30.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
