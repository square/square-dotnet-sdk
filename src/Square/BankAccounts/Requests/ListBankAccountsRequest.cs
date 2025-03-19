using System.Text.Json.Serialization;
using Square.Core;

namespace Square.BankAccounts;

public record ListBankAccountsRequest
{
    /// <summary>
    /// The pagination cursor returned by a previous call to this endpoint.
    /// Use it in the next `ListBankAccounts` request to retrieve the next set
    /// of results.
    ///
    /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Upper limit on the number of bank accounts to return in the response.
    /// Currently, 1000 is the largest supported limit. You can specify a limit
    /// of up to 1000 bank accounts. This is also the default limit.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Location ID. You can specify this optional filter
    /// to retrieve only the linked bank accounts belonging to a specific location.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
