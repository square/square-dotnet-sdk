using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;
using Square.Labor.BreakTypes;
using Square.Labor.EmployeeWages;
using Square.Labor.Shifts;
using Square.Labor.TeamMemberWages;
using Square.Labor.WorkweekConfigs;

namespace Square.Labor;

public partial class LaborClient
{
    private RawClient _client;

    internal LaborClient(RawClient client)
    {
        _client = client;
        BreakTypes = new BreakTypesClient(_client);
        EmployeeWages = new EmployeeWagesClient(_client);
        Shifts = new ShiftsClient(_client);
        TeamMemberWages = new TeamMemberWagesClient(_client);
        WorkweekConfigs = new WorkweekConfigsClient(_client);
    }

    public BreakTypesClient BreakTypes { get; }

    public EmployeeWagesClient EmployeeWages { get; }

    public ShiftsClient Shifts { get; }

    public TeamMemberWagesClient TeamMemberWages { get; }

    public WorkweekConfigsClient WorkweekConfigs { get; }

    /// <summary>
    /// Creates a scheduled shift by providing draft shift details such as job ID,
    /// team member assignment, and start and end times.
    ///
    /// The following `draft_shift_details` fields are required:
    /// - `location_id`
    /// - `job_id`
    /// - `start_at`
    /// - `end_at`
    /// </summary>
    /// <example><code>
    /// await client.Labor.CreateScheduledShiftAsync(
    ///     new CreateScheduledShiftRequest
    ///     {
    ///         IdempotencyKey = "HIDSNG5KS478L",
    ///         ScheduledShift = new ScheduledShift
    ///         {
    ///             DraftShiftDetails = new ScheduledShiftDetails
    ///             {
    ///                 TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
    ///                 LocationId = "PAA1RJZZKXBFG",
    ///                 JobId = "FzbJAtt9qEWncK1BWgVCxQ6M",
    ///                 StartAt = "2019-01-25T03:11:00-05:00",
    ///                 EndAt = "2019-01-25T13:11:00-05:00",
    ///                 Notes = "Dont forget to prep the vegetables",
    ///                 IsDeleted = false,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateScheduledShiftResponse> CreateScheduledShiftAsync(
        CreateScheduledShiftRequest request,
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
                    Path = "v2/labor/scheduled-shifts",
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
                return JsonUtils.Deserialize<CreateScheduledShiftResponse>(responseBody)!;
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
    /// Publishes 1 - 100 scheduled shifts. This endpoint takes a map of individual publish
    /// requests and returns a map of responses. When a scheduled shift is published, Square keeps
    /// the `draft_shift_details` field as is and copies it to the `published_shift_details` field.
    ///
    /// The minimum `start_at` and maximum `end_at` timestamps of all shifts in a
    /// `BulkPublishScheduledShifts` request must fall within a two-week period.
    /// </summary>
    /// <example><code>
    /// await client.Labor.BulkPublishScheduledShiftsAsync(
    ///     new BulkPublishScheduledShiftsRequest
    ///     {
    ///         ScheduledShifts = new Dictionary&lt;string, BulkPublishScheduledShiftsData&gt;()
    ///         {
    ///             { "key", new BulkPublishScheduledShiftsData() },
    ///         },
    ///         ScheduledShiftNotificationAudience = ScheduledShiftNotificationAudience.Affected,
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkPublishScheduledShiftsResponse> BulkPublishScheduledShiftsAsync(
        BulkPublishScheduledShiftsRequest request,
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
                    Path = "v2/labor/scheduled-shifts/bulk-publish",
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
                return JsonUtils.Deserialize<BulkPublishScheduledShiftsResponse>(responseBody)!;
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
    /// Returns a paginated list of scheduled shifts, with optional filter and sort settings.
    /// By default, results are sorted by `start_at` in ascending order.
    /// </summary>
    /// <example><code>
    /// await client.Labor.SearchScheduledShiftsAsync(
    ///     new SearchScheduledShiftsRequest
    ///     {
    ///         Query = new ScheduledShiftQuery
    ///         {
    ///             Filter = new ScheduledShiftFilter
    ///             {
    ///                 AssignmentStatus = ScheduledShiftFilterAssignmentStatus.Assigned,
    ///             },
    ///             Sort = new ScheduledShiftSort
    ///             {
    ///                 Field = ScheduledShiftSortField.CreatedAt,
    ///                 Order = SortOrder.Asc,
    ///             },
    ///         },
    ///         Limit = 2,
    ///         Cursor = "xoxp-1234-5678-90123",
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchScheduledShiftsResponse> SearchScheduledShiftsAsync(
        SearchScheduledShiftsRequest request,
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
                    Path = "v2/labor/scheduled-shifts/search",
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
                return JsonUtils.Deserialize<SearchScheduledShiftsResponse>(responseBody)!;
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
    /// Retrieves a scheduled shift by ID.
    /// </summary>
    /// <example><code>
    /// await client.Labor.RetrieveScheduledShiftAsync(new RetrieveScheduledShiftRequest { Id = "id" });
    /// </code></example>
    public async Task<RetrieveScheduledShiftResponse> RetrieveScheduledShiftAsync(
        RetrieveScheduledShiftRequest request,
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
                        "v2/labor/scheduled-shifts/{0}",
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
                return JsonUtils.Deserialize<RetrieveScheduledShiftResponse>(responseBody)!;
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
    /// Updates the draft shift details for a scheduled shift. This endpoint supports
    /// sparse updates, so only new, changed, or removed fields are required in the request.
    /// You must publish the shift to make updates public.
    ///
    /// You can make the following updates to `draft_shift_details`:
    /// - Change the `location_id`, `job_id`, `start_at`, and `end_at` fields.
    /// - Add, change, or clear the `team_member_id` and `notes` fields. To clear these fields,
    /// set the value to null.
    /// - Change the `is_deleted` field. To delete a scheduled shift, set `is_deleted` to true
    /// and then publish the shift.
    /// </summary>
    /// <example><code>
    /// await client.Labor.UpdateScheduledShiftAsync(
    ///     new UpdateScheduledShiftRequest
    ///     {
    ///         Id = "id",
    ///         ScheduledShift = new ScheduledShift
    ///         {
    ///             DraftShiftDetails = new ScheduledShiftDetails
    ///             {
    ///                 TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
    ///                 LocationId = "PAA1RJZZKXBFG",
    ///                 JobId = "FzbJAtt9qEWncK1BWgVCxQ6M",
    ///                 StartAt = "2019-03-25T03:11:00-05:00",
    ///                 EndAt = "2019-03-25T13:18:00-05:00",
    ///                 Notes = "Dont forget to prep the vegetables",
    ///                 IsDeleted = false,
    ///             },
    ///             Version = 1,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateScheduledShiftResponse> UpdateScheduledShiftAsync(
        UpdateScheduledShiftRequest request,
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
                        "v2/labor/scheduled-shifts/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                return JsonUtils.Deserialize<UpdateScheduledShiftResponse>(responseBody)!;
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
    /// Publishes a scheduled shift. When a scheduled shift is published, Square keeps the
    /// `draft_shift_details` field as is and copies it to the `published_shift_details` field.
    /// </summary>
    /// <example><code>
    /// await client.Labor.PublishScheduledShiftAsync(
    ///     new PublishScheduledShiftRequest
    ///     {
    ///         Id = "id",
    ///         IdempotencyKey = "HIDSNG5KS478L",
    ///         Version = 2,
    ///         ScheduledShiftNotificationAudience = ScheduledShiftNotificationAudience.All,
    ///     }
    /// );
    /// </code></example>
    public async Task<PublishScheduledShiftResponse> PublishScheduledShiftAsync(
        PublishScheduledShiftRequest request,
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
                    Path = string.Format(
                        "v2/labor/scheduled-shifts/{0}/publish",
                        ValueConvert.ToPathParameterString(request.Id)
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
                return JsonUtils.Deserialize<PublishScheduledShiftResponse>(responseBody)!;
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
    /// Creates a new `Timecard`.
    ///
    /// A `Timecard` represents a complete workday for a single team member.
    /// You must provide the following values in your request to this
    /// endpoint:
    ///
    /// - `location_id`
    /// - `team_member_id`
    /// - `start_at`
    ///
    /// An attempt to create a new `Timecard` can result in a `BAD_REQUEST` error when:
    /// - The `status` of the new `Timecard` is `OPEN` and the team member has another
    /// timecard with an `OPEN` status.
    /// - The `start_at` date is in the future.
    /// - The `start_at` or `end_at` date overlaps another timecard for the same team member.
    /// - The `Break` instances are set in the request and a break `start_at`
    /// is before the `Timecard.start_at`, a break `end_at` is after
    /// the `Timecard.end_at`, or both.
    /// </summary>
    /// <example><code>
    /// await client.Labor.CreateTimecardAsync(
    ///     new CreateTimecardRequest
    ///     {
    ///         IdempotencyKey = "HIDSNG5KS478L",
    ///         Timecard = new Timecard
    ///         {
    ///             LocationId = "PAA1RJZZKXBFG",
    ///             StartAt = "2019-01-25T03:11:00-05:00",
    ///             EndAt = "2019-01-25T13:11:00-05:00",
    ///             Wage = new TimecardWage
    ///             {
    ///                 Title = "Barista",
    ///                 HourlyRate = new Money { Amount = 1100, Currency = Currency.Usd },
    ///                 TipEligible = true,
    ///             },
    ///             Breaks = new List&lt;Break&gt;()
    ///             {
    ///                 new Break
    ///                 {
    ///                     StartAt = "2019-01-25T06:11:00-05:00",
    ///                     EndAt = "2019-01-25T06:16:00-05:00",
    ///                     BreakTypeId = "REGS1EQR1TPZ5",
    ///                     Name = "Tea Break",
    ///                     ExpectedDuration = "PT5M",
    ///                     IsPaid = true,
    ///                 },
    ///             },
    ///             TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
    ///             DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateTimecardResponse> CreateTimecardAsync(
        CreateTimecardRequest request,
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
                    Path = "v2/labor/timecards",
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
                return JsonUtils.Deserialize<CreateTimecardResponse>(responseBody)!;
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
    /// Returns a paginated list of `Timecard` records for a business.
    /// The list to be returned can be filtered by:
    /// - Location IDs
    /// - Team member IDs
    /// - Timecard status (`OPEN` or `CLOSED`)
    /// - Timecard start
    /// - Timecard end
    /// - Workday details
    ///
    /// The list can be sorted by:
    /// - `START_AT`
    /// - `END_AT`
    /// - `CREATED_AT`
    /// - `UPDATED_AT`
    /// </summary>
    /// <example><code>
    /// await client.Labor.SearchTimecardsAsync(
    ///     new SearchTimecardsRequest
    ///     {
    ///         Query = new TimecardQuery
    ///         {
    ///             Filter = new TimecardFilter
    ///             {
    ///                 Workday = new TimecardWorkday
    ///                 {
    ///                     DateRange = new DateRange { StartDate = "2019-01-20", EndDate = "2019-02-03" },
    ///                     MatchTimecardsBy = TimecardWorkdayMatcher.StartAt,
    ///                     DefaultTimezone = "America/Los_Angeles",
    ///                 },
    ///             },
    ///         },
    ///         Limit = 100,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchTimecardsResponse> SearchTimecardsAsync(
        SearchTimecardsRequest request,
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
                    Path = "v2/labor/timecards/search",
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
                return JsonUtils.Deserialize<SearchTimecardsResponse>(responseBody)!;
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
    /// Returns a single `Timecard` specified by `id`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.RetrieveTimecardAsync(new RetrieveTimecardRequest { Id = "id" });
    /// </code></example>
    public async Task<RetrieveTimecardResponse> RetrieveTimecardAsync(
        RetrieveTimecardRequest request,
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
                        "v2/labor/timecards/{0}",
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
                return JsonUtils.Deserialize<RetrieveTimecardResponse>(responseBody)!;
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
    /// Updates an existing `Timecard`.
    ///
    /// When adding a `Break` to a `Timecard`, any earlier `Break` instances in the `Timecard` have
    /// the `end_at` property set to a valid RFC-3339 datetime string.
    ///
    /// When closing a `Timecard`, all `Break` instances in the `Timecard` must be complete with `end_at`
    /// set on each `Break`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.UpdateTimecardAsync(
    ///     new UpdateTimecardRequest
    ///     {
    ///         Id = "id",
    ///         Timecard = new Timecard
    ///         {
    ///             LocationId = "PAA1RJZZKXBFG",
    ///             StartAt = "2019-01-25T03:11:00-05:00",
    ///             EndAt = "2019-01-25T13:11:00-05:00",
    ///             Wage = new TimecardWage
    ///             {
    ///                 Title = "Bartender",
    ///                 HourlyRate = new Money { Amount = 1500, Currency = Currency.Usd },
    ///                 TipEligible = true,
    ///             },
    ///             Breaks = new List&lt;Break&gt;()
    ///             {
    ///                 new Break
    ///                 {
    ///                     Id = "X7GAQYVVRRG6P",
    ///                     StartAt = "2019-01-25T06:11:00-05:00",
    ///                     EndAt = "2019-01-25T06:16:00-05:00",
    ///                     BreakTypeId = "REGS1EQR1TPZ5",
    ///                     Name = "Tea Break",
    ///                     ExpectedDuration = "PT5M",
    ///                     IsPaid = true,
    ///                 },
    ///             },
    ///             Status = TimecardStatus.Closed,
    ///             Version = 1,
    ///             TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
    ///             DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateTimecardResponse> UpdateTimecardAsync(
        UpdateTimecardRequest request,
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
                        "v2/labor/timecards/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                return JsonUtils.Deserialize<UpdateTimecardResponse>(responseBody)!;
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
    /// Deletes a `Timecard`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.DeleteTimecardAsync(new DeleteTimecardRequest { Id = "id" });
    /// </code></example>
    public async Task<DeleteTimecardResponse> DeleteTimecardAsync(
        DeleteTimecardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/labor/timecards/{0}",
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
                return JsonUtils.Deserialize<DeleteTimecardResponse>(responseBody)!;
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
