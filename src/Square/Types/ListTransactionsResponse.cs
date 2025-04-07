using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListTransactions](api-endpoint:Transactions-ListTransactions) endpoint.
///
/// One of `errors` or `transactions` is present in a given response (never both).
/// </summary>
public record ListTransactionsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// An array of transactions that match your query.
    /// </summary>
    [JsonPropertyName("transactions")]
    public IEnumerable<Transaction>? Transactions { get; set; }

    /// <summary>
    /// A pagination cursor for retrieving the next set of results,
    /// if any remain. Provide this value as the `cursor` parameter in a subsequent
    /// request to this endpoint.
    ///
    /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
