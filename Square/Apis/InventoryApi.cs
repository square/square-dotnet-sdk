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
    internal class InventoryApi: BaseApi, IInventoryApi
    {
        internal InventoryApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Returns the [InventoryAdjustment](#type-inventoryadjustment) object
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](#type-inventoryadjustment) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call</return>
        public Models.RetrieveInventoryAdjustmentResponse RetrieveInventoryAdjustment(string adjustmentId)
        {
            Task<Models.RetrieveInventoryAdjustmentResponse> t = RetrieveInventoryAdjustmentAsync(adjustmentId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the [InventoryAdjustment](#type-inventoryadjustment) object
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](#type-inventoryadjustment) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call</return>
        public async Task<Models.RetrieveInventoryAdjustmentResponse> RetrieveInventoryAdjustmentAsync(string adjustmentId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/adjustment/{adjustment_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "adjustment_id", adjustmentId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryAdjustmentResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchChangeInventoryResponse response from the API call</return>
        public Models.BatchChangeInventoryResponse BatchChangeInventory(Models.BatchChangeInventoryRequest body)
        {
            Task<Models.BatchChangeInventoryResponse> t = BatchChangeInventoryAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchChangeInventoryResponse response from the API call</return>
        public async Task<Models.BatchChangeInventoryResponse> BatchChangeInventoryAsync(Models.BatchChangeInventoryRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/batch-change");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchChangeInventoryResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns historical physical counts and adjustments based on the
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call</return>
        public Models.BatchRetrieveInventoryChangesResponse BatchRetrieveInventoryChanges(Models.BatchRetrieveInventoryChangesRequest body)
        {
            Task<Models.BatchRetrieveInventoryChangesResponse> t = BatchRetrieveInventoryChangesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns historical physical counts and adjustments based on the
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call</return>
        public async Task<Models.BatchRetrieveInventoryChangesResponse> BatchRetrieveInventoryChangesAsync(Models.BatchRetrieveInventoryChangesRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/batch-retrieve-changes");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveInventoryChangesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns current counts for the provided
        /// [CatalogObject](#type-catalogobject)s at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that
        /// time (based on the server timestamp for the most recent change) are
        /// returned. This allows clients to perform a "sync" operation, for example
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call</return>
        public Models.BatchRetrieveInventoryCountsResponse BatchRetrieveInventoryCounts(Models.BatchRetrieveInventoryCountsRequest body)
        {
            Task<Models.BatchRetrieveInventoryCountsResponse> t = BatchRetrieveInventoryCountsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns current counts for the provided
        /// [CatalogObject](#type-catalogobject)s at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that
        /// time (based on the server timestamp for the most recent change) are
        /// returned. This allows clients to perform a "sync" operation, for example
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call</return>
        public async Task<Models.BatchRetrieveInventoryCountsResponse> BatchRetrieveInventoryCountsAsync(Models.BatchRetrieveInventoryCountsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/batch-retrieve-counts");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveInventoryCountsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns the [InventoryPhysicalCount](#type-inventoryphysicalcount)
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](#type-inventoryphysicalcount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call</return>
        public Models.RetrieveInventoryPhysicalCountResponse RetrieveInventoryPhysicalCount(string physicalCountId)
        {
            Task<Models.RetrieveInventoryPhysicalCountResponse> t = RetrieveInventoryPhysicalCountAsync(physicalCountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the [InventoryPhysicalCount](#type-inventoryphysicalcount)
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](#type-inventoryphysicalcount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call</return>
        public async Task<Models.RetrieveInventoryPhysicalCountResponse> RetrieveInventoryPhysicalCountAsync(string physicalCountId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/physical-count/{physical_count_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "physical_count_id", physicalCountId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryPhysicalCountResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves the current calculated stock count for a given
        /// [CatalogObject](#type-catalogobject) at a given set of
        /// [Location](#type-location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryCountResponse response from the API call</return>
        public Models.RetrieveInventoryCountResponse RetrieveInventoryCount(string catalogObjectId, string locationIds = null, string cursor = null)
        {
            Task<Models.RetrieveInventoryCountResponse> t = RetrieveInventoryCountAsync(catalogObjectId, locationIds, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the current calculated stock count for a given
        /// [CatalogObject](#type-catalogobject) at a given set of
        /// [Location](#type-location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryCountResponse response from the API call</return>
        public async Task<Models.RetrieveInventoryCountResponse> RetrieveInventoryCountAsync(string catalogObjectId, string locationIds = null, string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/{catalog_object_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "catalog_object_id", catalogObjectId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_ids", locationIds },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryCountResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the
        /// provided [CatalogObject](#type-catalogobject) at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be 
        /// used to display recent changes for a specific item. For more
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryChangesResponse response from the API call</return>
        public Models.RetrieveInventoryChangesResponse RetrieveInventoryChanges(string catalogObjectId, string locationIds = null, string cursor = null)
        {
            Task<Models.RetrieveInventoryChangesResponse> t = RetrieveInventoryChangesAsync(catalogObjectId, locationIds, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the
        /// provided [CatalogObject](#type-catalogobject) at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be 
        /// used to display recent changes for a specific item. For more
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryChangesResponse response from the API call</return>
        public async Task<Models.RetrieveInventoryChangesResponse> RetrieveInventoryChangesAsync(string catalogObjectId, string locationIds = null, string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/inventory/{catalog_object_id}/changes");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "catalog_object_id", catalogObjectId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_ids", locationIds },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveInventoryChangesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}