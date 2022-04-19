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
    /// CardsApi.
    /// </summary>
    internal class CardsApi : BaseApi, ICardsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CardsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieves a list of cards owned by the account making the request.
        /// A max of 25 cards will be returned.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information..</param>
        /// <param name="customerId">Optional parameter: Limit results to cards associated with the customer supplied. By default, all cards owned by the merchant are returned..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled cards. By default, all enabled cards owned by the merchant are returned..</param>
        /// <param name="referenceId">Optional parameter: Limit results to cards associated with the reference_id supplied..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the card was created with the specified order. This field defaults to ASC..</param>
        /// <returns>Returns the Models.ListCardsResponse response from the API call.</returns>
        public Models.ListCardsResponse ListCards(
                string cursor = null,
                string customerId = null,
                bool? includeDisabled = false,
                string referenceId = null,
                string sortOrder = null)
        {
            Task<Models.ListCardsResponse> t = this.ListCardsAsync(cursor, customerId, includeDisabled, referenceId, sortOrder);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a list of cards owned by the account making the request.
        /// A max of 25 cards will be returned.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information..</param>
        /// <param name="customerId">Optional parameter: Limit results to cards associated with the customer supplied. By default, all cards owned by the merchant are returned..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled cards. By default, all enabled cards owned by the merchant are returned..</param>
        /// <param name="referenceId">Optional parameter: Limit results to cards associated with the reference_id supplied..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the card was created with the specified order. This field defaults to ASC..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCardsResponse response from the API call.</returns>
        public async Task<Models.ListCardsResponse> ListCardsAsync(
                string cursor = null,
                string customerId = null,
                bool? includeDisabled = false,
                string referenceId = null,
                string sortOrder = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cards");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "customer_id", customerId },
                { "include_disabled", (includeDisabled != null) ? includeDisabled : false },
                { "reference_id", referenceId },
                { "sort_order", sortOrder },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListCardsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Adds a card on file to an existing merchant.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCardResponse response from the API call.</returns>
        public Models.CreateCardResponse CreateCard(
                Models.CreateCardRequest body)
        {
            Task<Models.CreateCardResponse> t = this.CreateCardAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds a card on file to an existing merchant.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCardResponse response from the API call.</returns>
        public async Task<Models.CreateCardResponse> CreateCardAsync(
                Models.CreateCardRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cards");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateCardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves details for a specific Card.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <returns>Returns the Models.RetrieveCardResponse response from the API call.</returns>
        public Models.RetrieveCardResponse RetrieveCard(
                string cardId)
        {
            Task<Models.RetrieveCardResponse> t = this.RetrieveCardAsync(cardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves details for a specific Card.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCardResponse response from the API call.</returns>
        public async Task<Models.RetrieveCardResponse> RetrieveCardAsync(
                string cardId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cards/{card_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "card_id", cardId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Disables the card, preventing any further updates or charges.
        /// Disabling an already disabled card is allowed but has no effect.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <returns>Returns the Models.DisableCardResponse response from the API call.</returns>
        public Models.DisableCardResponse DisableCard(
                string cardId)
        {
            Task<Models.DisableCardResponse> t = this.DisableCardAsync(cardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Disables the card, preventing any further updates or charges.
        /// Disabling an already disabled card is allowed but has no effect.
        /// </summary>
        /// <param name="cardId">Required parameter: Unique ID for the desired Card..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DisableCardResponse response from the API call.</returns>
        public async Task<Models.DisableCardResponse> DisableCardAsync(
                string cardId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/cards/{card_id}/disable");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "card_id", cardId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.DisableCardResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}