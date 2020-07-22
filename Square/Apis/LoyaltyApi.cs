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
    internal class LoyaltyApi: BaseApi, ILoyaltyApi
    {
        internal LoyaltyApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Creates a loyalty account. For more information, see 
        /// [Create a loyalty account](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-create-account).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyAccountResponse response from the API call</return>
        public Models.CreateLoyaltyAccountResponse CreateLoyaltyAccount(Models.CreateLoyaltyAccountRequest body)
        {
            Task<Models.CreateLoyaltyAccountResponse> t = CreateLoyaltyAccountAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a loyalty account. For more information, see 
        /// [Create a loyalty account](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-create-account).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyAccountResponse response from the API call</return>
        public async Task<Models.CreateLoyaltyAccountResponse> CreateLoyaltyAccountAsync(Models.CreateLoyaltyAccountRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/accounts");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateLoyaltyAccountResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Searches for loyalty accounts. 
        /// In the current implementation, you can search for a loyalty account using the phone number associated with the account. 
        /// If no phone number is provided, all loyalty accounts are returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyAccountsResponse response from the API call</return>
        public Models.SearchLoyaltyAccountsResponse SearchLoyaltyAccounts(Models.SearchLoyaltyAccountsRequest body)
        {
            Task<Models.SearchLoyaltyAccountsResponse> t = SearchLoyaltyAccountsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for loyalty accounts. 
        /// In the current implementation, you can search for a loyalty account using the phone number associated with the account. 
        /// If no phone number is provided, all loyalty accounts are returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyAccountsResponse response from the API call</return>
        public async Task<Models.SearchLoyaltyAccountsResponse> SearchLoyaltyAccountsAsync(Models.SearchLoyaltyAccountsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/accounts/search");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchLoyaltyAccountsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves a loyalty account.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyAccountResponse response from the API call</return>
        public Models.RetrieveLoyaltyAccountResponse RetrieveLoyaltyAccount(string accountId)
        {
            Task<Models.RetrieveLoyaltyAccountResponse> t = RetrieveLoyaltyAccountAsync(accountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a loyalty account.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyAccountResponse response from the API call</return>
        public async Task<Models.RetrieveLoyaltyAccountResponse> RetrieveLoyaltyAccountAsync(string accountId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/accounts/{account_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "account_id", accountId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveLoyaltyAccountResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Adds points to a loyalty account.
        /// - If you are using the Orders API to manage orders, you only provide the `order_id`. 
        /// The endpoint reads the order to compute points to add to the buyer's account.
        /// - If you are not using the Orders API to manage orders, 
        /// you first perform a client-side computation to compute the points.  
        /// For spend-based and visit-based programs, you can call 
        /// `CalculateLoyaltyPoints` to compute the points. For more information, 
        /// see [Loyalty Program Overview](https://developer.squareup.com/docs/docs/loyalty/overview). 
        /// You then provide the points in a request to this endpoint. 
        /// For more information, see [Accumulate points](https://developer.squareup.com/docs/docs/loyalty-api/overview/#accumulate-points).
        /// </summary>
        /// <param name="accountId">Required parameter: The [loyalty account](#type-LoyaltyAccount) ID to which to add the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AccumulateLoyaltyPointsResponse response from the API call</return>
        public Models.AccumulateLoyaltyPointsResponse AccumulateLoyaltyPoints(string accountId, Models.AccumulateLoyaltyPointsRequest body)
        {
            Task<Models.AccumulateLoyaltyPointsResponse> t = AccumulateLoyaltyPointsAsync(accountId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds points to a loyalty account.
        /// - If you are using the Orders API to manage orders, you only provide the `order_id`. 
        /// The endpoint reads the order to compute points to add to the buyer's account.
        /// - If you are not using the Orders API to manage orders, 
        /// you first perform a client-side computation to compute the points.  
        /// For spend-based and visit-based programs, you can call 
        /// `CalculateLoyaltyPoints` to compute the points. For more information, 
        /// see [Loyalty Program Overview](https://developer.squareup.com/docs/docs/loyalty/overview). 
        /// You then provide the points in a request to this endpoint. 
        /// For more information, see [Accumulate points](https://developer.squareup.com/docs/docs/loyalty-api/overview/#accumulate-points).
        /// </summary>
        /// <param name="accountId">Required parameter: The [loyalty account](#type-LoyaltyAccount) ID to which to add the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AccumulateLoyaltyPointsResponse response from the API call</return>
        public async Task<Models.AccumulateLoyaltyPointsResponse> AccumulateLoyaltyPointsAsync(string accountId, Models.AccumulateLoyaltyPointsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/accounts/{account_id}/accumulate");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "account_id", accountId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.AccumulateLoyaltyPointsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Adds points to or subtracts points from a buyer's account. 
        /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call 
        /// [AccumulateLoyaltyPoints](https://developer.squareup.com/docs/reference/square/loyalty-api/accumulate-loyalty-points) 
        /// to add points when a buyer pays for the purchase.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) in which to adjust the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AdjustLoyaltyPointsResponse response from the API call</return>
        public Models.AdjustLoyaltyPointsResponse AdjustLoyaltyPoints(string accountId, Models.AdjustLoyaltyPointsRequest body)
        {
            Task<Models.AdjustLoyaltyPointsResponse> t = AdjustLoyaltyPointsAsync(accountId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds points to or subtracts points from a buyer's account. 
        /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call 
        /// [AccumulateLoyaltyPoints](https://developer.squareup.com/docs/reference/square/loyalty-api/accumulate-loyalty-points) 
        /// to add points when a buyer pays for the purchase.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) in which to adjust the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AdjustLoyaltyPointsResponse response from the API call</return>
        public async Task<Models.AdjustLoyaltyPointsResponse> AdjustLoyaltyPointsAsync(string accountId, Models.AdjustLoyaltyPointsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/accounts/{account_id}/adjust");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "account_id", accountId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.AdjustLoyaltyPointsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Searches for loyalty events.
        /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a 
        /// buyer's loyalty account. Each change in the point balance 
        /// (for example, points earned, points redeemed, and points expired) is 
        /// recorded in the ledger. Using this endpoint, you can search the ledger for events. 
        /// For more information, see 
        /// [Loyalty events](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-events).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyEventsResponse response from the API call</return>
        public Models.SearchLoyaltyEventsResponse SearchLoyaltyEvents(Models.SearchLoyaltyEventsRequest body)
        {
            Task<Models.SearchLoyaltyEventsResponse> t = SearchLoyaltyEventsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for loyalty events.
        /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a 
        /// buyer's loyalty account. Each change in the point balance 
        /// (for example, points earned, points redeemed, and points expired) is 
        /// recorded in the ledger. Using this endpoint, you can search the ledger for events. 
        /// For more information, see 
        /// [Loyalty events](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-events).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyEventsResponse response from the API call</return>
        public async Task<Models.SearchLoyaltyEventsResponse> SearchLoyaltyEventsAsync(Models.SearchLoyaltyEventsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/events/search");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchLoyaltyEventsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a list of loyalty programs in the seller's account.
        /// Currently, a seller can only have one loyalty program. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
        /// .
        /// </summary>
        /// <return>Returns the Models.ListLoyaltyProgramsResponse response from the API call</return>
        public Models.ListLoyaltyProgramsResponse ListLoyaltyPrograms()
        {
            Task<Models.ListLoyaltyProgramsResponse> t = ListLoyaltyProgramsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of loyalty programs in the seller's account.
        /// Currently, a seller can only have one loyalty program. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
        /// .
        /// </summary>
        /// <return>Returns the Models.ListLoyaltyProgramsResponse response from the API call</return>
        public async Task<Models.ListLoyaltyProgramsResponse> ListLoyaltyProgramsAsync(CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/programs");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListLoyaltyProgramsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Calculates the points a purchase earns.
        /// - If you are using the Orders API to manage orders, you provide `order_id` in the request. The 
        /// endpoint calculates the points by reading the order.
        /// - If you are not using the Orders API to manage orders, you provide the purchase amount in 
        /// the request for the endpoint to calculate the points.
        /// An application might call this endpoint to show the points that a buyer can earn with the 
        /// specific purchase.
        /// </summary>
        /// <param name="programId">Required parameter: The [loyalty program](#type-LoyaltyProgram) ID, which defines the rules for accruing points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateLoyaltyPointsResponse response from the API call</return>
        public Models.CalculateLoyaltyPointsResponse CalculateLoyaltyPoints(string programId, Models.CalculateLoyaltyPointsRequest body)
        {
            Task<Models.CalculateLoyaltyPointsResponse> t = CalculateLoyaltyPointsAsync(programId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Calculates the points a purchase earns.
        /// - If you are using the Orders API to manage orders, you provide `order_id` in the request. The 
        /// endpoint calculates the points by reading the order.
        /// - If you are not using the Orders API to manage orders, you provide the purchase amount in 
        /// the request for the endpoint to calculate the points.
        /// An application might call this endpoint to show the points that a buyer can earn with the 
        /// specific purchase.
        /// </summary>
        /// <param name="programId">Required parameter: The [loyalty program](#type-LoyaltyProgram) ID, which defines the rules for accruing points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateLoyaltyPointsResponse response from the API call</return>
        public async Task<Models.CalculateLoyaltyPointsResponse> CalculateLoyaltyPointsAsync(string programId, Models.CalculateLoyaltyPointsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/programs/{program_id}/calculate");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "program_id", programId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CalculateLoyaltyPointsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates a loyalty reward. In the process, the endpoint does following:
        /// - Uses the `reward_tier_id` in the request to determine the number of points 
        /// to lock for this reward. 
        /// - If the request includes `order_id`, it adds the reward and related discount to the order. 
        /// After a reward is created, the points are locked and 
        /// not available for the buyer to redeem another reward. 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyRewardResponse response from the API call</return>
        public Models.CreateLoyaltyRewardResponse CreateLoyaltyReward(Models.CreateLoyaltyRewardRequest body)
        {
            Task<Models.CreateLoyaltyRewardResponse> t = CreateLoyaltyRewardAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a loyalty reward. In the process, the endpoint does following:
        /// - Uses the `reward_tier_id` in the request to determine the number of points 
        /// to lock for this reward. 
        /// - If the request includes `order_id`, it adds the reward and related discount to the order. 
        /// After a reward is created, the points are locked and 
        /// not available for the buyer to redeem another reward. 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyRewardResponse response from the API call</return>
        public async Task<Models.CreateLoyaltyRewardResponse> CreateLoyaltyRewardAsync(Models.CreateLoyaltyRewardRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/rewards");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateLoyaltyRewardResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Searches for loyalty rewards in a loyalty account. 
        /// In the current implementation, the endpoint supports search by the reward `status`.
        /// If you know a reward ID, use the 
        /// [RetrieveLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/retrieve-loyalty-reward) endpoint.
        /// For more information about loyalty rewards, see 
        /// [Loyalty Rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyRewardsResponse response from the API call</return>
        public Models.SearchLoyaltyRewardsResponse SearchLoyaltyRewards(Models.SearchLoyaltyRewardsRequest body)
        {
            Task<Models.SearchLoyaltyRewardsResponse> t = SearchLoyaltyRewardsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for loyalty rewards in a loyalty account. 
        /// In the current implementation, the endpoint supports search by the reward `status`.
        /// If you know a reward ID, use the 
        /// [RetrieveLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/retrieve-loyalty-reward) endpoint.
        /// For more information about loyalty rewards, see 
        /// [Loyalty Rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyRewardsResponse response from the API call</return>
        public async Task<Models.SearchLoyaltyRewardsResponse> SearchLoyaltyRewardsAsync(Models.SearchLoyaltyRewardsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/rewards/search");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchLoyaltyRewardsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Deletes a loyalty reward by doing the following:
        /// - Returns the loyalty points back to the loyalty account.
        /// - If an order ID was specified when the reward was created 
        /// (see [CreateLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/create-loyalty-reward)), 
        /// it updates the order by removing the reward and related 
        /// discounts.
        /// You cannot delete a reward that has reached the terminal state (REDEEMED). 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to delete.</param>
        /// <return>Returns the Models.DeleteLoyaltyRewardResponse response from the API call</return>
        public Models.DeleteLoyaltyRewardResponse DeleteLoyaltyReward(string rewardId)
        {
            Task<Models.DeleteLoyaltyRewardResponse> t = DeleteLoyaltyRewardAsync(rewardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a loyalty reward by doing the following:
        /// - Returns the loyalty points back to the loyalty account.
        /// - If an order ID was specified when the reward was created 
        /// (see [CreateLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/create-loyalty-reward)), 
        /// it updates the order by removing the reward and related 
        /// discounts.
        /// You cannot delete a reward that has reached the terminal state (REDEEMED). 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to delete.</param>
        /// <return>Returns the Models.DeleteLoyaltyRewardResponse response from the API call</return>
        public async Task<Models.DeleteLoyaltyRewardResponse> DeleteLoyaltyRewardAsync(string rewardId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/rewards/{reward_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "reward_id", rewardId }
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
            HttpRequest _request = GetClientInstance().Delete(_queryUrl, _headers, null);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteLoyaltyRewardResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves a loyalty reward.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyRewardResponse response from the API call</return>
        public Models.RetrieveLoyaltyRewardResponse RetrieveLoyaltyReward(string rewardId)
        {
            Task<Models.RetrieveLoyaltyRewardResponse> t = RetrieveLoyaltyRewardAsync(rewardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a loyalty reward.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyRewardResponse response from the API call</return>
        public async Task<Models.RetrieveLoyaltyRewardResponse> RetrieveLoyaltyRewardAsync(string rewardId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/rewards/{reward_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "reward_id", rewardId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveLoyaltyRewardResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Redeems a loyalty reward.
        /// The endpoint sets the reward to the terminal state (`REDEEMED`). 
        /// If you are using your own order processing system (not using the 
        /// Orders API), you call this endpoint after the buyer paid for the 
        /// purchase.
        /// After the reward reaches the terminal state, it cannot be deleted. 
        /// In other words, points used for the reward cannot be returned 
        /// to the account.
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to redeem.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RedeemLoyaltyRewardResponse response from the API call</return>
        public Models.RedeemLoyaltyRewardResponse RedeemLoyaltyReward(string rewardId, Models.RedeemLoyaltyRewardRequest body)
        {
            Task<Models.RedeemLoyaltyRewardResponse> t = RedeemLoyaltyRewardAsync(rewardId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Redeems a loyalty reward.
        /// The endpoint sets the reward to the terminal state (`REDEEMED`). 
        /// If you are using your own order processing system (not using the 
        /// Orders API), you call this endpoint after the buyer paid for the 
        /// purchase.
        /// After the reward reaches the terminal state, it cannot be deleted. 
        /// In other words, points used for the reward cannot be returned 
        /// to the account.
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to redeem.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RedeemLoyaltyRewardResponse response from the API call</return>
        public async Task<Models.RedeemLoyaltyRewardResponse> RedeemLoyaltyRewardAsync(string rewardId, Models.RedeemLoyaltyRewardRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/loyalty/rewards/{reward_id}/redeem");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "reward_id", rewardId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RedeemLoyaltyRewardResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}