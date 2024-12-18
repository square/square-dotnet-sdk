using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Http.Client;
using Square.Http.Request;
using Square.Http.Response;
using Square.Utilities;

namespace Square.Apis
{
    /// <summary>
    /// ITeamApi.
    /// </summary>
    public interface ITeamApi
    {
        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
        /// You must provide the following values in your request to this endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTeamMemberResponse response from the API call.</returns>
        Models.CreateTeamMemberResponse CreateTeamMember(
                Models.CreateTeamMemberRequest body);

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
        Task<Models.CreateTeamMemberResponse> CreateTeamMemberAsync(
                Models.CreateTeamMemberRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
        /// This process is non-transactional and processes as much of the request as possible. If one of the creates in.
        /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response.
        /// contains explicit error information for the failed create.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateTeamMembersResponse response from the API call.</returns>
        Models.BulkCreateTeamMembersResponse BulkCreateTeamMembers(
                Models.BulkCreateTeamMembersRequest body);

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
        Task<Models.BulkCreateTeamMembersResponse> BulkCreateTeamMembersAsync(
                Models.BulkCreateTeamMembersRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
        /// This process is non-transactional and processes as much of the request as possible. If one of the updates in.
        /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response.
        /// contains explicit error information for the failed update.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateTeamMembersResponse response from the API call.</returns>
        Models.BulkUpdateTeamMembersResponse BulkUpdateTeamMembers(
                Models.BulkUpdateTeamMembersRequest body);

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
        Task<Models.BulkUpdateTeamMembersResponse> BulkUpdateTeamMembersAsync(
                Models.BulkUpdateTeamMembersRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists jobs in a seller account. Results are sorted by title in ascending order.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListJobsResponse response from the API call.</returns>
        Models.ListJobsResponse ListJobs(
                string cursor = null);

        /// <summary>
        /// Lists jobs in a seller account. Results are sorted by title in ascending order.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListJobsResponse response from the API call.</returns>
        Task<Models.ListJobsResponse> ListJobsAsync(
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a job in a seller account. A job defines a title and tip eligibility. Note that.
        /// compensation is defined in a [job assignment]($m/JobAssignment) in a team member's wage setting.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateJobResponse response from the API call.</returns>
        Models.CreateJobResponse CreateJob(
                Models.CreateJobRequest body);

        /// <summary>
        /// Creates a job in a seller account. A job defines a title and tip eligibility. Note that.
        /// compensation is defined in a [job assignment]($m/JobAssignment) in a team member's wage setting.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateJobResponse response from the API call.</returns>
        Task<Models.CreateJobResponse> CreateJobAsync(
                Models.CreateJobRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specified job.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to retrieve..</param>
        /// <returns>Returns the Models.RetrieveJobResponse response from the API call.</returns>
        Models.RetrieveJobResponse RetrieveJob(
                string jobId);

        /// <summary>
        /// Retrieves a specified job.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveJobResponse response from the API call.</returns>
        Task<Models.RetrieveJobResponse> RetrieveJobAsync(
                string jobId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the title or tip eligibility of a job. Changes to the title propagate to all.
        /// `JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to.
        /// tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateJobResponse response from the API call.</returns>
        Models.UpdateJobResponse UpdateJob(
                string jobId,
                Models.UpdateJobRequest body);

        /// <summary>
        /// Updates the title or tip eligibility of a job. Changes to the title propagate to all.
        /// `JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to.
        /// tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
        /// </summary>
        /// <param name="jobId">Required parameter: The ID of the job to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateJobResponse response from the API call.</returns>
        Task<Models.UpdateJobResponse> UpdateJobAsync(
                string jobId,
                Models.UpdateJobRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business. .
        /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether.
        /// the team member is the Square account owner.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        Models.SearchTeamMembersResponse SearchTeamMembers(
                Models.SearchTeamMembersRequest body);

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business. .
        /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether.
        /// the team member is the Square account owner.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        Task<Models.SearchTeamMembersResponse> SearchTeamMembersAsync(
                Models.SearchTeamMembersRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a `TeamMember` object for the given `TeamMember.id`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberResponse response from the API call.</returns>
        Models.RetrieveTeamMemberResponse RetrieveTeamMember(
                string teamMemberId);

        /// <summary>
        /// Retrieves a `TeamMember` object for the given `TeamMember.id`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberResponse response from the API call.</returns>
        Task<Models.RetrieveTeamMemberResponse> RetrieveTeamMemberAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateTeamMemberResponse response from the API call.</returns>
        Models.UpdateTeamMemberResponse UpdateTeamMember(
                string teamMemberId,
                Models.UpdateTeamMemberRequest body);

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateTeamMemberResponse response from the API call.</returns>
        Task<Models.UpdateTeamMemberResponse> UpdateTeamMemberAsync(
                string teamMemberId,
                Models.UpdateTeamMemberRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a `WageSetting` object for a team member specified.
        /// by `TeamMember.id`. For more information, see.
        /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
        /// Square recommends using [RetrieveTeamMember]($e/Team/RetrieveTeamMember) or [SearchTeamMembers]($e/Team/SearchTeamMembers).
        /// to get this information directly from the `TeamMember.wage_setting` field.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to retrieve the wage setting..</param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        Models.RetrieveWageSettingResponse RetrieveWageSetting(
                string teamMemberId);

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
        Task<Models.RetrieveWageSettingResponse> RetrieveWageSettingAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default);

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
        Models.UpdateWageSettingResponse UpdateWageSetting(
                string teamMemberId,
                Models.UpdateWageSettingRequest body);

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
        Task<Models.UpdateWageSettingResponse> UpdateWageSettingAsync(
                string teamMemberId,
                Models.UpdateWageSettingRequest body,
                CancellationToken cancellationToken = default);
    }
}