using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Bookings.TeamMemberProfiles;

public partial class TeamMemberProfilesClient
{
    private RawClient _client;

    internal TeamMemberProfilesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists booking profiles for team members.
    /// </summary>
    private async Task<ListTeamMemberBookingProfilesResponse> ListInternalAsync(
        ListTeamMemberProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.BookableOnly != null)
        {
            _query["bookable_only"] = JsonUtils.Serialize(request.BookableOnly.Value);
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/bookings/team-member-booking-profiles",
                    Query = _query,
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
                return JsonUtils.Deserialize<ListTeamMemberBookingProfilesResponse>(responseBody)!;
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
    /// Lists booking profiles for team members.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.TeamMemberProfiles.ListAsync(
    ///     new ListTeamMemberProfilesRequest
    ///     {
    ///         BookableOnly = true,
    ///         Limit = 1,
    ///         Cursor = "cursor",
    ///         LocationId = "location_id",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<TeamMemberBookingProfile>> ListAsync(
        ListTeamMemberProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListTeamMemberProfilesRequest,
            RequestOptions?,
            ListTeamMemberBookingProfilesResponse,
            string?,
            TeamMemberBookingProfile
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.TeamMemberBookingProfiles?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a team member's booking profile.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.TeamMemberProfiles.GetAsync(
    ///     new GetTeamMemberProfilesRequest { TeamMemberId = "team_member_id" }
    /// );
    /// </code></example>
    public async Task<GetTeamMemberBookingProfileResponse> GetAsync(
        GetTeamMemberProfilesRequest request,
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
                        "v2/bookings/team-member-booking-profiles/{0}",
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
                return JsonUtils.Deserialize<GetTeamMemberBookingProfileResponse>(responseBody)!;
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
