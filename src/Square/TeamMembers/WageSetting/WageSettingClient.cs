using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.TeamMembers.WageSetting;

public partial class WageSettingClient
{
    private RawClient _client;

    internal WageSettingClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a `WageSetting` object for a team member specified
    /// by `TeamMember.id`. For more information, see
    /// [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).
    ///
    /// Square recommends using [RetrieveTeamMember](api-endpoint:Team-RetrieveTeamMember) or [SearchTeamMembers](api-endpoint:Team-SearchTeamMembers)
    /// to get this information directly from the `TeamMember.wage_setting` field.
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.WageSetting.GetAsync(
    ///     new Square.TeamMembers.WageSetting.GetWageSettingRequest { TeamMemberId = "team_member_id" }
    /// );
    /// </code></example>
    public async Task<GetWageSettingResponse> GetAsync(
        GetWageSettingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/team-members/{0}/wage-setting",
                        ValueConvert.ToPathParameterString(request.TeamMemberId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetWageSettingResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

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
    /// <example><code>
    /// await client.TeamMembers.WageSetting.UpdateAsync(
    ///     new UpdateWageSettingRequest
    ///     {
    ///         TeamMemberId = "team_member_id",
    ///         WageSetting = new Square.WageSetting
    ///         {
    ///             JobAssignments = new List&lt;JobAssignment&gt;()
    ///             {
    ///                 new JobAssignment
    ///                 {
    ///                     JobTitle = "Manager",
    ///                     PayType = JobAssignmentPayType.Salary,
    ///                     AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
    ///                     WeeklyHours = 40,
    ///                 },
    ///                 new JobAssignment
    ///                 {
    ///                     JobTitle = "Cashier",
    ///                     PayType = JobAssignmentPayType.Hourly,
    ///                     HourlyRate = new Money { Amount = 2000, Currency = Currency.Usd },
    ///                 },
    ///             },
    ///             IsOvertimeExempt = true,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateWageSettingResponse> UpdateAsync(
        UpdateWageSettingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/team-members/{0}/wage-setting",
                        ValueConvert.ToPathParameterString(request.TeamMemberId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpdateWageSettingResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
