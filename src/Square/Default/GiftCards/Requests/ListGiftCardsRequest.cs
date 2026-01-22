using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record ListGiftCardsRequest
{
    /// <summary>
    /// If a [type](entity:GiftCardType) is provided, the endpoint returns gift cards of the specified type.
    /// Otherwise, the endpoint returns gift cards of all types.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }

    /// <summary>
    /// If a [state](entity:GiftCardStatus) is provided, the endpoint returns the gift cards in the specified state.
    /// Otherwise, the endpoint returns the gift cards of all states.
    /// </summary>
    [JsonIgnore]
    public string? State { get; set; }

    /// <summary>
    /// If a limit is provided, the endpoint returns only the specified number of results per page.
    /// The maximum value is 200. The default value is 30.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this cursor to retrieve the next set of results for the original query.
    /// If a cursor is not provided, the endpoint returns the first page of the results.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// If a customer ID is provided, the endpoint returns only the gift cards linked to the specified customer.
    /// </summary>
    [JsonIgnore]
    public string? CustomerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
