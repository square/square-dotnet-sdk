using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// TeamApi.
    /// </summary>
    internal class TeamApi : BaseApi, ITeamApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamApi"/> class.
        /// </summary>
        internal TeamApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
        /// You must provide the following values in your request to this endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTeamMemberResponse response from the API call.</returns>
        public Models.CreateTeamMemberResponse CreateTeamMember(
            Models.CreateTeamMemberRequest body
        ) => CoreHelper.RunTask(CreateTeamMemberAsync(body));

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
        /// You must provide the following values in your request to this endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTeamMemberResponse response from the API call.</returns>
        public async Task<Models.CreateTeamMemberResponse> CreateTeamMemberAsync(
            Models.CreateTeamMemberRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.CreateTeamMemberResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/team-members")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
        /// This process is non-transactional and processes as much of the request as possible. If one of the creates in.
        /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response.
        /// contains explicit error information for the failed create.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateTeamMembersResponse response from the API call.</returns>
        public Models.BulkCreateTeamMembersResponse BulkCreateTeamMembers(
            Models.BulkCreateTeamMembersRequest body
        ) => CoreHelper.RunTask(BulkCreateTeamMembersAsync(body));

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
        /// This process is non-transactional and processes as much of the request as possible. If one of the creates in.
        /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response.
        /// contains explicit error information for the failed create.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkCreateTeamMembersResponse response from the API call.</returns>
        public async Task<Models.BulkCreateTeamMembersResponse> BulkCreateTeamMembersAsync(
            Models.BulkCreateTeamMembersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkCreateTeamMembersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/team-members/bulk-create")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
        /// This process is non-transactional and processes as much of the request as possible. If one of the updates in.
        /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response.
        /// contains explicit error information for the failed update.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateTeamMembersResponse response from the API call.</returns>
        public Models.BulkUpdateTeamMembersResponse BulkUpdateTeamMembers(
            Models.BulkUpdateTeamMembersRequest body
        ) => CoreHelper.RunTask(BulkUpdateTeamMembersAsync(body));

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
        /// This process is non-transactional and processes as much of the request as possible. If one of the updates in.
        /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response.
        /// contains explicit error information for the failed update.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpdateTeamMembersResponse response from the API call.</returns>
        public async Task<Models.BulkUpdateTeamMembersResponse> BulkUpdateTeamMembersAsync(
            Models.BulkUpdateTeamMembersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkUpdateTeamMembersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/team-members/bulk-update")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Lists jobs in a seller account. Results are sorted by title in ascending order.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListJobsResponse response from the API call.</returns>
        public Models.ListJobsResponse ListJobs(string cursor = null) =>
            CoreHelper.RunTask(ListJobsAsync(cursor));

        /// <summary>
        /// Lists jobs in a seller account. Results are sorted by title in ascending order.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListJobsResponse response from the API call.</returns>
        public async Task<Models.ListJobsResponse> ListJobsAsync(
            string cursor = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListJobsResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/team-members/jobs")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Query(_query => _query.Setup("cursor", cursor))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a job in a seller account. A job defines a title and tip eligibility. Note that.
        /// compensation is defined in a [job assignment]($m/JobAssignment) in a team member's wage setting.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateJobResponse response from the API call.</returns>
        public Models.CreateJobResponse CreateJob(Models.CreateJobRequest body) =>
            CoreHelper.RunTask(CreateJobAsync(body));

        /// <summary>
        /// Creates a job in a seller account. A job defines a title and tip eligibility. Note that.
        /// compensation is defined in a [job assignment]($m/JobAssignment) in a team member's wage setting.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateJobResponse response from the API call.</returns>
        public async Task<Models.CreateJobResponse> CreateJobAsync(
            Models.CreateJobRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.CreateJobResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/team-members/jobs")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a specified job.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to retrieve..</param>
        /// <returns>Returns the Models.RetrieveJobResponse response from the API call.</returns>
        public Models.RetrieveJobResponse RetrieveJob(string jobId) =>
            CoreHelper.RunTask(RetrieveJobAsync(jobId));

        /// <summary>
        /// Retrieves a specified job.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveJobResponse response from the API call.</returns>
        public async Task<Models.RetrieveJobResponse> RetrieveJobAsync(
            string jobId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveJobResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/team-members/jobs/{job_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template => _template.Setup("job_id", jobId))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates the title or tip eligibility of a job. Changes to the title propagate to all.
        /// `JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to.
        /// tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateJobResponse response from the API call.</returns>
        public Models.UpdateJobResponse UpdateJob(string jobId, Models.UpdateJobRequest body) =>
            CoreHelper.RunTask(UpdateJobAsync(jobId, body));

        /// <summary>
        /// Updates the title or tip eligibility of a job. Changes to the title propagate to all.
        /// `JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to.
        /// tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateJobResponse response from the API call.</returns>
        public async Task<Models.UpdateJobResponse> UpdateJobAsync(
            string jobId,
            Models.UpdateJobRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpdateJobResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/team-members/jobs/{job_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("job_id", jobId))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business. .
        /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether.
        /// the team member is the Square account owner.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        public Models.SearchTeamMembersResponse SearchTeamMembers(
            Models.SearchTeamMembersRequest body
        ) => CoreHelper.RunTask(SearchTeamMembersAsync(body));

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business. .
        /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether.
        /// the team member is the Square account owner.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        public async Task<Models.SearchTeamMembersResponse> SearchTeamMembersAsync(
            Models.SearchTeamMembersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.SearchTeamMembersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/team-members/search")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a `TeamMember` object for the given `TeamMember.id`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberResponse response from the API call.</returns>
        public Models.RetrieveTeamMemberResponse RetrieveTeamMember(string teamMemberId) =>
            CoreHelper.RunTask(RetrieveTeamMemberAsync(teamMemberId));

        /// <summary>
        /// Retrieves a `TeamMember` object for the given `TeamMember.id`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberResponse response from the API call.</returns>
        public async Task<Models.RetrieveTeamMemberResponse> RetrieveTeamMemberAsync(
            string teamMemberId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveTeamMemberResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/team-members/{team_member_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template =>
                                _template.Setup("team_member_id", teamMemberId)
                            )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateTeamMemberResponse response from the API call.</returns>
        public Models.UpdateTeamMemberResponse UpdateTeamMember(
            string teamMemberId,
            Models.UpdateTeamMemberRequest body
        ) => CoreHelper.RunTask(UpdateTeamMemberAsync(teamMemberId, body));

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateTeamMemberResponse response from the API call.</returns>
        public async Task<Models.UpdateTeamMemberResponse> UpdateTeamMemberAsync(
            string teamMemberId,
            Models.UpdateTeamMemberRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpdateTeamMemberResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/team-members/{team_member_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template =>
                                    _template.Setup("team_member_id", teamMemberId)
                                )
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a `WageSetting` object for a team member specified.
        /// by `TeamMember.id`. For more information, see.
        /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
        /// Square recommends using [RetrieveTeamMember]($e/Team/RetrieveTeamMember) or [SearchTeamMembers]($e/Team/SearchTeamMembers).
        /// to get this information directly from the `TeamMember.wage_setting` field.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to retrieve the wage setting..</param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        public Models.RetrieveWageSettingResponse RetrieveWageSetting(string teamMemberId) =>
            CoreHelper.RunTask(RetrieveWageSettingAsync(teamMemberId));

        /// <summary>
        /// Retrieves a `WageSetting` object for a team member specified.
        /// by `TeamMember.id`. For more information, see.
        /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
        /// Square recommends using [RetrieveTeamMember]($e/Team/RetrieveTeamMember) or [SearchTeamMembers]($e/Team/SearchTeamMembers).
        /// to get this information directly from the `TeamMember.wage_setting` field.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to retrieve the wage setting..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        public async Task<Models.RetrieveWageSettingResponse> RetrieveWageSettingAsync(
            string teamMemberId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveWageSettingResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/team-members/{team_member_id}/wage-setting")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template =>
                                _template.Setup("team_member_id", teamMemberId)
                            )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a.
        /// `WageSetting` with the specified `team_member_id` doesn't exist. Otherwise,.
        /// it fully replaces the `WageSetting` object for the team member.
        /// The `WageSetting` is returned on a successful update. For more information, see.
        /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).
        /// Square recommends using [CreateTeamMember]($e/Team/CreateTeamMember) or [UpdateTeamMember]($e/Team/UpdateTeamMember).
        /// to manage the `TeamMember.wage_setting` field directly.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to update the `WageSetting` object..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWageSettingResponse response from the API call.</returns>
        public Models.UpdateWageSettingResponse UpdateWageSetting(
            string teamMemberId,
            Models.UpdateWageSettingRequest body
        ) => CoreHelper.RunTask(UpdateWageSettingAsync(teamMemberId, body));

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a.
        /// `WageSetting` with the specified `team_member_id` doesn't exist. Otherwise,.
        /// it fully replaces the `WageSetting` object for the team member.
        /// The `WageSetting` is returned on a successful update. For more information, see.
        /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).
        /// Square recommends using [CreateTeamMember]($e/Team/CreateTeamMember) or [UpdateTeamMember]($e/Team/UpdateTeamMember).
        /// to manage the `TeamMember.wage_setting` field directly.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to update the `WageSetting` object..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWageSettingResponse response from the API call.</returns>
        public async Task<Models.UpdateWageSettingResponse> UpdateWageSettingAsync(
            string teamMemberId,
            Models.UpdateWageSettingRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpdateWageSettingResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/team-members/{team_member_id}/wage-setting")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template =>
                                    _template.Setup("team_member_id", teamMemberId)
                                )
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
