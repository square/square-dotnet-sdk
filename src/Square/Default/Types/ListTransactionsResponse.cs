using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListTransactions](api-endpoint:Transactions-ListTransactions) endpoint.
///
/// One of `errors` or `transactions` is present in a given response (never both).
/// </summary>
[Serializable]
public record ListTransactionsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
