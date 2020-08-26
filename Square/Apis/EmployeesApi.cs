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
    internal class EmployeesApi: BaseApi, IEmployeesApi
    {
        internal EmployeesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// ListEmployees
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: </param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by.</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page.</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results.</param>
        /// <return>Returns the Models.ListEmployeesResponse response from the API call</return>
        [Obsolete]
        public Models.ListEmployeesResponse ListEmployees(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListEmployeesResponse> t = ListEmployeesAsync(locationId, status, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// ListEmployees
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: </param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by.</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page.</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results.</param>
        /// <return>Returns the Models.ListEmployeesResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ListEmployeesResponse> ListEmployeesAsync(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/employees");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "status", status },
                { "limit", limit },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListEmployeesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// RetrieveEmployee
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested.</param>
        /// <return>Returns the Models.RetrieveEmployeeResponse response from the API call</return>
        [Obsolete]
        public Models.RetrieveEmployeeResponse RetrieveEmployee(string id)
        {
            Task<Models.RetrieveEmployeeResponse> t = RetrieveEmployeeAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// RetrieveEmployee
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested.</param>
        /// <return>Returns the Models.RetrieveEmployeeResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.RetrieveEmployeeResponse> RetrieveEmployeeAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/employees/{id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "id", id }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveEmployeeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}