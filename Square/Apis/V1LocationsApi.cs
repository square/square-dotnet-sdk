using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Exceptions;

namespace Square.Apis
{
    internal class V1LocationsApi: BaseApi, IV1LocationsApi
    {
        internal V1LocationsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Get the general information for a business.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the Models.V1Merchant response from the API call</return>
        [Obsolete]
        public Models.V1Merchant RetrieveBusiness()
        {
            Task<Models.V1Merchant> t = RetrieveBusinessAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get the general information for a business.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the Models.V1Merchant response from the API call</return>
        [Obsolete]
        public async Task<Models.V1Merchant> RetrieveBusinessAsync()
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/me");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "Square-DotNet-SDK/4.0.0" },
                { "accept", "application/json" },
                { "Square-Version", "2019-12-17" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = authManagers["default"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.V1Merchant>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Provides details for all business locations associated with a Square
        /// account, including the Square-assigned object ID for the location.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the List<Models.V1Merchant> response from the API call</return>
        [Obsolete]
        public List<Models.V1Merchant> ListLocations()
        {
            Task<List<Models.V1Merchant>> t = ListLocationsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides details for all business locations associated with a Square
        /// account, including the Square-assigned object ID for the location.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the List<Models.V1Merchant> response from the API call</return>
        [Obsolete]
        public async Task<List<Models.V1Merchant>> ListLocationsAsync()
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/me/locations");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "Square-DotNet-SDK/4.0.0" },
                { "accept", "application/json" },
                { "Square-Version", "2019-12-17" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = authManagers["default"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            return ApiHelper.JsonDeserialize<List<Models.V1Merchant>>(_response.Body);
        }

    }
} 