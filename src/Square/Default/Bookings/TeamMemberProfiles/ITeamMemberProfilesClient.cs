using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Bookings.TeamMemberProfiles;

public partial interface ITeamMemberProfilesClient
{
    /// <summary>
    /// Lists booking profiles for team members.
    /// </summary>
    Task<Pager<TeamMemberBookingProfile>> ListAsync(
        ListTeamMemberProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a team member's booking profile.
    /// </summary>
    Task<GetTeamMemberBookingProfileResponse> GetAsync(
        GetTeamMemberProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
