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
    internal class TransactionsApi: BaseApi, ITransactionsApi
    {
        internal TransactionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Lists refunds for one of a business's locations.
        /// In addition to full or partial tender refunds processed through Square APIs,
        /// refunds may result from itemized returns or exchanges through Square's
        /// Point of Sale applications.
        /// Refunds with a `status` of `PENDING` are not currently included in this
        /// endpoint's response.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListRefundsResponse response from the API call</return>
        [Obsolete]
        public Models.ListRefundsResponse ListRefunds(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            Task<Models.ListRefundsResponse> t = ListRefundsAsync(locationId, beginTime, endTime, sortOrder, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists refunds for one of a business's locations.
        /// In addition to full or partial tender refunds processed through Square APIs,
        /// refunds may result from itemized returns or exchanges through Square's
        /// Point of Sale applications.
        /// Refunds with a `status` of `PENDING` are not currently included in this
        /// endpoint's response.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListRefundsResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ListRefundsResponse> ListRefundsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/refunds");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListRefundsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Lists transactions for a particular location.
        /// Transactions include payment information from sales and exchanges and refund
        /// information from returns and exchanges.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListTransactionsResponse response from the API call</return>
        [Obsolete]
        public Models.ListTransactionsResponse ListTransactions(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            Task<Models.ListTransactionsResponse> t = ListTransactionsAsync(locationId, beginTime, endTime, sortOrder, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists transactions for a particular location.
        /// Transactions include payment information from sales and exchanges and refund
        /// information from returns and exchanges.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list transactions for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListTransactionsResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ListTransactionsResponse> ListTransactionsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/transactions");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListTransactionsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Charges a card represented by a card nonce or a customer's card on file.
        /// Your request to this endpoint must include _either_:
        /// - A value for the `card_nonce` parameter (to charge a card nonce generated
        /// with the `SqPaymentForm`)
        /// - Values for the `customer_card_id` and `customer_id` parameters (to charge
        /// a customer's card on file)
        /// In order for an eCommerce payment to potentially qualify for
        /// [Square chargeback protection](https://squareup.com/help/article/5394), you
        /// _must_ provide values for the following parameters in your request:
        /// - `buyer_email_address`
        /// - At least one of `billing_address` or `shipping_address`
        /// When this response is returned, the amount of Square's processing fee might not yet be
        /// calculated. To obtain the processing fee, wait about ten seconds and call
        /// [RetrieveTransaction](#endpoint-retrievetransaction). See the `processing_fee_money`
        /// field of each [Tender included](#type-tender) in the transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to associate the created transaction with.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.ChargeResponse response from the API call</return>
        [Obsolete]
        public Models.ChargeResponse Charge(string locationId, Models.ChargeRequest body)
        {
            Task<Models.ChargeResponse> t = ChargeAsync(locationId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Charges a card represented by a card nonce or a customer's card on file.
        /// Your request to this endpoint must include _either_:
        /// - A value for the `card_nonce` parameter (to charge a card nonce generated
        /// with the `SqPaymentForm`)
        /// - Values for the `customer_card_id` and `customer_id` parameters (to charge
        /// a customer's card on file)
        /// In order for an eCommerce payment to potentially qualify for
        /// [Square chargeback protection](https://squareup.com/help/article/5394), you
        /// _must_ provide values for the following parameters in your request:
        /// - `buyer_email_address`
        /// - At least one of `billing_address` or `shipping_address`
        /// When this response is returned, the amount of Square's processing fee might not yet be
        /// calculated. To obtain the processing fee, wait about ten seconds and call
        /// [RetrieveTransaction](#endpoint-retrievetransaction). See the `processing_fee_money`
        /// field of each [Tender included](#type-tender) in the transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to associate the created transaction with.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.ChargeResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ChargeResponse> ChargeAsync(string locationId, Models.ChargeRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/transactions");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ChargeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve.</param>
        /// <return>Returns the Models.RetrieveTransactionResponse response from the API call</return>
        [Obsolete]
        public Models.RetrieveTransactionResponse RetrieveTransaction(string locationId, string transactionId)
        {
            Task<Models.RetrieveTransactionResponse> t = RetrieveTransactionAsync(locationId, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves details for a single transaction.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the transaction to retrieve.</param>
        /// <return>Returns the Models.RetrieveTransactionResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.RetrieveTransactionResponse> RetrieveTransactionAsync(string locationId, string transactionId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveTransactionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Captures a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.CaptureTransactionResponse response from the API call</return>
        [Obsolete]
        public Models.CaptureTransactionResponse CaptureTransaction(string locationId, string transactionId)
        {
            Task<Models.CaptureTransactionResponse> t = CaptureTransactionAsync(locationId, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Captures a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.CaptureTransactionResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.CaptureTransactionResponse> CaptureTransactionAsync(string locationId, string transactionId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}/capture");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId }
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
            HttpRequest _request = GetClientInstance().Post(_queryUrl, _headers, null);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CaptureTransactionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Initiates a refund for a previously charged tender.
        /// You must issue a refund within 120 days of the associated payment. See
        /// [this article](https://squareup.com/help/us/en/article/5060) for more information
        /// on refund behavior.
        /// NOTE: Card-present transactions with Interac credit cards **cannot be
        /// refunded using the Connect API**. Interac transactions must refunded
        /// in-person (e.g., dipping the card using POS app).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the original transaction that includes the tender to refund.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateRefundResponse response from the API call</return>
        [Obsolete]
        public Models.CreateRefundResponse CreateRefund(string locationId, string transactionId, Models.CreateRefundRequest body)
        {
            Task<Models.CreateRefundResponse> t = CreateRefundAsync(locationId, transactionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Initiates a refund for a previously charged tender.
        /// You must issue a refund within 120 days of the associated payment. See
        /// [this article](https://squareup.com/help/us/en/article/5060) for more information
        /// on refund behavior.
        /// NOTE: Card-present transactions with Interac credit cards **cannot be
        /// refunded using the Connect API**. Interac transactions must refunded
        /// in-person (e.g., dipping the card using POS app).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original transaction's associated location.</param>
        /// <param name="transactionId">Required parameter: The ID of the original transaction that includes the tender to refund.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateRefundResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.CreateRefundResponse> CreateRefundAsync(string locationId, string transactionId, Models.CreateRefundRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}/refund");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateRefundResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Cancels a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.VoidTransactionResponse response from the API call</return>
        [Obsolete]
        public Models.VoidTransactionResponse VoidTransaction(string locationId, string transactionId)
        {
            Task<Models.VoidTransactionResponse> t = VoidTransactionAsync(locationId, transactionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels a transaction that was created with the [Charge](#endpoint-charge)
        /// endpoint with a `delay_capture` value of `true`.
        /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
        /// for more information.
        /// </summary>
        /// <param name="locationId">Required parameter: Example: </param>
        /// <param name="transactionId">Required parameter: Example: </param>
        /// <return>Returns the Models.VoidTransactionResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.VoidTransactionResponse> VoidTransactionAsync(string locationId, string transactionId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/transactions/{transaction_id}/void");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "transaction_id", transactionId }
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
            HttpRequest _request = GetClientInstance().Post(_queryUrl, _headers, null);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.VoidTransactionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}