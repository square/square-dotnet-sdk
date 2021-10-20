namespace Square.Apis
{
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
        /// Returns a paginated list of `TeamMember` objects for a business.
        /// The list can be filtered by the following:.
        /// - location IDs.
        /// - `status`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTeamMembersResponse response from the API call.</returns>
        Models.SearchTeamMembersResponse SearchTeamMembers(
                Models.SearchTeamMembersRequest body);

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business.
        /// The list can be filtered by the following:.
        /// - location IDs.
        /// - `status`.
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
        /// by `TeamMember.id`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to retrieve the wage setting..</param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        Models.RetrieveWageSettingResponse RetrieveWageSetting(
                string teamMemberId);

        /// <summary>
        /// Retrieves a `WageSetting` object for a team member specified.
        /// by `TeamMember.id`.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to retrieve the wage setting..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveWageSettingResponse response from the API call.</returns>
        Task<Models.RetrieveWageSettingResponse> RetrieveWageSettingAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a.
        /// `WageSetting` with the specified `team_member_id` does not exist. Otherwise,.
        /// it fully replaces the `WageSetting` object for the team member.
        /// The `WageSetting` is returned on a successful update.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member for which to update the `WageSetting` object..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWageSettingResponse response from the API call.</returns>
        Models.UpdateWageSettingResponse UpdateWageSetting(
                string teamMemberId,
                Models.UpdateWageSettingRequest body);

        /// <summary>
        /// Creates or updates a `WageSetting` object. The object is created if a.
        /// `WageSetting` with the specified `team_member_id` does not exist. Otherwise,.
        /// it fully replaces the `WageSetting` object for the team member.
        /// The `WageSetting` is returned on a successful update.
        /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).
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