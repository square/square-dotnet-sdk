using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Cards;

[Serializable]
public record ListCardsRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for your original query.
    ///
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Limit results to cards associated with the customer supplied.
    /// By default, all cards owned by the merchant are returned.
    /// </summary>
    [JsonIgnore]
    public string? CustomerId { get; set; }

    /// <summary>
    /// Includes disabled cards.
    /// By default, all enabled cards owned by the merchant are returned.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeDisabled { get; set; }

    /// <summary>
    /// Limit results to cards associated with the reference_id supplied.
    /// </summary>
    [JsonIgnore]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Sorts the returned list by when the card was created with the specified order.
    /// This field defaults to ASC.
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
