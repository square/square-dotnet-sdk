namespace Square.Apis
{
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
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// TeamApi.
    /// </summary>
    internal class TeamApi : BaseApi, ITeamApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal TeamApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates..
        /// You must provide the following values in your request to this endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#createteammember)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTeamMemberResponse response from the API call.</returns>
        public Models.CreateTeamMemberResponse CreateTeamMember(
                Models.CreateTeamMemberRequest body)
        {
            Task<Models.CreateTeamMemberResponse> t = this.CreateTeamMemberAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates..
        /// You must provide the following values in your request to this endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#createteammember)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTeamMemberResponse response from the API call.</returns>
        public async Task<Models.CreateTeamMemberResponse> CreateTeamMemberAsync(
                Models.CreateTeamMemberRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateTeamMemberResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates..
        /// This process is non-transactional and will process as much of the request as is possible. If one of the creates in.
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response.
        /// will contain explicit error information for this particular create..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateTeamMembersResponse response from the API call.</returns>
        public Models.BulkCreateTeamMembersResponse BulkCreateTeamMembers(
                Models.BulkCreateTeamMembersRequest body)
        {
            Task<Models.BulkCreateTeamMembersResponse> t = this.BulkCreateTeamMembersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates..
        /// This process is non-transactional and will process as much of the request as is possible. If one of the creates in.
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response.
        /// will contain explicit error information for this particular create..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkCreateTeamMembersResponse response from the API call.</returns>
        public async Task<Models.BulkCreateTeamMembersResponse> BulkCreateTeamMembersAsync(
                Models.BulkCreateTeamMembersRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/bulk-create");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkCreateTeamMembersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates..
        /// This process is non-transactional and will process as much of the request as is possible. If one of the updates in.
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response.
        /// will contain explicit error information for this particular update..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateTeamMembersResponse response from the API call.</returns>
        public Models.BulkUpdateTeamMembersResponse BulkUpdateTeamMembers(
                Models.BulkUpdateTeamMembersRequest body)
        {
            Task<Models.BulkUpdateTeamMembersResponse> t = this.BulkUpdateTeamMembersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates..
        /// This process is non-transactional and will process as much of the request as is possible. If one of the updates in.
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response.
        /// will contain explicit error information for this particular update..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpdateTeamMembersResponse response from the API call.</returns>
        public async Task<Models.BulkUpdateTeamMembersResponse> BulkUpdateTeamMembersAsync(
                Models.BulkUpdateTeamMembersRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/bulk-update");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkUpdateTeamMembersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business..
        /// The list to be returned can be filtered by:.
        /// - location IDs **and**.
        /// - `status`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        public Models.SearchTeamMembersResponse SearchTeamMembers(
                Models.SearchTeamMembersRequest body)
        {
            Task<Models.SearchTeamMembersResponse> t = this.SearchTeamMembersAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business..
        /// The list to be returned can be filtered by:.
        /// - location IDs **and**.
        /// - `status`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        public async Task<Models.SearchTeamMembersResponse> SearchTeamMembersAsync(
                Models.SearchTeamMembersRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchTeamMembersResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieve a `TeamMember` object for the given `TeamMember.id`..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberResponse response from the API call.</returns>
        public Models.RetrieveTeamMemberResponse RetrieveTeamMember(
                string teamMemberId)
        {
            Task<Models.RetrieveTeamMemberResponse> t = this.RetrieveTeamMemberAsync(teamMemberId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve a `TeamMember` object for the given `TeamMember.id`..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberResponse response from the API call.</returns>
        public async Task<Models.RetrieveTeamMemberResponse> RetrieveTeamMemberAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/{team_member_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveTeamMemberResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateTeamMemberResponse response from the API call.</returns>
        public Models.UpdateTeamMemberResponse UpdateTeamMember(
                string teamMemberId,
                Models.UpdateTeamMemberRequest body)
        {
            Task<Models.UpdateTeamMemberResponse> t = this.UpdateTeamMemberAsync(teamMemberId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateTeamMemberResponse response from the API call.</returns>
        public async Task<Models.UpdateTeamMemberResponse> UpdateTeamMemberAsync(
                string teamMemberId,
                Models.UpdateTeamMemberRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/{team_member_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateTeamMemberResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieve a `WageSetting` object for a team member specified.
        /// by `TeamMember.id`..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve wage setting for.</param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        public Models.RetrieveWageSettingResponse RetrieveWageSetting(
                string teamMemberId)
        {
            Task<Models.RetrieveWageSettingResponse> t = this.RetrieveWageSettingAsync(teamMemberId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve a `WageSetting` object for a team member specified.
        /// by `TeamMember.id`..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve wage setting for.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        public async Task<Models.RetrieveWageSettingResponse> RetrieveWageSettingAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/{team_member_id}/wage-setting");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveWageSettingResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a.
        /// `WageSetting` with the specified `team_member_id` does not exist. Otherwise,.
        /// it fully replaces the `WageSetting` object for the team member..
        /// The `WageSetting` will be returned upon successful update..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update the `WageSetting` object for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWageSettingResponse response from the API call.</returns>
        public Models.UpdateWageSettingResponse UpdateWageSetting(
                string teamMemberId,
                Models.UpdateWageSettingRequest body)
        {
            Task<Models.UpdateWageSettingResponse> t = this.UpdateWageSettingAsync(teamMemberId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a.
        /// `WageSetting` with the specified `team_member_id` does not exist. Otherwise,.
        /// it fully replaces the `WageSetting` object for the team member..
        /// The `WageSetting` will be returned upon successful update..
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting)..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update the `WageSetting` object for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWageSettingResponse response from the API call.</returns>
        public async Task<Models.UpdateWageSettingResponse> UpdateWageSettingAsync(
                string teamMemberId,
                Models.UpdateWageSettingRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/team-members/{team_member_id}/wage-setting");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateWageSettingResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}