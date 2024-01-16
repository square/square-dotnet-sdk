namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// BankAccountsApi.
    /// </summary>
    internal class BankAccountsApi : BaseApi, IBankAccountsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountsApi"/> class.
        /// </summary>
        internal BankAccountsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Returns a list of [BankAccount]($m/BankAccount) objects linked to a Square account.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by a previous call to this endpoint. Use it in the next `ListBankAccounts` request to retrieve the next set  of results.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="limit">Optional parameter: Upper limit on the number of bank accounts to return in the response.  Currently, 1000 is the largest supported limit. You can specify a limit  of up to 1000 bank accounts. This is also the default limit..</param>
        /// <param name="locationId">Optional parameter: Location ID. You can specify this optional filter  to retrieve only the linked bank accounts belonging to a specific location..</param>
        /// <returns>Returns the Models.ListBankAccountsResponse response from the API call.</returns>
        public Models.ListBankAccountsResponse ListBankAccounts(
                string cursor = null,
                int? limit = null,
                string locationId = null)
            => CoreHelper.RunTask(ListBankAccountsAsync(cursor, limit, locationId));

        /// <summary>
        /// Returns a list of [BankAccount]($m/BankAccount) objects linked to a Square account.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by a previous call to this endpoint. Use it in the next `ListBankAccounts` request to retrieve the next set  of results.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="limit">Optional parameter: Upper limit on the number of bank accounts to return in the response.  Currently, 1000 is the largest supported limit. You can specify a limit  of up to 1000 bank accounts. This is also the default limit..</param>
        /// <param name="locationId">Optional parameter: Location ID. You can specify this optional filter  to retrieve only the linked bank accounts belonging to a specific location..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBankAccountsResponse response from the API call.</returns>
        public async Task<Models.ListBankAccountsResponse> ListBankAccountsAsync(
                string cursor = null,
                int? limit = null,
                string locationId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListBankAccountsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bank-accounts")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("location_id", locationId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount) identified by V1 bank account ID.
        /// </summary>
        /// <param name="v1BankAccountId">Required parameter: Connect V1 ID of the desired `BankAccount`. For more information, see  [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api)..</param>
        /// <returns>Returns the Models.GetBankAccountByV1IdResponse response from the API call.</returns>
        public Models.GetBankAccountByV1IdResponse GetBankAccountByV1Id(
                string v1BankAccountId)
            => CoreHelper.RunTask(GetBankAccountByV1IdAsync(v1BankAccountId));

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount) identified by V1 bank account ID.
        /// </summary>
        /// <param name="v1BankAccountId">Required parameter: Connect V1 ID of the desired `BankAccount`. For more information, see  [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBankAccountByV1IdResponse response from the API call.</returns>
        public async Task<Models.GetBankAccountByV1IdResponse> GetBankAccountByV1IdAsync(
                string v1BankAccountId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetBankAccountByV1IdResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bank-accounts/by-v1-id/{v1_bank_account_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("v1_bank_account_id", v1BankAccountId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount).
        /// linked to a Square account.
        /// </summary>
        /// <param name="bankAccountId">Required parameter: Square-issued ID of the desired `BankAccount`..</param>
        /// <returns>Returns the Models.GetBankAccountResponse response from the API call.</returns>
        public Models.GetBankAccountResponse GetBankAccount(
                string bankAccountId)
            => CoreHelper.RunTask(GetBankAccountAsync(bankAccountId));

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount).
        /// linked to a Square account.
        /// </summary>
        /// <param name="bankAccountId">Required parameter: Square-issued ID of the desired `BankAccount`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBankAccountResponse response from the API call.</returns>
        public async Task<Models.GetBankAccountResponse> GetBankAccountAsync(
                string bankAccountId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetBankAccountResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bank-accounts/{bank_account_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("bank_account_id", bankAccountId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}