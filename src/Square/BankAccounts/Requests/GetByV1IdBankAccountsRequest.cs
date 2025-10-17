using System.Text.Json.Serialization;
using Square.Core;

namespace Square.BankAccounts;

[Serializable]
public record GetByV1IdBankAccountsRequest
{
    /// <summary>
    /// Connect V1 ID of the desired `BankAccount`. For more information, see
    /// [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api).
    /// </summary>
    [JsonIgnore]
    public required string V1BankAccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
