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
    internal class V1TransactionsApi: BaseApi, IV1TransactionsApi
    {
        internal V1TransactionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Provides non-confidential details for all of a location's associated bank accounts. This endpoint does not provide full bank account numbers, and there is no way to obtain a full bank account number with the Connect API.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list bank accounts for.</param>
        /// <return>Returns the List<Models.V1BankAccount> response from the API call</return>
        [Obsolete]
        public List<Models.V1BankAccount> ListBankAccounts(string locationId)
        {
            Task<List<Models.V1BankAccount>> t = ListBankAccountsAsync(locationId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides non-confidential details for all of a location's associated bank accounts. This endpoint does not provide full bank account numbers, and there is no way to obtain a full bank account number with the Connect API.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list bank accounts for.</param>
        /// <return>Returns the List<Models.V1BankAccount> response from the API call</return>
        [Obsolete]
        public async Task<List<Models.V1BankAccount>> ListBankAccountsAsync(string locationId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/bank-accounts");

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

            var _responseModels = ApiHelper.JsonDeserialize<List<Models.V1BankAccount>>(_response.Body);
            _responseModels.ForEach(r => r.Context = _context);
            return _responseModels;
        }

        /// <summary>
        /// Provides non-confidential details for a merchant's associated bank account. This endpoint does not provide full bank account numbers, and there is no way to obtain a full bank account number with the Connect API.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the bank account's associated location.</param>
        /// <param name="bankAccountId">Required parameter: The bank account's Square-issued ID. You obtain this value from Settlement objects returned.</param>
        /// <return>Returns the Models.V1BankAccount response from the API call</return>
        [Obsolete]
        public Models.V1BankAccount RetrieveBankAccount(string locationId, string bankAccountId)
        {
            Task<Models.V1BankAccount> t = RetrieveBankAccountAsync(locationId, bankAccountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides non-confidential details for a merchant's associated bank account. This endpoint does not provide full bank account numbers, and there is no way to obtain a full bank account number with the Connect API.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the bank account's associated location.</param>
        /// <param name="bankAccountId">Required parameter: The bank account's Square-issued ID. You obtain this value from Settlement objects returned.</param>
        /// <return>Returns the Models.V1BankAccount response from the API call</return>
        [Obsolete]
        public async Task<Models.V1BankAccount> RetrieveBankAccountAsync(string locationId, string bankAccountId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/bank-accounts/{bank_account_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1BankAccount>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides summary information for a merchant's online store orders.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list online store orders for.</param>
        /// <param name="order">Optional parameter: TThe order in which payments are listed in the response.</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Order> response from the API call</return>
        public List<Models.V1Order> ListOrders(
                string locationId,
                string order = null,
                int? limit = null,
                string batchToken = null)
        {
            Task<List<Models.V1Order>> t = ListOrdersAsync(locationId, order, limit, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for a merchant's online store orders.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list online store orders for.</param>
        /// <param name="order">Optional parameter: TThe order in which payments are listed in the response.</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Order> response from the API call</return>
        public async Task<List<Models.V1Order>> ListOrdersAsync(
                string locationId,
                string order = null,
                int? limit = null,
                string batchToken = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/orders");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order", order },
                { "limit", limit },
                { "batch_token", batchToken }
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

            var _responseModels = ApiHelper.JsonDeserialize<List<Models.V1Order>>(_response.Body);
            _responseModels.ForEach(r => r.Context = _context);
            return _responseModels;
        }

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location.</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint</param>
        /// <return>Returns the Models.V1Order response from the API call</return>
        public Models.V1Order RetrieveOrder(string locationId, string orderId)
        {
            Task<Models.V1Order> t = RetrieveOrderAsync(locationId, orderId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides comprehensive information for a single online store order, including the order's history.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location.</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint</param>
        /// <return>Returns the Models.V1Order response from the API call</return>
        public async Task<Models.V1Order> RetrieveOrderAsync(string locationId, string orderId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/orders/{order_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "order_id", orderId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1Order>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location.</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Order response from the API call</return>
        public Models.V1Order UpdateOrder(string locationId, string orderId, Models.V1UpdateOrderRequest body)
        {
            Task<Models.V1Order> t = UpdateOrderAsync(locationId, orderId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the order's associated location.</param>
        /// <param name="orderId">Required parameter: The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Order response from the API call</return>
        public async Task<Models.V1Order> UpdateOrderAsync(string locationId, string orderId, Models.V1UpdateOrderRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/orders/{order_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "order_id", orderId }
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
            HttpRequest _request = GetClientInstance().PutBody(_queryUrl, _headers, _body);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1Order>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides summary information for all payments taken for a given
        /// Square account during a date range. Date ranges cannot exceed 1 year in
        /// length. See Date ranges for details of inclusive and exclusive dates.
        /// *Note**: Details for payments processed with Square Point of Sale while
        /// in offline mode may not be transmitted to Square for up to 72 hours.
        /// Offline payments have a `created_at` value that reflects the time the
        /// payment was originally processed, not the time it was subsequently
        /// transmitted to Square. Consequently, the ListPayments endpoint might
        /// list an offline payment chronologically between online payments that
        /// were seen in a previous request.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list payments for. If you specify me, this endpoint returns payments aggregated from all of the business's locations.</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <param name="includePartial">Optional parameter: Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed.</param>
        /// <return>Returns the List<Models.V1Payment> response from the API call</return>
        public List<Models.V1Payment> ListPayments(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null,
                bool? includePartial = false)
        {
            Task<List<Models.V1Payment>> t = ListPaymentsAsync(locationId, order, beginTime, endTime, limit, batchToken, includePartial);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for all payments taken for a given
        /// Square account during a date range. Date ranges cannot exceed 1 year in
        /// length. See Date ranges for details of inclusive and exclusive dates.
        /// *Note**: Details for payments processed with Square Point of Sale while
        /// in offline mode may not be transmitted to Square for up to 72 hours.
        /// Offline payments have a `created_at` value that reflects the time the
        /// payment was originally processed, not the time it was subsequently
        /// transmitted to Square. Consequently, the ListPayments endpoint might
        /// list an offline payment chronologically between online payments that
        /// were seen in a previous request.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list payments for. If you specify me, this endpoint returns payments aggregated from all of the business's locations.</param>
        /// <param name="order">Optional parameter: The order in which payments are listed in the response.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.</param>
        /// <param name="limit">Optional parameter: The maximum number of payments to return in a single response. This value cannot exceed 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <param name="includePartial">Optional parameter: Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed.</param>
        /// <return>Returns the List<Models.V1Payment> response from the API call</return>
        public async Task<List<Models.V1Payment>> ListPaymentsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null,
                bool? includePartial = false, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/payments");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "batch_token", batchToken },
                { "include_partial", (null != includePartial) ? includePartial : false }
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

            var _responseModels = ApiHelper.JsonDeserialize<List<Models.V1Payment>>(_response.Body);
            _responseModels.ForEach(r => r.Context = _context);
            return _responseModels;
        }

        /// <summary>
        /// Provides comprehensive information for a single payment.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the payment's associated location.</param>
        /// <param name="paymentId">Required parameter: The Square-issued payment ID. payment_id comes from Payment objects returned by the List Payments endpoint, Settlement objects returned by the List Settlements endpoint, or Refund objects returned by the List Refunds endpoint.</param>
        /// <return>Returns the Models.V1Payment response from the API call</return>
        public Models.V1Payment RetrievePayment(string locationId, string paymentId)
        {
            Task<Models.V1Payment> t = RetrievePaymentAsync(locationId, paymentId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides comprehensive information for a single payment.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the payment's associated location.</param>
        /// <param name="paymentId">Required parameter: The Square-issued payment ID. payment_id comes from Payment objects returned by the List Payments endpoint, Settlement objects returned by the List Settlements endpoint, or Refund objects returned by the List Refunds endpoint.</param>
        /// <return>Returns the Models.V1Payment response from the API call</return>
        public async Task<Models.V1Payment> RetrievePaymentAsync(string locationId, string paymentId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/payments/{payment_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "payment_id", paymentId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1Payment>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides the details for all refunds initiated by a merchant or any of the merchant's mobile staff during a date range. Date ranges cannot exceed one year in length.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for.</param>
        /// <param name="order">Optional parameter: TThe order in which payments are listed in the response.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.</param>
        /// <param name="limit">Optional parameter: The approximate number of refunds to return in a single response. Default: 100. Max: 200. Response may contain more results than the prescribed limit when refunds are made simultaneously to multiple tenders in a payment or when refunds are generated in an exchange to account for the value of returned goods.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Refund> response from the API call</return>
        public List<Models.V1Refund> ListRefunds(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null)
        {
            Task<List<Models.V1Refund>> t = ListRefundsAsync(locationId, order, beginTime, endTime, limit, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the details for all refunds initiated by a merchant or any of the merchant's mobile staff during a date range. Date ranges cannot exceed one year in length.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list refunds for.</param>
        /// <param name="order">Optional parameter: TThe order in which payments are listed in the response.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.</param>
        /// <param name="limit">Optional parameter: The approximate number of refunds to return in a single response. Default: 100. Max: 200. Response may contain more results than the prescribed limit when refunds are made simultaneously to multiple tenders in a payment or when refunds are generated in an exchange to account for the value of returned goods.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Refund> response from the API call</return>
        public async Task<List<Models.V1Refund>> ListRefundsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string batchToken = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/refunds");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "batch_token", batchToken }
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

            var _responseModels = ApiHelper.JsonDeserialize<List<Models.V1Refund>>(_response.Body);
            _responseModels.ForEach(r => r.Context = _context);
            return _responseModels;
        }

        /// <summary>
        /// Issues a refund for a previously processed payment. You must issue
        /// a refund within 60 days of the associated payment.
        /// You cannot issue a partial refund for a split tender payment. You must
        /// instead issue a full or partial refund for a particular tender, by
        /// providing the applicable tender id to the V1CreateRefund endpoint.
        /// Issuing a full refund for a split tender payment refunds all tenders
        /// associated with the payment.
        /// Issuing a refund for a card payment is not reversible. For development
        /// purposes, you can create fake cash payments in Square Point of Sale and
        /// refund them.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original payment's associated location.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Refund response from the API call</return>
        public Models.V1Refund CreateRefund(string locationId, Models.V1CreateRefundRequest body)
        {
            Task<Models.V1Refund> t = CreateRefundAsync(locationId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Issues a refund for a previously processed payment. You must issue
        /// a refund within 60 days of the associated payment.
        /// You cannot issue a partial refund for a split tender payment. You must
        /// instead issue a full or partial refund for a particular tender, by
        /// providing the applicable tender id to the V1CreateRefund endpoint.
        /// Issuing a full refund for a split tender payment refunds all tenders
        /// associated with the payment.
        /// Issuing a refund for a card payment is not reversible. For development
        /// purposes, you can create fake cash payments in Square Point of Sale and
        /// refund them.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the original payment's associated location.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Refund response from the API call</return>
        public async Task<Models.V1Refund> CreateRefundAsync(string locationId, Models.V1CreateRefundRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/refunds");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1Refund>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides summary information for all deposits and withdrawals
        /// initiated by Square to a linked bank account during a date range. Date
        /// ranges cannot exceed one year in length.
        /// *Note**: the ListSettlements endpoint does not provide entry
        /// information.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list settlements for. If you specify me, this endpoint returns settlements aggregated from all of the business's locations.</param>
        /// <param name="order">Optional parameter: The order in which settlements are listed in the response.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.</param>
        /// <param name="limit">Optional parameter: The maximum number of settlements to return in a single response. This value cannot exceed 200.</param>
        /// <param name="status">Optional parameter: Provide this parameter to retrieve only settlements with a particular status (SENT or FAILED).</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Settlement> response from the API call</return>
        public List<Models.V1Settlement> ListSettlements(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string status = null,
                string batchToken = null)
        {
            Task<List<Models.V1Settlement>> t = ListSettlementsAsync(locationId, order, beginTime, endTime, limit, status, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for all deposits and withdrawals
        /// initiated by Square to a linked bank account during a date range. Date
        /// ranges cannot exceed one year in length.
        /// *Note**: the ListSettlements endpoint does not provide entry
        /// information.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list settlements for. If you specify me, this endpoint returns settlements aggregated from all of the business's locations.</param>
        /// <param name="order">Optional parameter: The order in which settlements are listed in the response.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.</param>
        /// <param name="limit">Optional parameter: The maximum number of settlements to return in a single response. This value cannot exceed 200.</param>
        /// <param name="status">Optional parameter: Provide this parameter to retrieve only settlements with a particular status (SENT or FAILED).</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Settlement> response from the API call</return>
        public async Task<List<Models.V1Settlement>> ListSettlementsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null,
                int? limit = null,
                string status = null,
                string batchToken = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/settlements");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "limit", limit },
                { "status", status },
                { "batch_token", batchToken }
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

            var _responseModels = ApiHelper.JsonDeserialize<List<Models.V1Settlement>>(_response.Body);
            _responseModels.ForEach(r => r.Context = _context);
            return _responseModels;
        }

        /// <summary>
        /// Provides comprehensive information for a single settlement.
        /// The returned `Settlement` objects include an `entries` field that lists
        /// the transactions that contribute to the settlement total. Most
        /// settlement entries correspond to a payment payout, but settlement
        /// entries are also generated for less common events, like refunds, manual
        /// adjustments, or chargeback holds.
        /// Square initiates its regular deposits as indicated in the
        /// [Deposit Options with Square](https://squareup.com/help/us/en/article/3807)
        /// help article. Details for a regular deposit are usually not available
        /// from Connect API endpoints before 10 p.m. PST the same day.
        /// Square does not know when an initiated settlement **completes**, only
        /// whether it has failed. A completed settlement is typically reflected in
        /// a bank account within 3 business days, but in exceptional cases it may
        /// take longer.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the settlements's associated location.</param>
        /// <param name="settlementId">Required parameter: The settlement's Square-issued ID. You obtain this value from Settlement objects returned by the List Settlements endpoint.</param>
        /// <return>Returns the Models.V1Settlement response from the API call</return>
        public Models.V1Settlement RetrieveSettlement(string locationId, string settlementId)
        {
            Task<Models.V1Settlement> t = RetrieveSettlementAsync(locationId, settlementId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides comprehensive information for a single settlement.
        /// The returned `Settlement` objects include an `entries` field that lists
        /// the transactions that contribute to the settlement total. Most
        /// settlement entries correspond to a payment payout, but settlement
        /// entries are also generated for less common events, like refunds, manual
        /// adjustments, or chargeback holds.
        /// Square initiates its regular deposits as indicated in the
        /// [Deposit Options with Square](https://squareup.com/help/us/en/article/3807)
        /// help article. Details for a regular deposit are usually not available
        /// from Connect API endpoints before 10 p.m. PST the same day.
        /// Square does not know when an initiated settlement **completes**, only
        /// whether it has failed. A completed settlement is typically reflected in
        /// a bank account within 3 business days, but in exceptional cases it may
        /// take longer.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the settlements's associated location.</param>
        /// <param name="settlementId">Required parameter: The settlement's Square-issued ID. You obtain this value from Settlement objects returned by the List Settlements endpoint.</param>
        /// <return>Returns the Models.V1Settlement response from the API call</return>
        public async Task<Models.V1Settlement> RetrieveSettlementAsync(string locationId, string settlementId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/{location_id}/settlements/{settlement_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "settlement_id", settlementId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1Settlement>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}