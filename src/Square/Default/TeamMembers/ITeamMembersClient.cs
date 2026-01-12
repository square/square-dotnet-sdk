using Square;
using Square.Default;
using Square.Default.TeamMembers.WageSetting;

namespace Square.Default.TeamMembers;

public partial interface ITeamMembersClient
{
    public WageSettingClient WageSetting { get; }

    /// <summary>
    /// Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
    /// You must provide the following values in your request to this endpoint:
    /// - `given_name`
    /// - `family_name`
    ///
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).
    /// </summary>
    Task<CreateTeamMemberResponse> CreateAsync(
        CreateTeamMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
    /// This process is non-transactional and processes as much of the request as possible. If one of the creates in
    /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response
    /// contains explicit error information for the failed create.
    ///
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).
    /// </summary>
    Task<BatchCreateTeamMembersResponse> BatchCreateAsync(
        BatchCreateTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
    /// This process is non-transactional and processes as much of the request as possible. If one of the updates in
    /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response
    /// contains explicit error information for the failed update.
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).
    /// </summary>
    Task<BatchUpdateTeamMembersResponse> BatchUpdateAsync(
        BatchUpdateTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of `TeamMember` objects for a business.
    /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether
    /// the team member is the Square account owner.
    /// </summary>
    Task<SearchTeamMembersResponse> SearchAsync(
        SearchTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a `TeamMember` object for the given `TeamMember.id`.
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
    /// </summary>
    Task<GetTeamMemberResponse> GetAsync(
        GetTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
    /// </summary>
    Task<UpdateTeamMemberResponse> UpdateAsync(
        UpdateTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
