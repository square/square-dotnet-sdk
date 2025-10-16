using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;
using Square.TeamMembers.WageSetting;

namespace Square.TeamMembers;

public partial class TeamMembersClient
{
    private RawClient _client;

    internal TeamMembersClient(RawClient client)
    {
        _client = client;
        WageSetting = new WageSettingClient(_client);
    }

    public WageSettingClient WageSetting { get; }

    /// <summary>
    /// Returns a paginated list of `TeamMember` objects for a business.
    /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether
    /// the team member is the Square account owner.
    /// </summary>
    private async Task<SearchTeamMembersResponse> SearchInternalAsync(
        SearchTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/team-members/search",
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
                return JsonUtils.Deserialize<SearchTeamMembersResponse>(responseBody)!;
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
    /// Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
    /// You must provide the following values in your request to this endpoint:
    /// - `given_name`
    /// - `family_name`
    ///
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.CreateAsync(
    ///     new CreateTeamMemberRequest
    ///     {
    ///         IdempotencyKey = "idempotency-key-0",
    ///         TeamMember = new TeamMember
    ///         {
    ///             ReferenceId = "reference_id_1",
    ///             Status = TeamMemberStatus.Active,
    ///             GivenName = "Joe",
    ///             FamilyName = "Doe",
    ///             EmailAddress = "joe_doe@gmail.com",
    ///             PhoneNumber = "+14159283333",
    ///             AssignedLocations = new TeamMemberAssignedLocations
    ///             {
    ///                 AssignmentType = TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
    ///                 LocationIds = new List&lt;string&gt;() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
    ///             },
    ///             WageSetting = new Square.WageSetting
    ///             {
    ///                 JobAssignments = new List&lt;JobAssignment&gt;()
    ///                 {
    ///                     new JobAssignment
    ///                     {
    ///                         PayType = JobAssignmentPayType.Salary,
    ///                         AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
    ///                         WeeklyHours = 40,
    ///                         JobId = "FjS8x95cqHiMenw4f1NAUH4P",
    ///                     },
    ///                     new JobAssignment
    ///                     {
    ///                         PayType = JobAssignmentPayType.Hourly,
    ///                         HourlyRate = new Money { Amount = 2000, Currency = Currency.Usd },
    ///                         JobId = "VDNpRv8da51NU8qZFC5zDWpF",
    ///                     },
    ///                 },
    ///                 IsOvertimeExempt = true,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateTeamMemberResponse> CreateAsync(
        CreateTeamMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/team-members",
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
                return JsonUtils.Deserialize<CreateTeamMemberResponse>(responseBody)!;
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
    /// Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
    /// This process is non-transactional and processes as much of the request as possible. If one of the creates in
    /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response
    /// contains explicit error information for the failed create.
    ///
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.BatchCreateAsync(
    ///     new BatchCreateTeamMembersRequest
    ///     {
    ///         TeamMembers = new Dictionary&lt;string, CreateTeamMemberRequest&gt;()
    ///         {
    ///             {
    ///                 "idempotency-key-1",
    ///                 new CreateTeamMemberRequest
    ///                 {
    ///                     TeamMember = new TeamMember
    ///                     {
    ///                         ReferenceId = "reference_id_1",
    ///                         GivenName = "Joe",
    ///                         FamilyName = "Doe",
    ///                         EmailAddress = "joe_doe@gmail.com",
    ///                         PhoneNumber = "+14159283333",
    ///                         AssignedLocations = new TeamMemberAssignedLocations
    ///                         {
    ///                             AssignmentType =
    ///                                 TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
    ///                             LocationIds = new List&lt;string&gt;() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
    ///                         },
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "idempotency-key-2",
    ///                 new CreateTeamMemberRequest
    ///                 {
    ///                     TeamMember = new TeamMember
    ///                     {
    ///                         ReferenceId = "reference_id_2",
    ///                         GivenName = "Jane",
    ///                         FamilyName = "Smith",
    ///                         EmailAddress = "jane_smith@gmail.com",
    ///                         PhoneNumber = "+14159223334",
    ///                         AssignedLocations = new TeamMemberAssignedLocations
    ///                         {
    ///                             AssignmentType =
    ///                                 TeamMemberAssignedLocationsAssignmentType.AllCurrentAndFutureLocations,
    ///                         },
    ///                     },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchCreateTeamMembersResponse> BatchCreateAsync(
        BatchCreateTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/team-members/bulk-create",
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
                return JsonUtils.Deserialize<BatchCreateTeamMembersResponse>(responseBody)!;
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
    /// Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
    /// This process is non-transactional and processes as much of the request as possible. If one of the updates in
    /// the request cannot be successfully processed, the request is not marked as failed, but the body of the response
    /// contains explicit error information for the failed update.
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.BatchUpdateAsync(
    ///     new BatchUpdateTeamMembersRequest
    ///     {
    ///         TeamMembers = new Dictionary&lt;string, UpdateTeamMemberRequest&gt;()
    ///         {
    ///             {
    ///                 "AFMwA08kR-MIF-3Vs0OE",
    ///                 new UpdateTeamMemberRequest
    ///                 {
    ///                     TeamMember = new TeamMember
    ///                     {
    ///                         ReferenceId = "reference_id_2",
    ///                         IsOwner = false,
    ///                         Status = TeamMemberStatus.Active,
    ///                         GivenName = "Jane",
    ///                         FamilyName = "Smith",
    ///                         EmailAddress = "jane_smith@gmail.com",
    ///                         PhoneNumber = "+14159223334",
    ///                         AssignedLocations = new TeamMemberAssignedLocations
    ///                         {
    ///                             AssignmentType =
    ///                                 TeamMemberAssignedLocationsAssignmentType.AllCurrentAndFutureLocations,
    ///                         },
    ///                     },
    ///                 }
    ///             },
    ///             {
    ///                 "fpgteZNMaf0qOK-a4t6P",
    ///                 new UpdateTeamMemberRequest
    ///                 {
    ///                     TeamMember = new TeamMember
    ///                     {
    ///                         ReferenceId = "reference_id_1",
    ///                         IsOwner = false,
    ///                         Status = TeamMemberStatus.Active,
    ///                         GivenName = "Joe",
    ///                         FamilyName = "Doe",
    ///                         EmailAddress = "joe_doe@gmail.com",
    ///                         PhoneNumber = "+14159283333",
    ///                         AssignedLocations = new TeamMemberAssignedLocations
    ///                         {
    ///                             AssignmentType =
    ///                                 TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
    ///                             LocationIds = new List&lt;string&gt;() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
    ///                         },
    ///                     },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BatchUpdateTeamMembersResponse> BatchUpdateAsync(
        BatchUpdateTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/team-members/bulk-update",
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
                return JsonUtils.Deserialize<BatchUpdateTeamMembersResponse>(responseBody)!;
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
    /// Returns a paginated list of `TeamMember` objects for a business.
    /// The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether
    /// the team member is the Square account owner.
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.SearchAsync(
    ///     new SearchTeamMembersRequest
    ///     {
    ///         Query = new SearchTeamMembersQuery
    ///         {
    ///             Filter = new SearchTeamMembersFilter
    ///             {
    ///                 LocationIds = new List&lt;string&gt;() { "0G5P3VGACMMQZ" },
    ///                 Status = TeamMemberStatus.Active,
    ///             },
    ///         },
    ///         Limit = 10,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<TeamMember>> SearchAsync(
        SearchTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            SearchTeamMembersRequest,
            RequestOptions?,
            SearchTeamMembersResponse,
            string?,
            TeamMember
        >
            .CreateInstanceAsync(
                request,
                options,
                SearchInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.TeamMembers?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a `TeamMember` object for the given `TeamMember.id`.
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.GetAsync(new GetTeamMembersRequest { TeamMemberId = "team_member_id" });
    /// </code></example>
    public async Task<GetTeamMemberResponse> GetAsync(
        GetTeamMembersRequest request,
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
                        "v2/team-members/{0}",
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
                return JsonUtils.Deserialize<GetTeamMemberResponse>(responseBody)!;
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
    /// Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
    /// Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
    /// </summary>
    /// <example><code>
    /// await client.TeamMembers.UpdateAsync(
    ///     new UpdateTeamMembersRequest
    ///     {
    ///         TeamMemberId = "team_member_id",
    ///         Body = new UpdateTeamMemberRequest
    ///         {
    ///             TeamMember = new TeamMember
    ///             {
    ///                 ReferenceId = "reference_id_1",
    ///                 Status = TeamMemberStatus.Active,
    ///                 GivenName = "Joe",
    ///                 FamilyName = "Doe",
    ///                 EmailAddress = "joe_doe@gmail.com",
    ///                 PhoneNumber = "+14159283333",
    ///                 AssignedLocations = new TeamMemberAssignedLocations
    ///                 {
    ///                     AssignmentType = TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
    ///                     LocationIds = new List&lt;string&gt;() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
    ///                 },
    ///                 WageSetting = new Square.WageSetting
    ///                 {
    ///                     JobAssignments = new List&lt;JobAssignment&gt;()
    ///                     {
    ///                         new JobAssignment
    ///                         {
    ///                             PayType = JobAssignmentPayType.Salary,
    ///                             AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
    ///                             WeeklyHours = 40,
    ///                             JobId = "FjS8x95cqHiMenw4f1NAUH4P",
    ///                         },
    ///                         new JobAssignment
    ///                         {
    ///                             PayType = JobAssignmentPayType.Hourly,
    ///                             HourlyRate = new Money { Amount = 1200, Currency = Currency.Usd },
    ///                             JobId = "VDNpRv8da51NU8qZFC5zDWpF",
    ///                         },
    ///                     },
    ///                     IsOvertimeExempt = true,
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateTeamMemberResponse> UpdateAsync(
        UpdateTeamMembersRequest request,
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
                        "v2/team-members/{0}",
                        ValueConvert.ToPathParameterString(request.TeamMemberId)
                    ),
                    Body = request.Body,
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
                return JsonUtils.Deserialize<UpdateTeamMemberResponse>(responseBody)!;
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
