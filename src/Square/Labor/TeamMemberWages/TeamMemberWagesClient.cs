using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Labor.TeamMemberWages;

public partial class TeamMemberWagesClient
{
    private RawClient _client;

    internal TeamMemberWagesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a paginated list of `TeamMemberWage` instances for a business.
    /// </summary>
    private async Task<ListTeamMemberWagesResponse> ListInternalAsync(
        ListTeamMemberWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.TeamMemberId != null)
        {
            _query["team_member_id"] = request.TeamMemberId;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/labor/team-member-wages",
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
                return JsonUtils.Deserialize<ListTeamMemberWagesResponse>(responseBody)!;
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
    /// Returns a paginated list of `TeamMemberWage` instances for a business.
    /// </summary>
    /// <example><code>
    /// await client.Labor.TeamMemberWages.ListAsync(
    ///     new ListTeamMemberWagesRequest
    ///     {
    ///         TeamMemberId = "team_member_id",
    ///         Limit = 1,
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<TeamMemberWage>> ListAsync(
        ListTeamMemberWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListTeamMemberWagesRequest,
            RequestOptions?,
            ListTeamMemberWagesResponse,
            string?,
            TeamMemberWage
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.TeamMemberWages?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns a single `TeamMemberWage` specified by `id`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.TeamMemberWages.GetAsync(new GetTeamMemberWagesRequest { Id = "id" });
    /// </code></example>
    public async Task<GetTeamMemberWageResponse> GetAsync(
        GetTeamMemberWagesRequest request,
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
                        "v2/labor/team-member-wages/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                return JsonUtils.Deserialize<GetTeamMemberWageResponse>(responseBody)!;
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
