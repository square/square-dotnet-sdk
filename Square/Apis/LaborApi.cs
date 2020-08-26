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
    internal class LaborApi: BaseApi, ILaborApi
    {
        internal LaborApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter Break Types returned to only those that are associated with the specified location.</param>
        /// <param name="limit">Optional parameter: Maximum number of Break Types to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Break Type results to fetch.</param>
        /// <return>Returns the Models.ListBreakTypesResponse response from the API call</return>
        public Models.ListBreakTypesResponse ListBreakTypes(string locationId = null, int? limit = null, string cursor = null)
        {
            Task<Models.ListBreakTypesResponse> t = ListBreakTypesAsync(locationId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter Break Types returned to only those that are associated with the specified location.</param>
        /// <param name="limit">Optional parameter: Maximum number of Break Types to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Break Type results to fetch.</param>
        /// <return>Returns the Models.ListBreakTypesResponse response from the API call</return>
        public async Task<Models.ListBreakTypesResponse> ListBreakTypesAsync(string locationId = null, int? limit = null, string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/break-types");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListBreakTypesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `break_name`
        /// - `expected_duration`
        /// - `is_paid`
        /// You can only have 3 `BreakType` instances per location. If you attempt to add a 4th
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateBreakTypeResponse response from the API call</return>
        public Models.CreateBreakTypeResponse CreateBreakType(Models.CreateBreakTypeRequest body)
        {
            Task<Models.CreateBreakTypeResponse> t = CreateBreakTypeAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `break_name`
        /// - `expected_duration`
        /// - `is_paid`
        /// You can only have 3 `BreakType` instances per location. If you attempt to add a 4th
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateBreakTypeResponse response from the API call</return>
        public async Task<Models.CreateBreakTypeResponse> CreateBreakTypeAsync(Models.CreateBreakTypeRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/break-types");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateBreakTypeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being deleted.</param>
        /// <return>Returns the Models.DeleteBreakTypeResponse response from the API call</return>
        public Models.DeleteBreakTypeResponse DeleteBreakType(string id)
        {
            Task<Models.DeleteBreakTypeResponse> t = DeleteBreakTypeAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being deleted.</param>
        /// <return>Returns the Models.DeleteBreakTypeResponse response from the API call</return>
        public async Task<Models.DeleteBreakTypeResponse> DeleteBreakTypeAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/break-types/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteBreakTypeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a single `BreakType` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being retrieved.</param>
        /// <return>Returns the Models.GetBreakTypeResponse response from the API call</return>
        public Models.GetBreakTypeResponse GetBreakType(string id)
        {
            Task<Models.GetBreakTypeResponse> t = GetBreakTypeAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `BreakType` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being retrieved.</param>
        /// <return>Returns the Models.GetBreakTypeResponse response from the API call</return>
        public async Task<Models.GetBreakTypeResponse> GetBreakTypeAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/break-types/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetBreakTypeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateBreakTypeResponse response from the API call</return>
        public Models.UpdateBreakTypeResponse UpdateBreakType(string id, Models.UpdateBreakTypeRequest body)
        {
            Task<Models.UpdateBreakTypeResponse> t = UpdateBreakTypeAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateBreakTypeResponse response from the API call</return>
        public async Task<Models.UpdateBreakTypeResponse> UpdateBreakTypeAsync(string id, Models.UpdateBreakTypeRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/break-types/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateBreakTypeResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter wages returned to only those that are associated with the specified employee.</param>
        /// <param name="limit">Optional parameter: Maximum number of Employee Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListEmployeeWagesResponse response from the API call</return>
        [Obsolete]
        public Models.ListEmployeeWagesResponse ListEmployeeWages(string employeeId = null, int? limit = null, string cursor = null)
        {
            Task<Models.ListEmployeeWagesResponse> t = ListEmployeeWagesAsync(employeeId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter wages returned to only those that are associated with the specified employee.</param>
        /// <param name="limit">Optional parameter: Maximum number of Employee Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListEmployeeWagesResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ListEmployeeWagesResponse> ListEmployeeWagesAsync(string employeeId = null, int? limit = null, string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/employee-wages");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "employee_id", employeeId },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListEmployeeWagesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a single `EmployeeWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `EmployeeWage` being retrieved.</param>
        /// <return>Returns the Models.GetEmployeeWageResponse response from the API call</return>
        [Obsolete]
        public Models.GetEmployeeWageResponse GetEmployeeWage(string id)
        {
            Task<Models.GetEmployeeWageResponse> t = GetEmployeeWageAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `EmployeeWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `EmployeeWage` being retrieved.</param>
        /// <return>Returns the Models.GetEmployeeWageResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.GetEmployeeWageResponse> GetEmployeeWageAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/employee-wages/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetEmployeeWageResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete work day for a single employee.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `employee_id`
        /// - `start_at`
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
        /// - The `status` of the new `Shift` is `OPEN` and the employee has another
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future
        /// - the `start_at` or `end_at` overlaps another shift for the same employee
        /// - If `Break`s are set in the request, a break `start_at`
        /// must not be before the `Shift.start_at`. A break `end_at` must not be after
        /// the `Shift.end_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateShiftResponse response from the API call</return>
        public Models.CreateShiftResponse CreateShift(Models.CreateShiftRequest body)
        {
            Task<Models.CreateShiftResponse> t = CreateShiftAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete work day for a single employee.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `employee_id`
        /// - `start_at`
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
        /// - The `status` of the new `Shift` is `OPEN` and the employee has another
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future
        /// - the `start_at` or `end_at` overlaps another shift for the same employee
        /// - If `Break`s are set in the request, a break `start_at`
        /// must not be before the `Shift.start_at`. A break `end_at` must not be after
        /// the `Shift.end_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateShiftResponse response from the API call</return>
        public async Task<Models.CreateShiftResponse> CreateShiftAsync(Models.CreateShiftRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/shifts");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateShiftResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:
        /// - Location IDs **and**
        /// - employee IDs **and**
        /// - shift status (`OPEN`, `CLOSED`) **and**
        /// - shift start **and**
        /// - shift end **and**
        /// - work day details
        /// The list can be sorted by:
        /// - `start_at`
        /// - `end_at`
        /// - `created_at`
        /// - `updated_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchShiftsResponse response from the API call</return>
        public Models.SearchShiftsResponse SearchShifts(Models.SearchShiftsRequest body)
        {
            Task<Models.SearchShiftsResponse> t = SearchShiftsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:
        /// - Location IDs **and**
        /// - employee IDs **and**
        /// - shift status (`OPEN`, `CLOSED`) **and**
        /// - shift start **and**
        /// - shift end **and**
        /// - work day details
        /// The list can be sorted by:
        /// - `start_at`
        /// - `end_at`
        /// - `created_at`
        /// - `updated_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchShiftsResponse response from the API call</return>
        public async Task<Models.SearchShiftsResponse> SearchShiftsAsync(Models.SearchShiftsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/shifts/search");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchShiftsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being deleted.</param>
        /// <return>Returns the Models.DeleteShiftResponse response from the API call</return>
        public Models.DeleteShiftResponse DeleteShift(string id)
        {
            Task<Models.DeleteShiftResponse> t = DeleteShiftAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being deleted.</param>
        /// <return>Returns the Models.DeleteShiftResponse response from the API call</return>
        public async Task<Models.DeleteShiftResponse> DeleteShiftAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/shifts/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteShiftResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a single `Shift` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being retrieved.</param>
        /// <return>Returns the Models.GetShiftResponse response from the API call</return>
        public Models.GetShiftResponse GetShift(string id)
        {
            Task<Models.GetShiftResponse> t = GetShiftAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `Shift` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being retrieved.</param>
        /// <return>Returns the Models.GetShiftResponse response from the API call</return>
        public async Task<Models.GetShiftResponse> GetShiftAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/shifts/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetShiftResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Breaks` in the `Shift` have
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the shift must be complete with `end_at`
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: ID of the object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateShiftResponse response from the API call</return>
        public Models.UpdateShiftResponse UpdateShift(string id, Models.UpdateShiftRequest body)
        {
            Task<Models.UpdateShiftResponse> t = UpdateShiftAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Breaks` in the `Shift` have
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the shift must be complete with `end_at`
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: ID of the object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateShiftResponse response from the API call</return>
        public async Task<Models.UpdateShiftResponse> UpdateShiftAsync(string id, Models.UpdateShiftRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/shifts/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateShiftResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter wages returned to only those that are associated with the specified team member.</param>
        /// <param name="limit">Optional parameter: Maximum number of Team Member Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListTeamMemberWagesResponse response from the API call</return>
        public Models.ListTeamMemberWagesResponse ListTeamMemberWages(string teamMemberId = null, int? limit = null, string cursor = null)
        {
            Task<Models.ListTeamMemberWagesResponse> t = ListTeamMemberWagesAsync(teamMemberId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter wages returned to only those that are associated with the specified team member.</param>
        /// <param name="limit">Optional parameter: Maximum number of Team Member Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListTeamMemberWagesResponse response from the API call</return>
        public async Task<Models.ListTeamMemberWagesResponse> ListTeamMemberWagesAsync(string teamMemberId = null, int? limit = null, string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/team-member-wages");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListTeamMemberWagesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `TeamMemberWage` being retrieved.</param>
        /// <return>Returns the Models.GetTeamMemberWageResponse response from the API call</return>
        public Models.GetTeamMemberWageResponse GetTeamMemberWage(string id)
        {
            Task<Models.GetTeamMemberWageResponse> t = GetTeamMemberWageAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `TeamMemberWage` being retrieved.</param>
        /// <return>Returns the Models.GetTeamMemberWageResponse response from the API call</return>
        public async Task<Models.GetTeamMemberWageResponse> GetTeamMemberWageAsync(string id, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/team-member-wages/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetTeamMemberWageResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: Maximum number of Workweek Configs to return per page.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Workweek Config results to fetch.</param>
        /// <return>Returns the Models.ListWorkweekConfigsResponse response from the API call</return>
        public Models.ListWorkweekConfigsResponse ListWorkweekConfigs(int? limit = null, string cursor = null)
        {
            Task<Models.ListWorkweekConfigsResponse> t = ListWorkweekConfigsAsync(limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: Maximum number of Workweek Configs to return per page.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Workweek Config results to fetch.</param>
        /// <return>Returns the Models.ListWorkweekConfigsResponse response from the API call</return>
        public async Task<Models.ListWorkweekConfigsResponse> ListWorkweekConfigsAsync(int? limit = null, string cursor = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/workweek-configs");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListWorkweekConfigsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `WorkweekConfig` object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateWorkweekConfigResponse response from the API call</return>
        public Models.UpdateWorkweekConfigResponse UpdateWorkweekConfig(string id, Models.UpdateWorkweekConfigRequest body)
        {
            Task<Models.UpdateWorkweekConfigResponse> t = UpdateWorkweekConfigAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `WorkweekConfig` object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateWorkweekConfigResponse response from the API call</return>
        public async Task<Models.UpdateWorkweekConfigResponse> UpdateWorkweekConfigAsync(string id, Models.UpdateWorkweekConfigRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/labor/workweek-configs/{id}");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateWorkweekConfigResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}