using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

public partial interface ITeamMemberWagesClient
{
    /// <summary>
    /// Returns a paginated list of `TeamMemberWage` instances for a business.
    /// </summary>
    Task<Pager<TeamMemberWage>> ListAsync(
        ListTeamMemberWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single `TeamMemberWage` specified by `id`.
    /// </summary>
    Task<GetTeamMemberWageResponse> GetAsync(
        GetTeamMemberWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
