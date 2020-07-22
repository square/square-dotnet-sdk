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
    internal class InvoicesApi: BaseApi, IInvoicesApi
    {
        internal InvoicesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Returns a list of invoices for a given location. The response 
        /// is paginated. If truncated, the response includes a `cursor` that you    
        /// use in a subsequent request to fetch the next set of invoices.
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server  uses a default limit of 100 invoices.</param>
        /// <return>Returns the Models.ListInvoicesResponse response from the API call</return>
        public Models.ListInvoicesResponse ListInvoices(string locationId, string cursor = null, int? limit = null)
        {
            Task<Models.ListInvoicesResponse> t = ListInvoicesAsync(locationId, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of invoices for a given location. The response 
        /// is paginated. If truncated, the response includes a `cursor` that you    
        /// use in a subsequent request to fetch the next set of invoices.
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server  uses a default limit of 100 invoices.</param>
        /// <return>Returns the Models.ListInvoicesResponse response from the API call</return>
        public async Task<Models.ListInvoicesResponse> ListInvoicesAsync(string locationId, string cursor = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "cursor", cursor },
                { "limit", limit }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListInvoicesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates a draft [invoice](#type-invoice) 
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. 
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file). 
        /// For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateInvoiceResponse response from the API call</return>
        public Models.CreateInvoiceResponse CreateInvoice(Models.CreateInvoiceRequest body)
        {
            Task<Models.CreateInvoiceResponse> t = CreateInvoiceAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a draft [invoice](#type-invoice) 
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. 
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file). 
        /// For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateInvoiceResponse response from the API call</return>
        public async Task<Models.CreateInvoiceResponse> CreateInvoiceAsync(Models.CreateInvoiceRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateInvoiceResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Searches for invoices from a location specified in 
        /// the filter. You can optionally specify customers in the filter for whom to 
        /// retrieve invoices. In the current implementation, you can only specify one location and 
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` 
        /// that you use in a subsequent request to fetch the next set of invoices. 
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchInvoicesResponse response from the API call</return>
        public Models.SearchInvoicesResponse SearchInvoices(Models.SearchInvoicesRequest body)
        {
            Task<Models.SearchInvoicesResponse> t = SearchInvoicesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for invoices from a location specified in 
        /// the filter. You can optionally specify customers in the filter for whom to 
        /// retrieve invoices. In the current implementation, you can only specify one location and 
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` 
        /// that you use in a subsequent request to fetch the next set of invoices. 
        /// For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchInvoicesResponse response from the API call</return>
        public async Task<Models.SearchInvoicesResponse> SearchInvoicesAsync(Models.SearchInvoicesRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices/search");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchInvoicesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the 
        /// associated Order status changes to CANCELED. You can only delete a draft 
        /// invoice (you cannot delete an invoice scheduled for publication, or a 
        /// published invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete.</param>
        /// <param name="version">Optional parameter: The version of the [invoice](#type-invoice) to delete. If you do not know the version, you can call [GetInvoice](#endpoint-Invoices-GetInvoice) or  [ListInvoices](#endpoint-Invoices-ListInvoices).</param>
        /// <return>Returns the Models.DeleteInvoiceResponse response from the API call</return>
        public Models.DeleteInvoiceResponse DeleteInvoice(string invoiceId, int? version = null)
        {
            Task<Models.DeleteInvoiceResponse> t = DeleteInvoiceAsync(invoiceId, version);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the 
        /// associated Order status changes to CANCELED. You can only delete a draft 
        /// invoice (you cannot delete an invoice scheduled for publication, or a 
        /// published invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete.</param>
        /// <param name="version">Optional parameter: The version of the [invoice](#type-invoice) to delete. If you do not know the version, you can call [GetInvoice](#endpoint-Invoices-GetInvoice) or  [ListInvoices](#endpoint-Invoices-ListInvoices).</param>
        /// <return>Returns the Models.DeleteInvoiceResponse response from the API call</return>
        public async Task<Models.DeleteInvoiceResponse> DeleteInvoiceAsync(string invoiceId, int? version = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices/{invoice_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "version", version }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteInvoiceResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to retrieve.</param>
        /// <return>Returns the Models.GetInvoiceResponse response from the API call</return>
        public Models.GetInvoiceResponse GetInvoice(string invoiceId)
        {
            Task<Models.GetInvoiceResponse> t = GetInvoiceAsync(invoiceId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to retrieve.</param>
        /// <return>Returns the Models.GetInvoiceResponse response from the API call</return>
        public async Task<Models.GetInvoiceResponse> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices/{invoice_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetInvoiceResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates an invoice by modifying field values, clearing field values, or both 
        /// as specified in the request. 
        /// There are no restrictions to updating an invoice in a draft state. 
        /// However, there are guidelines for updating a published invoice. 
        /// For more information, see [Update an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#update-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateInvoiceResponse response from the API call</return>
        public Models.UpdateInvoiceResponse UpdateInvoice(string invoiceId, Models.UpdateInvoiceRequest body)
        {
            Task<Models.UpdateInvoiceResponse> t = UpdateInvoiceAsync(invoiceId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an invoice by modifying field values, clearing field values, or both 
        /// as specified in the request. 
        /// There are no restrictions to updating an invoice in a draft state. 
        /// However, there are guidelines for updating a published invoice. 
        /// For more information, see [Update an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#update-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateInvoiceResponse response from the API call</return>
        public async Task<Models.UpdateInvoiceResponse> UpdateInvoiceAsync(string invoiceId, Models.UpdateInvoiceRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices/{invoice_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateInvoiceResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for 
        /// the canceled invoice.
        /// You cannot cancel an invoice in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](#type-invoice) to cancel.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelInvoiceResponse response from the API call</return>
        public Models.CancelInvoiceResponse CancelInvoice(string invoiceId, Models.CancelInvoiceRequest body)
        {
            Task<Models.CancelInvoiceResponse> t = CancelInvoiceAsync(invoiceId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for 
        /// the canceled invoice.
        /// You cannot cancel an invoice in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice](#type-invoice) to cancel.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CancelInvoiceResponse response from the API call</return>
        public async Task<Models.CancelInvoiceResponse> CancelInvoiceAsync(string invoiceId, Models.CancelInvoiceRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices/{invoice_id}/cancel");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CancelInvoiceResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Publishes the specified draft invoice. 
        /// After an invoice is published, Square 
        /// follows up based on the invoice configuration. For example, Square 
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does 
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. 
        /// The invoice `status` also changes from `DRAFT` to a status 
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if 
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the 
        /// invoice amount).
        /// For more information, see 
        /// [Create and publish an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#create-and-publish-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to publish.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.PublishInvoiceResponse response from the API call</return>
        public Models.PublishInvoiceResponse PublishInvoice(string invoiceId, Models.PublishInvoiceRequest body)
        {
            Task<Models.PublishInvoiceResponse> t = PublishInvoiceAsync(invoiceId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Publishes the specified draft invoice. 
        /// After an invoice is published, Square 
        /// follows up based on the invoice configuration. For example, Square 
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does 
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. 
        /// The invoice `status` also changes from `DRAFT` to a status 
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if 
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the 
        /// invoice amount).
        /// For more information, see 
        /// [Create and publish an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#create-and-publish-an-invoice).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The id of the invoice to publish.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.PublishInvoiceResponse response from the API call</return>
        public async Task<Models.PublishInvoiceResponse> PublishInvoiceAsync(string invoiceId, Models.PublishInvoiceRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/invoices/{invoice_id}/publish");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.PublishInvoiceResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}