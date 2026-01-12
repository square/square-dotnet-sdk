using Square;
using Square.Core;

namespace Square.BankAccounts;

public partial interface IBankAccountsClient
{
    /// <summary>
    /// Returns a list of [BankAccount](entity:BankAccount) objects linked to a Square account.
    /// </summary>
    Task<Pager<BankAccount>> ListAsync(
        ListBankAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns details of a [BankAccount](entity:BankAccount) identified by V1 bank account ID.
    /// </summary>
    Task<GetBankAccountByV1IdResponse> GetByV1IdAsync(
        GetByV1IdBankAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns details of a [BankAccount](entity:BankAccount)
    /// linked to a Square account.
    /// </summary>
    Task<GetBankAccountResponse> GetAsync(
        GetBankAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
