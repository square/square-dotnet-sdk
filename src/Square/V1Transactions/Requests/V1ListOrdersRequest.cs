using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.V1Transactions;

[Serializable]
public record V1ListOrdersRequest
{
    /// <summary>
    /// The ID of the location to list online store orders for.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The order in which payments are listed in the response.
    /// </summary>
    [JsonIgnore]
    public SortOrder? Order { get; set; }

    /// <summary>
    /// The maximum number of payments to return in a single response. This value cannot exceed 200.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// A pagination cursor to retrieve the next set of results for your
    /// original query to the endpoint.
    /// </summary>
    [JsonIgnore]
    public string? BatchToken { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
