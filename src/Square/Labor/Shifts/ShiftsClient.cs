using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Labor.Shifts;

public partial class ShiftsClient
{
    private RawClient _client;

    internal ShiftsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a new `Shift`.
    ///
    /// A `Shift` represents a complete workday for a single team member.
    /// You must provide the following values in your request to this
    /// endpoint:
    ///
    /// - `location_id`
    /// - `team_member_id`
    /// - `start_at`
    ///
    /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
    /// - The `status` of the new `Shift` is `OPEN` and the team member has another
    /// shift with an `OPEN` status.
    /// - The `start_at` date is in the future.
    /// - The `start_at` or `end_at` date overlaps another shift for the same team member.
    /// - The `Break` instances are set in the request and a break `start_at`
    /// is before the `Shift.start_at`, a break `end_at` is after
    /// the `Shift.end_at`, or both.
    /// </summary>
    /// <example><code>
    /// await client.Labor.Shifts.CreateAsync(
    ///     new CreateShiftRequest
    ///     {
    ///         IdempotencyKey = "HIDSNG5KS478L",
    ///         Shift = new Shift
    ///         {
    ///             LocationId = "PAA1RJZZKXBFG",
    ///             StartAt = "2019-01-25T03:11:00-05:00",
    ///             EndAt = "2019-01-25T13:11:00-05:00",
    ///             Wage = new ShiftWage
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
    public async Task<CreateShiftResponse> CreateAsync(
        CreateShiftRequest request,
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
                    Path = "v2/labor/shifts",
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
                return JsonUtils.Deserialize<CreateShiftResponse>(responseBody)!;
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
    /// Returns a paginated list of `Shift` records for a business.
    /// The list to be returned can be filtered by:
    /// - Location IDs
    /// - Team member IDs
    /// - Shift status (`OPEN` or `CLOSED`)
    /// - Shift start
    /// - Shift end
    /// - Workday details
    ///
    /// The list can be sorted by:
    /// - `START_AT`
    /// - `END_AT`
    /// - `CREATED_AT`
    /// - `UPDATED_AT`
    /// </summary>
    /// <example><code>
    /// await client.Labor.Shifts.SearchAsync(
    ///     new SearchShiftsRequest
    ///     {
    ///         Query = new ShiftQuery
    ///         {
    ///             Filter = new ShiftFilter
    ///             {
    ///                 Workday = new ShiftWorkday
    ///                 {
    ///                     DateRange = new DateRange { StartDate = "2019-01-20", EndDate = "2019-02-03" },
    ///                     MatchShiftsBy = ShiftWorkdayMatcher.StartAt,
    ///                     DefaultTimezone = "America/Los_Angeles",
    ///                 },
    ///             },
    ///         },
    ///         Limit = 100,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchShiftsResponse> SearchAsync(
        SearchShiftsRequest request,
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
                    Path = "v2/labor/shifts/search",
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
                return JsonUtils.Deserialize<SearchShiftsResponse>(responseBody)!;
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
    /// Returns a single `Shift` specified by `id`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.Shifts.GetAsync(new Square.Labor.Shifts.GetShiftsRequest { Id = "id" });
    /// </code></example>
    public async Task<GetShiftResponse> GetAsync(
        GetShiftsRequest request,
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
                        "v2/labor/shifts/{0}",
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
                return JsonUtils.Deserialize<GetShiftResponse>(responseBody)!;
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
    /// Updates an existing `Shift`.
    ///
    /// When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have
    /// the `end_at` property set to a valid RFC-3339 datetime string.
    ///
    /// When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`
    /// set on each `Break`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.Shifts.UpdateAsync(
    ///     new UpdateShiftRequest
    ///     {
    ///         Id = "id",
    ///         Shift = new Shift
    ///         {
    ///             LocationId = "PAA1RJZZKXBFG",
    ///             StartAt = "2019-01-25T03:11:00-05:00",
    ///             EndAt = "2019-01-25T13:11:00-05:00",
    ///             Wage = new ShiftWage
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
    ///             Version = 1,
    ///             TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
    ///             DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateShiftResponse> UpdateAsync(
        UpdateShiftRequest request,
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
                        "v2/labor/shifts/{0}",
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
                return JsonUtils.Deserialize<UpdateShiftResponse>(responseBody)!;
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
    /// Deletes a `Shift`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.Shifts.DeleteAsync(new DeleteShiftsRequest { Id = "id" });
    /// </code></example>
    public async Task<DeleteShiftResponse> DeleteAsync(
        DeleteShiftsRequest request,
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
                        "v2/labor/shifts/{0}",
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
                return JsonUtils.Deserialize<DeleteShiftResponse>(responseBody)!;
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
