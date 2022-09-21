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
    using Square.Http.Request.Configuration;
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Adds points earned from a purchase to a [loyalty account]($m/LoyaltyAccount).
        /// - If you are using the Orders API to manage orders, provide the `order_id`. Square reads the order.
        /// to compute the points earned from both the base loyalty program and an associated.
        /// [loyalty promotion]($m/LoyaltyPromotion). For purchases that qualify for multiple accrual.
        /// rules, Square computes points based on the accrual rule that grants the most points.
        /// For purchases that qualify for multiple promotions, Square computes points based on the most.
        /// recently created promotion. A purchase must first qualify for program points to be eligible for promotion points.
        /// - If you are not using the Orders API to manage orders, provide `points` with the number of points to add.
        /// You must first perform a client-side computation of the points earned from the loyalty program and.
        /// loyalty promotion. For spend-based and visit-based programs, you can call [CalculateLoyaltyPoints]($e/Loyalty/CalculateLoyaltyPoints).
        /// to compute the points earned from the base loyalty program. For information about computing points earned from a loyalty promotion, see.
        /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the target [loyalty account]($m/LoyaltyAccount)..</param>
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
        /// Adds points earned from a purchase to a [loyalty account]($m/LoyaltyAccount).
        /// - If you are using the Orders API to manage orders, provide the `order_id`. Square reads the order.
        /// to compute the points earned from both the base loyalty program and an associated.
        /// [loyalty promotion]($m/LoyaltyPromotion). For purchases that qualify for multiple accrual.
        /// rules, Square computes points based on the accrual rule that grants the most points.
        /// For purchases that qualify for multiple promotions, Square computes points based on the most.
        /// recently created promotion. A purchase must first qualify for program points to be eligible for promotion points.
        /// - If you are not using the Orders API to manage orders, provide `points` with the number of points to add.
        /// You must first perform a client-side computation of the points earned from the loyalty program and.
        /// loyalty promotion. For spend-based and visit-based programs, you can call [CalculateLoyaltyPoints]($e/Loyalty/CalculateLoyaltyPoints).
        /// to compute the points earned from the base loyalty program. For information about computing points earned from a loyalty promotion, see.
        /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the target [loyalty account]($m/LoyaltyAccount)..</param>
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="accountId">Required parameter: The ID of the target [loyalty account]($m/LoyaltyAccount)..</param>
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
        /// <param name="accountId">Required parameter: The ID of the target [loyalty account]($m/LoyaltyAccount)..</param>
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Calculates the number of points a buyer can earn from a purchase. Applications might call this endpoint.
        /// to display the points to the buyer.
        /// - If you are using the Orders API to manage orders, provide the `order_id` and (optional) `loyalty_account_id`.
        /// Square reads the order to compute the points earned from the base loyalty program and an associated.
        /// [loyalty promotion]($m/LoyaltyPromotion).
        /// - If you are not using the Orders API to manage orders, provide `transaction_amount_money` with the.
        /// purchase amount. Square uses this amount to calculate the points earned from the base loyalty program,.
        /// but not points earned from a loyalty promotion. For spend-based and visit-based programs, the `tax_mode`.
        /// setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
        /// If the purchase qualifies for program points, call.
        /// [ListLoyaltyPromotions]($e/Loyalty/ListLoyaltyPromotions) and perform a client-side computation.
        /// to calculate whether the purchase also qualifies for promotion points. For more information, see.
        /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the [loyalty program]($m/LoyaltyProgram), which defines the rules for accruing points..</param>
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
        /// Calculates the number of points a buyer can earn from a purchase. Applications might call this endpoint.
        /// to display the points to the buyer.
        /// - If you are using the Orders API to manage orders, provide the `order_id` and (optional) `loyalty_account_id`.
        /// Square reads the order to compute the points earned from the base loyalty program and an associated.
        /// [loyalty promotion]($m/LoyaltyPromotion).
        /// - If you are not using the Orders API to manage orders, provide `transaction_amount_money` with the.
        /// purchase amount. Square uses this amount to calculate the points earned from the base loyalty program,.
        /// but not points earned from a loyalty promotion. For spend-based and visit-based programs, the `tax_mode`.
        /// setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
        /// If the purchase qualifies for program points, call.
        /// [ListLoyaltyPromotions]($e/Loyalty/ListLoyaltyPromotions) and perform a client-side computation.
        /// to calculate whether the purchase also qualifies for promotion points. For more information, see.
        /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the [loyalty program]($m/LoyaltyProgram), which defines the rules for accruing points..</param>
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Lists the loyalty promotions associated with a [loyalty program]($m/LoyaltyProgram).
        /// Results are sorted by the `created_at` date in descending order (newest to oldest).
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the base [loyalty program]($m/LoyaltyProgram). To get the program ID, call [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) using the `main` keyword..</param>
        /// <param name="status">Optional parameter: The status to filter the results by. If a status is provided, only loyalty promotions with the specified status are returned. Otherwise, all loyalty promotions associated with the loyalty program are returned..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. The minimum value is 1 and the maximum value is 30. The default value is 30. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListLoyaltyPromotionsResponse response from the API call.</returns>
        public Models.ListLoyaltyPromotionsResponse ListLoyaltyPromotions(
                string programId,
                string status = null,
                string cursor = null,
                int? limit = null)
        {
            Task<Models.ListLoyaltyPromotionsResponse> t = this.ListLoyaltyPromotionsAsync(programId, status, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists the loyalty promotions associated with a [loyalty program]($m/LoyaltyProgram).
        /// Results are sorted by the `created_at` date in descending order (newest to oldest).
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the base [loyalty program]($m/LoyaltyProgram). To get the program ID, call [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) using the `main` keyword..</param>
        /// <param name="status">Optional parameter: The status to filter the results by. If a status is provided, only loyalty promotions with the specified status are returned. Otherwise, all loyalty promotions associated with the loyalty program are returned..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. The minimum value is 1 and the maximum value is 30. The default value is 30. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLoyaltyPromotionsResponse response from the API call.</returns>
        public async Task<Models.ListLoyaltyPromotionsResponse> ListLoyaltyPromotionsAsync(
                string programId,
                string status = null,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs/{program_id}/promotions");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "program_id", programId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "status", status },
                { "cursor", cursor },
                { "limit", limit },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListLoyaltyPromotionsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a loyalty promotion for a [loyalty program]($m/LoyaltyProgram). A loyalty promotion.
        /// enables buyers to earn points in addition to those earned from the base loyalty program.
        /// This endpoint sets the loyalty promotion to the `ACTIVE` or `SCHEDULED` status, depending on the.
        /// `available_time` setting. A loyalty program can have a maximum of 10 loyalty promotions with an.
        /// `ACTIVE` or `SCHEDULED` status.
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the [loyalty program]($m/LoyaltyProgram) to associate with the promotion. To get the program ID, call [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) using the `main` keyword..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateLoyaltyPromotionResponse response from the API call.</returns>
        public Models.CreateLoyaltyPromotionResponse CreateLoyaltyPromotion(
                string programId,
                Models.CreateLoyaltyPromotionRequest body)
        {
            Task<Models.CreateLoyaltyPromotionResponse> t = this.CreateLoyaltyPromotionAsync(programId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a loyalty promotion for a [loyalty program]($m/LoyaltyProgram). A loyalty promotion.
        /// enables buyers to earn points in addition to those earned from the base loyalty program.
        /// This endpoint sets the loyalty promotion to the `ACTIVE` or `SCHEDULED` status, depending on the.
        /// `available_time` setting. A loyalty program can have a maximum of 10 loyalty promotions with an.
        /// `ACTIVE` or `SCHEDULED` status.
        /// </summary>
        /// <param name="programId">Required parameter: The ID of the [loyalty program]($m/LoyaltyProgram) to associate with the promotion. To get the program ID, call [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) using the `main` keyword..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateLoyaltyPromotionResponse response from the API call.</returns>
        public async Task<Models.CreateLoyaltyPromotionResponse> CreateLoyaltyPromotionAsync(
                string programId,
                Models.CreateLoyaltyPromotionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs/{program_id}/promotions");

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateLoyaltyPromotionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a loyalty promotion.
        /// </summary>
        /// <param name="promotionId">Required parameter: The ID of the [loyalty promotion]($m/LoyaltyPromotion) to retrieve..</param>
        /// <param name="programId">Required parameter: The ID of the base [loyalty program]($m/LoyaltyProgram). To get the program ID, call [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) using the `main` keyword..</param>
        /// <returns>Returns the Models.RetrieveLoyaltyPromotionResponse response from the API call.</returns>
        public Models.RetrieveLoyaltyPromotionResponse RetrieveLoyaltyPromotion(
                string promotionId,
                string programId)
        {
            Task<Models.RetrieveLoyaltyPromotionResponse> t = this.RetrieveLoyaltyPromotionAsync(promotionId, programId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a loyalty promotion.
        /// </summary>
        /// <param name="promotionId">Required parameter: The ID of the [loyalty promotion]($m/LoyaltyPromotion) to retrieve..</param>
        /// <param name="programId">Required parameter: The ID of the base [loyalty program]($m/LoyaltyProgram). To get the program ID, call [RetrieveLoyaltyProgram]($e/Loyalty/RetrieveLoyaltyProgram) using the `main` keyword..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLoyaltyPromotionResponse response from the API call.</returns>
        public async Task<Models.RetrieveLoyaltyPromotionResponse> RetrieveLoyaltyPromotionAsync(
                string promotionId,
                string programId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs/{program_id}/promotions/{promotion_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "promotion_id", promotionId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveLoyaltyPromotionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Cancels a loyalty promotion. Use this endpoint to cancel an `ACTIVE` promotion earlier than the.
        /// end date, cancel an `ACTIVE` promotion when an end date is not specified, or cancel a `SCHEDULED` promotion.
        /// Because updating a promotion is not supported, you can also use this endpoint to cancel a promotion before.
        /// you create a new one.
        /// This endpoint sets the loyalty promotion to the `CANCELED` state.
        /// </summary>
        /// <param name="promotionId">Required parameter: The ID of the [loyalty promotion]($m/LoyaltyPromotion) to cancel. You can cancel a promotion that has an `ACTIVE` or `SCHEDULED` status..</param>
        /// <param name="programId">Required parameter: The ID of the base [loyalty program]($m/LoyaltyProgram)..</param>
        /// <returns>Returns the Models.CancelLoyaltyPromotionResponse response from the API call.</returns>
        public Models.CancelLoyaltyPromotionResponse CancelLoyaltyPromotion(
                string promotionId,
                string programId)
        {
            Task<Models.CancelLoyaltyPromotionResponse> t = this.CancelLoyaltyPromotionAsync(promotionId, programId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels a loyalty promotion. Use this endpoint to cancel an `ACTIVE` promotion earlier than the.
        /// end date, cancel an `ACTIVE` promotion when an end date is not specified, or cancel a `SCHEDULED` promotion.
        /// Because updating a promotion is not supported, you can also use this endpoint to cancel a promotion before.
        /// you create a new one.
        /// This endpoint sets the loyalty promotion to the `CANCELED` state.
        /// </summary>
        /// <param name="promotionId">Required parameter: The ID of the [loyalty promotion]($m/LoyaltyPromotion) to cancel. You can cancel a promotion that has an `ACTIVE` or `SCHEDULED` status..</param>
        /// <param name="programId">Required parameter: The ID of the base [loyalty program]($m/LoyaltyProgram)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelLoyaltyPromotionResponse response from the API call.</returns>
        public async Task<Models.CancelLoyaltyPromotionResponse> CancelLoyaltyPromotionAsync(
                string promotionId,
                string programId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/loyalty/programs/{program_id}/promotions/{promotion_id}/cancel");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "promotion_id", promotionId },
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
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CancelLoyaltyPromotionResponse>(response.Body);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts. .
        /// If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.
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
        /// Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts. .
        /// If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
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