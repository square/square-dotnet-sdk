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
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// LoyaltyApi.
    /// </summary>
    internal class LoyaltyApi : BaseApi, ILoyaltyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal LoyaltyApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Creates a loyalty account. To create a loyalty account, you must provide the `program_id` and a `mapping` with the `phone_number` of the buyer.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateLoyaltyAccountResponse response from the API call.</returns>
        public Models.CreateLoyaltyAccountResponse CreateLoyaltyAccount(
                Models.CreateLoyaltyAccountRequest body)
        {
            Task<Models.CreateLoyaltyAccountResponse> t = this.CreateLoyaltyAccountAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a loyalty account. To create a loyalty account, you must provide the `program_id` and a `mapping` with the `phone_number` of the buyer.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateLoyaltyAccountResponse response from the API call.</returns>
        public async Task<Models.CreateLoyaltyAccountResponse> CreateLoyaltyAccountAsync(
                Models.CreateLoyaltyAccountRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/accounts");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateLoyaltyAccountResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches for loyalty accounts in a loyalty program.  .
        /// You can search for a loyalty account using the phone number or customer ID associated with the account. To return all loyalty accounts, specify an empty `query` object or omit it entirely.  .
        /// Search results are sorted by `created_at` in ascending order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchLoyaltyAccountsResponse response from the API call.</returns>
        public Models.SearchLoyaltyAccountsResponse SearchLoyaltyAccounts(
                Models.SearchLoyaltyAccountsRequest body)
        {
            Task<Models.SearchLoyaltyAccountsResponse> t = this.SearchLoyaltyAccountsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for loyalty accounts in a loyalty program.  .
        /// You can search for a loyalty account using the phone number or customer ID associated with the account. To return all loyalty accounts, specify an empty `query` object or omit it entirely.  .
        /// Search results are sorted by `created_at` in ascending order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchLoyaltyAccountsResponse response from the API call.</returns>
        public async Task<Models.SearchLoyaltyAccountsResponse> SearchLoyaltyAccountsAsync(
                Models.SearchLoyaltyAccountsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/accounts/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchLoyaltyAccountsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a loyalty account.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account]($m/LoyaltyAccount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveLoyaltyAccountResponse response from the API call.</returns>
        public Models.RetrieveLoyaltyAccountResponse RetrieveLoyaltyAccount(
                string accountId)
        {
            Task<Models.RetrieveLoyaltyAccountResponse> t = this.RetrieveLoyaltyAccountAsync(accountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a loyalty account.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account]($m/LoyaltyAccount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLoyaltyAccountResponse response from the API call.</returns>
        public async Task<Models.RetrieveLoyaltyAccountResponse> RetrieveLoyaltyAccountAsync(
                string accountId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/accounts/{account_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "account_id", accountId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveLoyaltyAccountResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Adds points to a loyalty account.
        /// - If you are using the Orders API to manage orders, you only provide the `order_id`. .
        /// The endpoint reads the order to compute points to add to the buyer's account.
        /// - If you are not using the Orders API to manage orders, .
        /// you first perform a client-side computation to compute the points.  .
        /// For spend-based and visit-based programs, you can first call .
        /// [CalculateLoyaltyPoints]($e/Loyalty/CalculateLoyaltyPoints) to compute the points  .
        /// that you provide to this endpoint.
        /// </summary>
        /// <param name="accountId">Required parameter: The [loyalty account]($m/LoyaltyAccount) ID to which to add the points..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.AccumulateLoyaltyPointsResponse response from the API call.</returns>
        public Models.AccumulateLoyaltyPointsResponse AccumulateLoyaltyPoints(
                string accountId,
                Models.AccumulateLoyaltyPointsRequest body)
        {
            Task<Models.AccumulateLoyaltyPointsResponse> t = this.AccumulateLoyaltyPointsAsync(accountId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds points to a loyalty account.
        /// - If you are using the Orders API to manage orders, you only provide the `order_id`. .
        /// The endpoint reads the order to compute points to add to the buyer's account.
        /// - If you are not using the Orders API to manage orders, .
        /// you first perform a client-side computation to compute the points.  .
        /// For spend-based and visit-based programs, you can first call .
        /// [CalculateLoyaltyPoints]($e/Loyalty/CalculateLoyaltyPoints) to compute the points  .
        /// that you provide to this endpoint.
        /// </summary>
        /// <param name="accountId">Required parameter: The [loyalty account]($m/LoyaltyAccount) ID to which to add the points..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AccumulateLoyaltyPointsResponse response from the API call.</returns>
        public async Task<Models.AccumulateLoyaltyPointsResponse> AccumulateLoyaltyPointsAsync(
                string accountId,
                Models.AccumulateLoyaltyPointsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/accounts/{account_id}/accumulate");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "account_id", accountId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.AccumulateLoyaltyPointsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Adds points to or subtracts points from a buyer's account. .
        /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call .
        /// [AccumulateLoyaltyPoints]($e/Loyalty/AccumulateLoyaltyPoints) .
        /// to add points when a buyer pays for the purchase.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account]($m/LoyaltyAccount) in which to adjust the points..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.AdjustLoyaltyPointsResponse response from the API call.</returns>
        public Models.AdjustLoyaltyPointsResponse AdjustLoyaltyPoints(
                string accountId,
                Models.AdjustLoyaltyPointsRequest body)
        {
            Task<Models.AdjustLoyaltyPointsResponse> t = this.AdjustLoyaltyPointsAsync(accountId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds points to or subtracts points from a buyer's account. .
        /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call .
        /// [AccumulateLoyaltyPoints]($e/Loyalty/AccumulateLoyaltyPoints) .
        /// to add points when a buyer pays for the purchase.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account]($m/LoyaltyAccount) in which to adjust the points..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AdjustLoyaltyPointsResponse response from the API call.</returns>
        public async Task<Models.AdjustLoyaltyPointsResponse> AdjustLoyaltyPointsAsync(
                string accountId,
                Models.AdjustLoyaltyPointsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/accounts/{account_id}/adjust");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "account_id", accountId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.AdjustLoyaltyPointsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches for loyalty events.
        /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a .
        /// buyer's loyalty account. Each change in the point balance .
        /// (for example, points earned, points redeemed, and points expired) is .
        /// recorded in the ledger. Using this endpoint, you can search the ledger for events.
        /// Search results are sorted by `created_at` in descending order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchLoyaltyEventsResponse response from the API call.</returns>
        public Models.SearchLoyaltyEventsResponse SearchLoyaltyEvents(
                Models.SearchLoyaltyEventsRequest body)
        {
            Task<Models.SearchLoyaltyEventsResponse> t = this.SearchLoyaltyEventsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for loyalty events.
        /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a .
        /// buyer's loyalty account. Each change in the point balance .
        /// (for example, points earned, points redeemed, and points expired) is .
        /// recorded in the ledger. Using this endpoint, you can search the ledger for events.
        /// Search results are sorted by `created_at` in descending order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchLoyaltyEventsResponse response from the API call.</returns>
        public async Task<Models.SearchLoyaltyEventsResponse> SearchLoyaltyEventsAsync(
                Models.SearchLoyaltyEventsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/events/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchLoyaltyEventsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a list of loyalty programs in the seller's account.
        /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// Replaced with [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) when used with the keyword `main`.
        /// </summary>
        /// <returns>Returns the Models.ListLoyaltyProgramsResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListLoyaltyProgramsResponse ListLoyaltyPrograms()
        {
            Task<Models.ListLoyaltyProgramsResponse> t = this.ListLoyaltyProgramsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of loyalty programs in the seller's account.
        /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// Replaced with [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) when used with the keyword `main`.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLoyaltyProgramsResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListLoyaltyProgramsResponse> ListLoyaltyProgramsAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListLoyaltyProgramsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves the loyalty program in a seller's account, specified by the program ID or the keyword `main`. .
        /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the loyalty program or the keyword `main`. Either value can be used to retrieve the single loyalty program that belongs to the seller..</param>
        /// <returns>Returns the Models.RetrieveLoyaltyProgramResponse response from the API call.</returns>
        public Models.RetrieveLoyaltyProgramResponse RetrieveLoyaltyProgram(
                string programId)
        {
            Task<Models.RetrieveLoyaltyProgramResponse> t = this.RetrieveLoyaltyProgramAsync(programId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the loyalty program in a seller's account, specified by the program ID or the keyword `main`. .
        /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the loyalty program or the keyword `main`. Either value can be used to retrieve the single loyalty program that belongs to the seller..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLoyaltyProgramResponse response from the API call.</returns>
        public async Task<Models.RetrieveLoyaltyProgramResponse> RetrieveLoyaltyProgramAsync(
                string programId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs/{program_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "program_id", programId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveLoyaltyProgramResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Calculates the points a purchase earns.
        /// - If you are using the Orders API to manage orders, you provide the `order_id` in the request. The .
        /// endpoint calculates the points by reading the order.
        /// - If you are not using the Orders API to manage orders, you provide the purchase amount in .
        /// the request for the endpoint to calculate the points.
        /// An application might call this endpoint to show the points that a buyer can earn with the .
        /// specific purchase.
        /// For spend-based and visit-based programs, the `tax_mode` setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
        /// </summary>
        /// <param name="programId">Required parameter: The [loyalty program]($m/LoyaltyProgram) ID, which defines the rules for accruing points..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CalculateLoyaltyPointsResponse response from the API call.</returns>
        public Models.CalculateLoyaltyPointsResponse CalculateLoyaltyPoints(
                string programId,
                Models.CalculateLoyaltyPointsRequest body)
        {
            Task<Models.CalculateLoyaltyPointsResponse> t = this.CalculateLoyaltyPointsAsync(programId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Calculates the points a purchase earns.
        /// - If you are using the Orders API to manage orders, you provide the `order_id` in the request. The .
        /// endpoint calculates the points by reading the order.
        /// - If you are not using the Orders API to manage orders, you provide the purchase amount in .
        /// the request for the endpoint to calculate the points.
        /// An application might call this endpoint to show the points that a buyer can earn with the .
        /// specific purchase.
        /// For spend-based and visit-based programs, the `tax_mode` setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
        /// </summary>
        /// <param name="programId">Required parameter: The [loyalty program]($m/LoyaltyProgram) ID, which defines the rules for accruing points..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CalculateLoyaltyPointsResponse response from the API call.</returns>
        public async Task<Models.CalculateLoyaltyPointsResponse> CalculateLoyaltyPointsAsync(
                string programId,
                Models.CalculateLoyaltyPointsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs/{program_id}/calculate");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "program_id", programId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CalculateLoyaltyPointsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a loyalty reward. In the process, the endpoint does following:.
        /// - Uses the `reward_tier_id` in the request to determine the number of points .
        /// to lock for this reward. .
        /// - If the request includes `order_id`, it adds the reward and related discount to the order. .
        /// After a reward is created, the points are locked and .
        /// not available for the buyer to redeem another reward.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateLoyaltyRewardResponse response from the API call.</returns>
        public Models.CreateLoyaltyRewardResponse CreateLoyaltyReward(
                Models.CreateLoyaltyRewardRequest body)
        {
            Task<Models.CreateLoyaltyRewardResponse> t = this.CreateLoyaltyRewardAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a loyalty reward. In the process, the endpoint does following:.
        /// - Uses the `reward_tier_id` in the request to determine the number of points .
        /// to lock for this reward. .
        /// - If the request includes `order_id`, it adds the reward and related discount to the order. .
        /// After a reward is created, the points are locked and .
        /// not available for the buyer to redeem another reward.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateLoyaltyRewardResponse response from the API call.</returns>
        public async Task<Models.CreateLoyaltyRewardResponse> CreateLoyaltyRewardAsync(
                Models.CreateLoyaltyRewardRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/rewards");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateLoyaltyRewardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches for loyalty rewards in a loyalty account. .
        /// In the current implementation, the endpoint supports search by the reward `status`.
        /// If you know a reward ID, use the .
        /// [RetrieveLoyaltyReward]($e/Loyalty/RetrieveLoyaltyReward) endpoint.
        /// Search results are sorted by `updated_at` in descending order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchLoyaltyRewardsResponse response from the API call.</returns>
        public Models.SearchLoyaltyRewardsResponse SearchLoyaltyRewards(
                Models.SearchLoyaltyRewardsRequest body)
        {
            Task<Models.SearchLoyaltyRewardsResponse> t = this.SearchLoyaltyRewardsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for loyalty rewards in a loyalty account. .
        /// In the current implementation, the endpoint supports search by the reward `status`.
        /// If you know a reward ID, use the .
        /// [RetrieveLoyaltyReward]($e/Loyalty/RetrieveLoyaltyReward) endpoint.
        /// Search results are sorted by `updated_at` in descending order.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchLoyaltyRewardsResponse response from the API call.</returns>
        public async Task<Models.SearchLoyaltyRewardsResponse> SearchLoyaltyRewardsAsync(
                Models.SearchLoyaltyRewardsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/rewards/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchLoyaltyRewardsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a loyalty reward by doing the following:.
        /// - Returns the loyalty points back to the loyalty account.
        /// - If an order ID was specified when the reward was created .
        /// (see [CreateLoyaltyReward]($e/Loyalty/CreateLoyaltyReward)), .
        /// it updates the order by removing the reward and related .
        /// discounts.
        /// You cannot delete a reward that has reached the terminal state (REDEEMED).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward]($m/LoyaltyReward) to delete..</param>
        /// <returns>Returns the Models.DeleteLoyaltyRewardResponse response from the API call.</returns>
        public Models.DeleteLoyaltyRewardResponse DeleteLoyaltyReward(
                string rewardId)
        {
            Task<Models.DeleteLoyaltyRewardResponse> t = this.DeleteLoyaltyRewardAsync(rewardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a loyalty reward by doing the following:.
        /// - Returns the loyalty points back to the loyalty account.
        /// - If an order ID was specified when the reward was created .
        /// (see [CreateLoyaltyReward]($e/Loyalty/CreateLoyaltyReward)), .
        /// it updates the order by removing the reward and related .
        /// discounts.
        /// You cannot delete a reward that has reached the terminal state (REDEEMED).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward]($m/LoyaltyReward) to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteLoyaltyRewardResponse response from the API call.</returns>
        public async Task<Models.DeleteLoyaltyRewardResponse> DeleteLoyaltyRewardAsync(
                string rewardId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/rewards/{reward_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "reward_id", rewardId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteLoyaltyRewardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a loyalty reward.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward]($m/LoyaltyReward) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveLoyaltyRewardResponse response from the API call.</returns>
        public Models.RetrieveLoyaltyRewardResponse RetrieveLoyaltyReward(
                string rewardId)
        {
            Task<Models.RetrieveLoyaltyRewardResponse> t = this.RetrieveLoyaltyRewardAsync(rewardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a loyalty reward.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward]($m/LoyaltyReward) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLoyaltyRewardResponse response from the API call.</returns>
        public async Task<Models.RetrieveLoyaltyRewardResponse> RetrieveLoyaltyRewardAsync(
                string rewardId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/rewards/{reward_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "reward_id", rewardId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveLoyaltyRewardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Redeems a loyalty reward.
        /// The endpoint sets the reward to the `REDEEMED` terminal state. .
        /// If you are using your own order processing system (not using the .
        /// Orders API), you call this endpoint after the buyer paid for the .
        /// purchase.
        /// After the reward reaches the terminal state, it cannot be deleted. .
        /// In other words, points used for the reward cannot be returned .
        /// to the account.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward]($m/LoyaltyReward) to redeem..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RedeemLoyaltyRewardResponse response from the API call.</returns>
        public Models.RedeemLoyaltyRewardResponse RedeemLoyaltyReward(
                string rewardId,
                Models.RedeemLoyaltyRewardRequest body)
        {
            Task<Models.RedeemLoyaltyRewardResponse> t = this.RedeemLoyaltyRewardAsync(rewardId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Redeems a loyalty reward.
        /// The endpoint sets the reward to the `REDEEMED` terminal state. .
        /// If you are using your own order processing system (not using the .
        /// Orders API), you call this endpoint after the buyer paid for the .
        /// purchase.
        /// After the reward reaches the terminal state, it cannot be deleted. .
        /// In other words, points used for the reward cannot be returned .
        /// to the account.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward]($m/LoyaltyReward) to redeem..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RedeemLoyaltyRewardResponse response from the API call.</returns>
        public async Task<Models.RedeemLoyaltyRewardResponse> RedeemLoyaltyRewardAsync(
                string rewardId,
                Models.RedeemLoyaltyRewardRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/rewards/{reward_id}/redeem");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "reward_id", rewardId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RedeemLoyaltyRewardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}