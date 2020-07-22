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
    internal class TeamApi: BaseApi, ITeamApi
    {
        internal TeamApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates.
        /// You must provide the following values in your request to this endpoint:
        /// - `first_name`
        /// - `last_name`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTeamMemberResponse response from the API call</return>
        public Models.CreateTeamMemberResponse CreateTeamMember(Models.CreateTeamMemberRequest body)
        {
            Task<Models.CreateTeamMemberResponse> t = CreateTeamMemberAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates.
        /// You must provide the following values in your request to this endpoint:
        /// - `first_name`
        /// - `last_name`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTeamMemberResponse response from the API call</return>
        public async Task<Models.CreateTeamMemberResponse> CreateTeamMemberAsync(Models.CreateTeamMemberRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateTeamMemberResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the creates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular create.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkcreateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkCreateTeamMembersResponse response from the API call</return>
        public Models.BulkCreateTeamMembersResponse BulkCreateTeamMembers(Models.BulkCreateTeamMembersRequest body)
        {
            Task<Models.BulkCreateTeamMembersResponse> t = BulkCreateTeamMembersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the creates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular create.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkcreateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkCreateTeamMembersResponse response from the API call</return>
        public async Task<Models.BulkCreateTeamMembersResponse> BulkCreateTeamMembersAsync(Models.BulkCreateTeamMembersRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/bulk-create");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.BulkCreateTeamMembersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the updates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular update.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkupdateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkUpdateTeamMembersResponse response from the API call</return>
        public Models.BulkUpdateTeamMembersResponse BulkUpdateTeamMembers(Models.BulkUpdateTeamMembersRequest body)
        {
            Task<Models.BulkUpdateTeamMembersResponse> t = BulkUpdateTeamMembersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the updates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular update.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkupdateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkUpdateTeamMembersResponse response from the API call</return>
        public async Task<Models.BulkUpdateTeamMembersResponse> BulkUpdateTeamMembersAsync(Models.BulkUpdateTeamMembersRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/bulk-update");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.BulkUpdateTeamMembersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business.
        /// The list to be returned can be filtered by:
        /// - location IDs **and**
        /// - `is_active`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTeamMembersResponse response from the API call</return>
        public Models.SearchTeamMembersResponse SearchTeamMembers(Models.SearchTeamMembersRequest body)
        {
            Task<Models.SearchTeamMembersResponse> t = SearchTeamMembersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business.
        /// The list to be returned can be filtered by:
        /// - location IDs **and**
        /// - `is_active`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTeamMembersResponse response from the API call</return>
        public async Task<Models.SearchTeamMembersResponse> SearchTeamMembersAsync(Models.SearchTeamMembersRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/search");

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

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchTeamMembersResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieve a `TeamMember` object for the given `TeamMember.id`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrieveteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve.</param>
        /// <return>Returns the Models.RetrieveTeamMemberResponse response from the API call</return>
        public Models.RetrieveTeamMemberResponse RetrieveTeamMember(string teamMemberId)
        {
            Task<Models.RetrieveTeamMemberResponse> t = RetrieveTeamMemberAsync(teamMemberId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve a `TeamMember` object for the given `TeamMember.id`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrieveteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve.</param>
        /// <return>Returns the Models.RetrieveTeamMemberResponse response from the API call</return>
        public async Task<Models.RetrieveTeamMemberResponse> RetrieveTeamMemberAsync(string teamMemberId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/{team_member_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveTeamMemberResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updateteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateTeamMemberResponse response from the API call</return>
        public Models.UpdateTeamMemberResponse UpdateTeamMember(string teamMemberId, Models.UpdateTeamMemberRequest body)
        {
            Task<Models.UpdateTeamMemberResponse> t = UpdateTeamMemberAsync(teamMemberId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updateteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateTeamMemberResponse response from the API call</return>
        public async Task<Models.UpdateTeamMemberResponse> UpdateTeamMemberAsync(string teamMemberId, Models.UpdateTeamMemberRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/{team_member_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateTeamMemberResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieve a `WageSetting` object for a team member specified
        /// by `TeamMember.id`.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrievewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve wage setting for</param>
        /// <return>Returns the Models.RetrieveWageSettingResponse response from the API call</return>
        public Models.RetrieveWageSettingResponse RetrieveWageSetting(string teamMemberId)
        {
            Task<Models.RetrieveWageSettingResponse> t = RetrieveWageSettingAsync(teamMemberId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve a `WageSetting` object for a team member specified
        /// by `TeamMember.id`.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrievewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve wage setting for</param>
        /// <return>Returns the Models.RetrieveWageSettingResponse response from the API call</return>
        public async Task<Models.RetrieveWageSettingResponse> RetrieveWageSettingAsync(string teamMemberId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/{team_member_id}/wage-setting");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveWageSettingResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a
        /// `WageSetting` with the specified `team_member_id` does not exist. Otherwise,
        /// it fully replaces the `WageSetting` object for the team member.
        /// The `WageSetting` will be returned upon successful update.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updatewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update the `WageSetting` object for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateWageSettingResponse response from the API call</return>
        public Models.UpdateWageSettingResponse UpdateWageSetting(string teamMemberId, Models.UpdateWageSettingRequest body)
        {
            Task<Models.UpdateWageSettingResponse> t = UpdateWageSettingAsync(teamMemberId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a
        /// `WageSetting` with the specified `team_member_id` does not exist. Otherwise,
        /// it fully replaces the `WageSetting` object for the team member.
        /// The `WageSetting` will be returned upon successful update.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updatewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update the `WageSetting` object for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateWageSettingResponse response from the API call</return>
        public async Task<Models.UpdateWageSettingResponse> UpdateWageSettingAsync(string teamMemberId, Models.UpdateWageSettingRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/team-members/{team_member_id}/wage-setting");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId }
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

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateWageSettingResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}