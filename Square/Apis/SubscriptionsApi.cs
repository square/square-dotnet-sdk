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
    internal class SubscriptionsApi: BaseApi, ISubscriptionsApi
    {
        internal SubscriptionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Creates a subscription for a customer to a subscription plan.
        /// If you provide a card on file in the request, Square charges the card for 
        /// the subscription. Otherwise, Square bills an invoice to the customer's email 
        /// address. The subscription starts immediately, unless the request includes 
        /// the optional `start_date`. Each individual subscription is associated with a particular location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateSubscriptionResponse response from the API call</return>
        public Models.CreateSubscriptionResponse CreateSubscription(Models.CreateSubscriptionRequest body)
        {
            Task<Models.CreateSubscriptionResponse> t = CreateSubscriptionAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a subscription for a customer to a subscription plan.
        /// If you provide a card on file in the request, Square charges the card for 
        /// the subscription. Otherwise, Square bills an invoice to the customer's email 
        /// address. The subscription starts immediately, unless the request includes 
        /// the optional `start_date`. Each individual subscription is associated with a particular location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateSubscriptionResponse response from the API call</return>
        public async Task<Models.CreateSubscriptionResponse> CreateSubscriptionAsync(Models.CreateSubscriptionRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/subscriptions");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateSubscriptionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Searches for subscriptions. 
        /// Results are ordered chronologically by subscription creation date. If
        /// the request specifies more than one location ID, 
        /// the endpoint orders the result 
        /// by location ID, and then by creation date within each location. If no locations are given
        /// in the query, all locations are searched.
        /// You can also optionally specify `customer_ids` to search by customer. 
        /// If left unset, all customers 
        /// associated with the specified locations are returned. 
        /// If the request specifies customer IDs, the endpoint orders results 
        /// first by location, within location by customer ID, and within 
        /// customer by subscription creation date.
        /// For more information, see 
        /// [Retrieve subscriptions](https://developer.squareup.com/docs/docs/subscriptions-api/overview#retrieve-subscriptions).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchSubscriptionsResponse response from the API call</return>
        public Models.SearchSubscriptionsResponse SearchSubscriptions(Models.SearchSubscriptionsRequest body)
        {
            Task<Models.SearchSubscriptionsResponse> t = SearchSubscriptionsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for subscriptions. 
        /// Results are ordered chronologically by subscription creation date. If
        /// the request specifies more than one location ID, 
        /// the endpoint orders the result 
        /// by location ID, and then by creation date within each location. If no locations are given
        /// in the query, all locations are searched.
        /// You can also optionally specify `customer_ids` to search by customer. 
        /// If left unset, all customers 
        /// associated with the specified locations are returned. 
        /// If the request specifies customer IDs, the endpoint orders results 
        /// first by location, within location by customer ID, and within 
        /// customer by subscription creation date.
        /// For more information, see 
        /// [Retrieve subscriptions](https://developer.squareup.com/docs/docs/subscriptions-api/overview#retrieve-subscriptions).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchSubscriptionsResponse response from the API call</return>
        public async Task<Models.SearchSubscriptionsResponse> SearchSubscriptionsAsync(Models.SearchSubscriptionsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/subscriptions/search");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchSubscriptionsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve.</param>
        /// <return>Returns the Models.RetrieveSubscriptionResponse response from the API call</return>
        public Models.RetrieveSubscriptionResponse RetrieveSubscription(string subscriptionId)
        {
            Task<Models.RetrieveSubscriptionResponse> t = RetrieveSubscriptionAsync(subscriptionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve.</param>
        /// <return>Returns the Models.RetrieveSubscriptionResponse response from the API call</return>
        public async Task<Models.RetrieveSubscriptionResponse> RetrieveSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/subscriptions/{subscription_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveSubscriptionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates a subscription. You can set, modify, and clear the 
        /// `subscription` field values.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID for the subscription to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateSubscriptionResponse response from the API call</return>
        public Models.UpdateSubscriptionResponse UpdateSubscription(string subscriptionId, Models.UpdateSubscriptionRequest body)
        {
            Task<Models.UpdateSubscriptionResponse> t = UpdateSubscriptionAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a subscription. You can set, modify, and clear the 
        /// `subscription` field values.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID for the subscription to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateSubscriptionResponse response from the API call</return>
        public async Task<Models.UpdateSubscriptionResponse> UpdateSubscriptionAsync(string subscriptionId, Models.UpdateSubscriptionRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/subscriptions/{subscription_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateSubscriptionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Sets the `canceled_date` field to the end of the active billing period.
        /// After this date, the status changes from ACTIVE to CANCELED.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel.</param>
        /// <return>Returns the Models.CancelSubscriptionResponse response from the API call</return>
        public Models.CancelSubscriptionResponse CancelSubscription(string subscriptionId)
        {
            Task<Models.CancelSubscriptionResponse> t = CancelSubscriptionAsync(subscriptionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sets the `canceled_date` field to the end of the active billing period.
        /// After this date, the status changes from ACTIVE to CANCELED.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel.</param>
        /// <return>Returns the Models.CancelSubscriptionResponse response from the API call</return>
        public async Task<Models.CancelSubscriptionResponse> CancelSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/subscriptions/{subscription_id}/cancel");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CancelSubscriptionResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Lists all events for a specific subscription.
        /// In the current implementation, only `START_SUBSCRIPTION` and `STOP_SUBSCRIPTION` (when the subscription was canceled) events are returned.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve the events for.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).</param>
        /// <param name="limit">Optional parameter: The upper limit on the number of subscription events to return  in the response.   Default: `200`</param>
        /// <return>Returns the Models.ListSubscriptionEventsResponse response from the API call</return>
        public Models.ListSubscriptionEventsResponse ListSubscriptionEvents(string subscriptionId, string cursor = null, int? limit = null)
        {
            Task<Models.ListSubscriptionEventsResponse> t = ListSubscriptionEventsAsync(subscriptionId, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists all events for a specific subscription.
        /// In the current implementation, only `START_SUBSCRIPTION` and `STOP_SUBSCRIPTION` (when the subscription was canceled) events are returned.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve the events for.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).</param>
        /// <param name="limit">Optional parameter: The upper limit on the number of subscription events to return  in the response.   Default: `200`</param>
        /// <return>Returns the Models.ListSubscriptionEventsResponse response from the API call</return>
        public async Task<Models.ListSubscriptionEventsResponse> ListSubscriptionEventsAsync(string subscriptionId, string cursor = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/subscriptions/{subscription_id}/events");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListSubscriptionEventsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}