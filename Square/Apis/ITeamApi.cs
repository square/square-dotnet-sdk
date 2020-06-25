using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface ITeamApi
    {
        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates.
        /// You must provide the following values in your request to this endpoint:
        /// - `first_name`
        /// - `last_name`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTeamMemberResponse response from the API call</return>
        Models.CreateTeamMemberResponse CreateTeamMember(Models.CreateTeamMemberRequest body);

        /// <summary>
        /// Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates.
        /// You must provide the following values in your request to this endpoint:
        /// - `first_name`
        /// - `last_name`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#createteammember).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTeamMemberResponse response from the API call</return>
        Task<Models.CreateTeamMemberResponse> CreateTeamMemberAsync(Models.CreateTeamMemberRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the creates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular create.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkcreateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkCreateTeamMembersResponse response from the API call</return>
        Models.BulkCreateTeamMembersResponse BulkCreateTeamMembers(Models.BulkCreateTeamMembersRequest body);

        /// <summary>
        /// Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the creates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular create.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkcreateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkCreateTeamMembersResponse response from the API call</return>
        Task<Models.BulkCreateTeamMembersResponse> BulkCreateTeamMembersAsync(Models.BulkCreateTeamMembersRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the updates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular update.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkupdateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkUpdateTeamMembersResponse response from the API call</return>
        Models.BulkUpdateTeamMembersResponse BulkUpdateTeamMembers(Models.BulkUpdateTeamMembersRequest body);

        /// <summary>
        /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates.
        /// This process is non-transactional and will process as much of the request as is possible. If one of the updates in
        /// the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
        /// will contain explicit error information for this particular update.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkupdateteammembers).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BulkUpdateTeamMembersResponse response from the API call</return>
        Task<Models.BulkUpdateTeamMembersResponse> BulkUpdateTeamMembersAsync(Models.BulkUpdateTeamMembersRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business.
        /// The list to be returned can be filtered by:
        /// - location IDs **and**
        /// - `is_active`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTeamMembersResponse response from the API call</return>
        Models.SearchTeamMembersResponse SearchTeamMembers(Models.SearchTeamMembersRequest body);

        /// <summary>
        /// Returns a paginated list of `TeamMember` objects for a business.
        /// The list to be returned can be filtered by:
        /// - location IDs **and**
        /// - `is_active`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTeamMembersResponse response from the API call</return>
        Task<Models.SearchTeamMembersResponse> SearchTeamMembersAsync(Models.SearchTeamMembersRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve a `TeamMember` object for the given `TeamMember.id`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrieveteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve.</param>
        /// <return>Returns the Models.RetrieveTeamMemberResponse response from the API call</return>
        Models.RetrieveTeamMemberResponse RetrieveTeamMember(string teamMemberId);

        /// <summary>
        /// Retrieve a `TeamMember` object for the given `TeamMember.id`
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrieveteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve.</param>
        /// <return>Returns the Models.RetrieveTeamMemberResponse response from the API call</return>
        Task<Models.RetrieveTeamMemberResponse> RetrieveTeamMemberAsync(string teamMemberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updateteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateTeamMemberResponse response from the API call</return>
        Models.UpdateTeamMemberResponse UpdateTeamMember(string teamMemberId, Models.UpdateTeamMemberRequest body);

        /// <summary>
        /// Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updateteammember).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateTeamMemberResponse response from the API call</return>
        Task<Models.UpdateTeamMemberResponse> UpdateTeamMemberAsync(string teamMemberId, Models.UpdateTeamMemberRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve a `WageSetting` object for a team member specified
        /// by `TeamMember.id`.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrievewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve wage setting for</param>
        /// <return>Returns the Models.RetrieveWageSettingResponse response from the API call</return>
        Models.RetrieveWageSettingResponse RetrieveWageSetting(string teamMemberId);

        /// <summary>
        /// Retrieve a `WageSetting` object for a team member specified
        /// by `TeamMember.id`.
        /// Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrievewagesetting).
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve wage setting for</param>
        /// <return>Returns the Models.RetrieveWageSettingResponse response from the API call</return>
        Task<Models.RetrieveWageSettingResponse> RetrieveWageSettingAsync(string teamMemberId, CancellationToken cancellationToken = default);

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
        Models.UpdateWageSettingResponse UpdateWageSetting(string teamMemberId, Models.UpdateWageSettingRequest body);

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
        Task<Models.UpdateWageSettingResponse> UpdateWageSettingAsync(string teamMemberId, Models.UpdateWageSettingRequest body, CancellationToken cancellationToken = default);

    }
}