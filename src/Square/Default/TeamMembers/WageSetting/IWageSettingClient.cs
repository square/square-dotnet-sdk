using Square;
using Square.Default;

namespace Square.Default.TeamMembers;

public partial interface IWageSettingClient
{
    /// <summary>
    /// Retrieves a `WageSetting` object for a team member specified
    /// by `TeamMember.id`. For more information, see
    /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
    ///
    /// Square recommends using [RetrieveTeamMember](api-endpoint:Team-RetrieveTeamMember) or [SearchTeamMembers](api-endpoint:Team-SearchTeamMembers)
    /// to get this information directly from the `TeamMember.wage_setting` field.
    /// </summary>
    Task<GetWageSettingResponse> GetAsync(
        GetWageSettingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates a `WageSetting` object. The object is created if a
    /// `WageSetting` with the specified `team_member_id` doesn't exist. Otherwise,
    /// it fully replaces the `WageSetting` object for the team member.
    /// The `WageSetting` is returned on a successful update. For more information, see
    /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).
    ///
    /// Square recommends using [CreateTeamMember](api-endpoint:Team-CreateTeamMember) or [UpdateTeamMember](api-endpoint:Team-UpdateTeamMember)
    /// to manage the `TeamMember.wage_setting` field directly.
    /// </summary>
    Task<UpdateWageSettingResponse> UpdateAsync(
        UpdateWageSettingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
