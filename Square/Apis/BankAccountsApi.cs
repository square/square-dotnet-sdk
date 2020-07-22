using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;
using Square.Exceptions;

namespace Square.Apis
{
    internal class BankAccountsApi: BaseApi, IBankAccountsApi
    {
        internal BankAccountsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Returns a list of [BankAccount](#type-bankaccount) objects linked to a Square account. 
        /// For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by a previous call to this endpoint. Use it in the next `ListBankAccounts` request to retrieve the next set  of results.  See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.</param>
        /// <param name="limit">Optional parameter: Upper limit on the number of bank accounts to return in the response.  Currently, 1000 is the largest supported limit. You can specify a limit  of up to 1000 bank accounts. This is also the default limit.</param>
        /// <param name="locationId">Optional parameter: Location ID. You can specify this optional filter  to retrieve only the linked bank accounts belonging to a specific location.</param>
        /// <return>Returns the Models.ListBankAccountsResponse response from the API call</return>
        public Models.ListBankAccountsResponse ListBankAccounts(string cursor = null, int? limit = null, string locationId = null)
        {
            Task<Models.ListBankAccountsResponse> t = ListBankAccountsAsync(cursor, limit, locationId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of [BankAccount](#type-bankaccount) objects linked to a Square account. 
        /// For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by a previous call to this endpoint. Use it in the next `ListBankAccounts` request to retrieve the next set  of results.  See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.</param>
        /// <param name="limit">Optional parameter: Upper limit on the number of bank accounts to return in the response.  Currently, 1000 is the largest supported limit. You can specify a limit  of up to 1000 bank accounts. This is also the default limit.</param>
        /// <param name="locationId">Optional parameter: Location ID. You can specify this optional filter  to retrieve only the linked bank accounts belonging to a specific location.</param>
        /// <return>Returns the Models.ListBankAccountsResponse response from the API call</return>
        public async Task<Models.ListBankAccountsResponse> ListBankAccountsAsync(string cursor = null, int? limit = null, string locationId = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/bank-accounts");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "limit", limit },
                { "location_id", locationId }
            }, ArrayDeserializationFormat, ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListBankAccountsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns details of a [BankAccount](#type-bankaccount) identified by V1 bank account ID. 
        /// For more information, see 
        /// [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-the-v1-bank-accounts-api).
        /// </summary>
        /// <param name="v1BankAccountId">Required parameter: Connect V1 ID of the desired `BankAccount`. For more information, see  [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api).</param>
        /// <return>Returns the Models.GetBankAccountByV1IdResponse response from the API call</return>
        public Models.GetBankAccountByV1IdResponse GetBankAccountByV1Id(string v1BankAccountId)
        {
            Task<Models.GetBankAccountByV1IdResponse> t = GetBankAccountByV1IdAsync(v1BankAccountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns details of a [BankAccount](#type-bankaccount) identified by V1 bank account ID. 
        /// For more information, see 
        /// [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-the-v1-bank-accounts-api).
        /// </summary>
        /// <param name="v1BankAccountId">Required parameter: Connect V1 ID of the desired `BankAccount`. For more information, see  [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api).</param>
        /// <return>Returns the Models.GetBankAccountByV1IdResponse response from the API call</return>
        public async Task<Models.GetBankAccountByV1IdResponse> GetBankAccountByV1IdAsync(string v1BankAccountId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/bank-accounts/by-v1-id/{v1_bank_account_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "v1_bank_account_id", v1BankAccountId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetBankAccountByV1IdResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns details of a [BankAccount](#type-bankaccount) 
        /// linked to a Square account. For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        /// <param name="bankAccountId">Required parameter: Square-issued ID of the desired `BankAccount`.</param>
        /// <return>Returns the Models.GetBankAccountResponse response from the API call</return>
        public Models.GetBankAccountResponse GetBankAccount(string bankAccountId)
        {
            Task<Models.GetBankAccountResponse> t = GetBankAccountAsync(bankAccountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns details of a [BankAccount](#type-bankaccount) 
        /// linked to a Square account. For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        /// <param name="bankAccountId">Required parameter: Square-issued ID of the desired `BankAccount`.</param>
        /// <return>Returns the Models.GetBankAccountResponse response from the API call</return>
        public async Task<Models.GetBankAccountResponse> GetBankAccountAsync(string bankAccountId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/bank-accounts/{bank_account_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "bank_account_id", bankAccountId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetBankAccountResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}