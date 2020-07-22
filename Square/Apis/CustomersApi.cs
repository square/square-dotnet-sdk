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
    internal class CustomersApi: BaseApi, ICustomersApi
    {
        internal CustomersApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.</param>
        /// <param name="sortField">Optional parameter: Indicates how Customers should be sorted.  Default: `DEFAULT`.</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether Customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  Default: `ASC`.</param>
        /// <return>Returns the Models.ListCustomersResponse response from the API call</return>
        public Models.ListCustomersResponse ListCustomers(string cursor = null, string sortField = null, string sortOrder = null)
        {
            Task<Models.ListCustomersResponse> t = ListCustomersAsync(cursor, sortField, sortOrder);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.</param>
        /// <param name="sortField">Optional parameter: Indicates how Customers should be sorted.  Default: `DEFAULT`.</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether Customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  Default: `ASC`.</param>
        /// <return>Returns the Models.ListCustomersResponse response from the API call</return>
        public async Task<Models.ListCustomersResponse> ListCustomersAsync(string cursor = null, string sortField = null, string sortOrder = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "sort_field", sortField },
                { "sort_order", sortOrder }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListCustomersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates a new customer for a business, which can have associated cards on file.
        /// You must provide __at least one__ of the following values in your request to this
        /// endpoint:
        /// - `given_name`
        /// - `family_name`
        /// - `company_name`
        /// - `email_address`
        /// - `phone_number`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerResponse response from the API call</return>
        public Models.CreateCustomerResponse CreateCustomer(Models.CreateCustomerRequest body)
        {
            Task<Models.CreateCustomerResponse> t = CreateCustomerAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new customer for a business, which can have associated cards on file.
        /// You must provide __at least one__ of the following values in your request to this
        /// endpoint:
        /// - `given_name`
        /// - `family_name`
        /// - `company_name`
        /// - `email_address`
        /// - `phone_number`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerResponse response from the API call</return>
        public async Task<Models.CreateCustomerResponse> CreateCustomerAsync(Models.CreateCustomerRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateCustomerResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Searches the customer profiles associated with a Square account using 
        /// one or more supported query filters. 
        /// Calling `SearchCustomers` without any explicit query filter returns all
        /// customer profiles ordered alphabetically based on `given_name` and
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCustomersResponse response from the API call</return>
        public Models.SearchCustomersResponse SearchCustomers(Models.SearchCustomersRequest body)
        {
            Task<Models.SearchCustomersResponse> t = SearchCustomersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches the customer profiles associated with a Square account using 
        /// one or more supported query filters. 
        /// Calling `SearchCustomers` without any explicit query filter returns all
        /// customer profiles ordered alphabetically based on `given_name` and
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCustomersResponse response from the API call</return>
        public async Task<Models.SearchCustomersResponse> SearchCustomersAsync(Models.SearchCustomersRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/search");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchCustomersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Deletes a customer from a business, along with any linked cards on file. When two profiles
        /// are merged into a single profile, that profile is assigned a new `customer_id`. You must use the
        /// new `customer_id` to delete merged profiles.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete.</param>
        /// <return>Returns the Models.DeleteCustomerResponse response from the API call</return>
        public Models.DeleteCustomerResponse DeleteCustomer(string customerId)
        {
            Task<Models.DeleteCustomerResponse> t = DeleteCustomerAsync(customerId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a customer from a business, along with any linked cards on file. When two profiles
        /// are merged into a single profile, that profile is assigned a new `customer_id`. You must use the
        /// new `customer_id` to delete merged profiles.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete.</param>
        /// <return>Returns the Models.DeleteCustomerResponse response from the API call</return>
        public async Task<Models.DeleteCustomerResponse> DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteCustomerResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve.</param>
        /// <return>Returns the Models.RetrieveCustomerResponse response from the API call</return>
        public Models.RetrieveCustomerResponse RetrieveCustomer(string customerId)
        {
            Task<Models.RetrieveCustomerResponse> t = RetrieveCustomerAsync(customerId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve.</param>
        /// <return>Returns the Models.RetrieveCustomerResponse response from the API call</return>
        public async Task<Models.RetrieveCustomerResponse> RetrieveCustomerAsync(string customerId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCustomerResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates the details of an existing customer. When two profiles are merged
        /// into a single profile, that profile is assigned a new `customer_id`. You must use
        /// the new `customer_id` to update merged profiles.
        /// You cannot edit a customer's cards on file with this endpoint. To make changes
        /// to a card on file, you must delete the existing card on file with the
        /// [DeleteCustomerCard](#endpoint-deletecustomercard) endpoint, then create a new one with the
        /// [CreateCustomerCard](#endpoint-createcustomercard) endpoint.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateCustomerResponse response from the API call</return>
        public Models.UpdateCustomerResponse UpdateCustomer(string customerId, Models.UpdateCustomerRequest body)
        {
            Task<Models.UpdateCustomerResponse> t = UpdateCustomerAsync(customerId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the details of an existing customer. When two profiles are merged
        /// into a single profile, that profile is assigned a new `customer_id`. You must use
        /// the new `customer_id` to update merged profiles.
        /// You cannot edit a customer's cards on file with this endpoint. To make changes
        /// to a card on file, you must delete the existing card on file with the
        /// [DeleteCustomerCard](#endpoint-deletecustomercard) endpoint, then create a new one with the
        /// [CreateCustomerCard](#endpoint-createcustomercard) endpoint.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateCustomerResponse response from the API call</return>
        public async Task<Models.UpdateCustomerResponse> UpdateCustomerAsync(string customerId, Models.UpdateCustomerRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateCustomerResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
        /// calls with the same card nonce return the same card record that was created
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerCardResponse response from the API call</return>
        public Models.CreateCustomerCardResponse CreateCustomerCard(string customerId, Models.CreateCustomerCardRequest body)
        {
            Task<Models.CreateCustomerCardResponse> t = CreateCustomerCardAsync(customerId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
        /// calls with the same card nonce return the same card record that was created
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerCardResponse response from the API call</return>
        public async Task<Models.CreateCustomerCardResponse> CreateCustomerCardAsync(string customerId, Models.CreateCustomerCardRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}/cards");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateCustomerCardResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to.</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete.</param>
        /// <return>Returns the Models.DeleteCustomerCardResponse response from the API call</return>
        public Models.DeleteCustomerCardResponse DeleteCustomerCard(string customerId, string cardId)
        {
            Task<Models.DeleteCustomerCardResponse> t = DeleteCustomerCardAsync(customerId, cardId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to.</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete.</param>
        /// <return>Returns the Models.DeleteCustomerCardResponse response from the API call</return>
        public async Task<Models.DeleteCustomerCardResponse> DeleteCustomerCardAsync(string customerId, string cardId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}/cards/{card_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
                { "card_id", cardId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteCustomerCardResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Removes a group membership from a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from.</param>
        /// <return>Returns the Models.RemoveGroupFromCustomerResponse response from the API call</return>
        public Models.RemoveGroupFromCustomerResponse RemoveGroupFromCustomer(string customerId, string groupId)
        {
            Task<Models.RemoveGroupFromCustomerResponse> t = RemoveGroupFromCustomerAsync(customerId, groupId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Removes a group membership from a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from.</param>
        /// <return>Returns the Models.RemoveGroupFromCustomerResponse response from the API call</return>
        public async Task<Models.RemoveGroupFromCustomerResponse> RemoveGroupFromCustomerAsync(string customerId, string groupId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}/groups/{group_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
                { "group_id", groupId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RemoveGroupFromCustomerResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Adds a group membership to a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to.</param>
        /// <return>Returns the Models.AddGroupToCustomerResponse response from the API call</return>
        public Models.AddGroupToCustomerResponse AddGroupToCustomer(string customerId, string groupId)
        {
            Task<Models.AddGroupToCustomerResponse> t = AddGroupToCustomerAsync(customerId, groupId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Adds a group membership to a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to.</param>
        /// <return>Returns the Models.AddGroupToCustomerResponse response from the API call</return>
        public async Task<Models.AddGroupToCustomerResponse> AddGroupToCustomerAsync(string customerId, string groupId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/customers/{customer_id}/groups/{group_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer_id", customerId },
                { "group_id", groupId }
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
            HttpRequest _request = GetClientInstance().Put(_queryUrl, _headers, null);
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.AddGroupToCustomerResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}