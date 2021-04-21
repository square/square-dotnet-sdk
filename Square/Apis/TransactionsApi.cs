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
    /// TransactionsApi.
    /// </summary>
    internal class TransactionsApi : BaseApi, ITransactionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal TransactionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Lists refunds for one of a business's locations..
        /// In addition to full or partial tender refunds processed through Square APIs,.
        /// refunds may result from itemized returns or exchanges through Square's.
        /// Point of Sale applications..
        /// Refunds with a `status` of `PENDING` are not currently included in this.
        /// endpoint's response..
        /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <returns>Returns the Models.ListRefundsResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListRefundsResponse ListRefunds(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            Task<Models.ListRefundsResponse> t = this.ListRefundsAsync(locationId, beginTime, endTime, sortOrder, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists refunds for one of a business's locations..
        /// In addition to full or partial tender refunds processed through Square APIs,.
        /// refunds may result from itemized returns or exchanges through Square's.
        /// Point of Sale applications..
        /// Refunds with a `status` of `PENDING` are not currently included in this.
        /// endpoint's response..
        /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListRefundsResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListRefundsResponse> ListRefundsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/refunds");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListRefundsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Lists transactions for a particular location..
        /// Transactions include payment information from sales and exchanges and refund.
        /// information from returns and exchanges..
        /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <returns>Returns the Models.ListTransactionsResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListTransactionsResponse ListTransactions(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            Task<Models.ListTransactionsResponse> t = this.ListTransactionsAsync(locationId, beginTime, endTime, sortOrder, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists transactions for a particular location..
        /// Transactions include payment information from sales and exchanges and refund.
        /// information from returns and exchanges..
        /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for..</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.  Default value: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTransactionsResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListTransactionsResponse> ListTransactionsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/transactions");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListTransactionsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Charges a card represented by a card nonce or a customer's card on file..
        /// Your request to this endpoint must include _either_:.
        /// - A value for the `card_nonce` parameter (to charge a card nonce generated.
        /// with the `SqPaymentForm`).
        /// - Values for the `customer_card_id` and `customer_id` parameters (to charge.
        /// a customer's card on file).
        /// In order for an eCommerce payment to potentially qualify for.
        /// [Square chargeback protection](https://squareup.com/help/article/5394), you.
        /// _must_ provide values for the following parameters in your request:.
        /// - `buyer_email_address`.
        /// - At least one of `billing_address` or `shipping_address`.
        /// When this response is returned, the amount of Square's processing fee might not yet be.
        /// calculated. To obtain the processing fee, wait about ten seconds and call.
        /// [RetrieveTransaction]($e/Transactions/RetrieveTransaction). See the `processing_fee_money`.
        /// field of each [Tender included]($m/Tender) in the transaction..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to associate the created transaction with..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ChargeResponse response from the API call.</returns>
        [Obsolete]
        public Models.ChargeResponse Charge(
                string locationId,
                Models.ChargeRequest body)
        {
            Task<Models.ChargeResponse> t = this.ChargeAsync(locationId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Charges a card represented by a card nonce or a customer's card on file..
        /// Your request to this endpoint must include _either_:.
        /// - A value for the `card_nonce` parameter (to charge a card nonce generated.
        /// with the `SqPaymentForm`).
        /// - Values for the `customer_card_id` and `customer_id` parameters (to charge.
        /// a customer's card on file).
        /// In order for an eCommerce payment to potentially qualify for.
        /// [Square chargeback protection](https://squareup.com/help/article/5394), you.
        /// _must_ provide values for the following parameters in your request:.
        /// - `buyer_email_address`.
        /// - At least one of `billing_address` or `shipping_address`.
        /// When this response is returned, the amount of Square's processing fee might not yet be.
        /// calculated. To obtain the processing fee, wait about ten seconds and call.
        /// [RetrieveTransaction]($e/Transactions/RetrieveTransaction). See the `processing_fee_money`.
        /// field of each [Tender included]($m/Tender) in the transaction..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to associate the created transaction with..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ChargeResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ChargeResponse> ChargeAsync(
                string locationId,
                Models.ChargeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/transactions");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ChargeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves details for a single transaction..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTransactionResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveTransactionResponse RetrieveTransaction(
                string locationId,
                string transactionId)
        {
            Task<Models.RetrieveTransactionResponse> t = this.RetrieveTransactionAsync(locationId, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves details for a single transaction..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTransactionResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveTransactionResponse> RetrieveTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveTransactionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Captures a transaction that was created with the [Charge]($e/Transactions/Charge).
        /// endpoint with a `delay_capture` value of `true`..
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information..
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CaptureTransactionResponse response from the API call.</returns>
        [Obsolete]
        public Models.CaptureTransactionResponse CaptureTransaction(
                string locationId,
                string transactionId)
        {
            Task<Models.CaptureTransactionResponse> t = this.CaptureTransactionAsync(locationId, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Captures a transaction that was created with the [Charge]($e/Transactions/Charge).
        /// endpoint with a `delay_capture` value of `true`..
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information..
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CaptureTransactionResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CaptureTransactionResponse> CaptureTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}/capture");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CaptureTransactionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Initiates a refund for a previously charged tender..
        /// You must issue a refund within 120 days of the associated payment. See.
        /// [this article](https://squareup.com/help/us/en/article/5060) for more information.
        /// on refund behavior..
        /// NOTE: Card-present transactions with Interac credit cards **cannot be.
        /// refunded using the Connect API**. Interac transactions must refunded.
        /// in-person (e.g., dipping the card using POS app)..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the original transaction that includes the tender to refund..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateRefundResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateRefundResponse CreateRefund(
                string locationId,
                string transactionId,
                Models.CreateRefundRequest body)
        {
            Task<Models.CreateRefundResponse> t = this.CreateRefundAsync(locationId, transactionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Initiates a refund for a previously charged tender..
        /// You must issue a refund within 120 days of the associated payment. See.
        /// [this article](https://squareup.com/help/us/en/article/5060) for more information.
        /// on refund behavior..
        /// NOTE: Card-present transactions with Interac credit cards **cannot be.
        /// refunded using the Connect API**. Interac transactions must refunded.
        /// in-person (e.g., dipping the card using POS app)..
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original transaction's associated location..</param>
        /// <param name="transactionId">Required parameter: The ID of the original transaction that includes the tender to refund..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateRefundResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateRefundResponse> CreateRefundAsync(
                string locationId,
                string transactionId,
                Models.CreateRefundRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}/refund");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateRefundResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Cancels a transaction that was created with the [Charge]($e/Transactions/Charge).
        /// endpoint with a `delay_capture` value of `true`..
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information..
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.VoidTransactionResponse response from the API call.</returns>
        [Obsolete]
        public Models.VoidTransactionResponse VoidTransaction(
                string locationId,
                string transactionId)
        {
            Task<Models.VoidTransactionResponse> t = this.VoidTransactionAsync(locationId, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels a transaction that was created with the [Charge]($e/Transactions/Charge).
        /// endpoint with a `delay_capture` value of `true`..
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture).
        /// for more information..
        /// </summary>
        /// <param name="locationId">Required parameter: Example: .</param>
        /// <param name="transactionId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.VoidTransactionResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.VoidTransactionResponse> VoidTransactionAsync(
                string locationId,
                string transactionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}/void");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.VoidTransactionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}