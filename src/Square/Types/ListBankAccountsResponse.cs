using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Response object returned by ListBankAccounts.
/// </summary>
public record ListBankAccountsResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// List of BankAccounts associated with this account.
    /// </summary>
    [JsonPropertyName("bank_accounts")]
    public IEnumerable<BankAccount>? BankAccounts { get; set; }

    /// <summary>
    /// When a response is truncated, it includes a cursor that you can
    /// use in a subsequent request to fetch next set of bank accounts.
    /// If empty, this is the final response.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
