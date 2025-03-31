using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.CashDrawers.Shifts;

public partial class ShiftsClient
{
    private RawClient _client;

    internal ShiftsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Provides the details for all of the cash drawer shifts for a location
    /// in a date range.
    /// </summary>
    private async Task<ListCashDrawerShiftsResponse> ListInternalAsync(
        ListShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["location_id"] = request.LocationId;
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
        }
        if (request.BeginTime != null)
        {
            _query["begin_time"] = request.BeginTime;
        }
        if (request.EndTime != null)
        {
            _query["end_time"] = request.EndTime;
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
                    Path = "v2/cash-drawers/shifts",
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
                return JsonUtils.Deserialize<ListCashDrawerShiftsResponse>(responseBody)!;
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
    /// Provides a paginated list of events for a single cash drawer shift.
    /// </summary>
    private async Task<ListCashDrawerShiftEventsResponse> ListEventsInternalAsync(
        ListEventsShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["location_id"] = request.LocationId;
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
                    Path = string.Format(
                        "v2/cash-drawers/shifts/{0}/events",
                        ValueConvert.ToPathParameterString(request.ShiftId)
                    ),
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
                return JsonUtils.Deserialize<ListCashDrawerShiftEventsResponse>(responseBody)!;
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
    /// Provides the details for all of the cash drawer shifts for a location
    /// in a date range.
    /// </summary>
    /// <example><code>
    /// await client.CashDrawers.Shifts.ListAsync(new ListShiftsRequest { LocationId = "location_id" });
    /// </code></example>
    public async Task<Pager<CashDrawerShiftSummary>> ListAsync(
        ListShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListShiftsRequest,
            RequestOptions?,
            ListCashDrawerShiftsResponse,
            string?,
            CashDrawerShiftSummary
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
                response => response?.CashDrawerShifts?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Provides the summary details for a single cash drawer shift. See
    /// [ListCashDrawerShiftEvents](api-endpoint:CashDrawers-ListCashDrawerShiftEvents) for a list of cash drawer shift events.
    /// </summary>
    /// <example><code>
    /// await client.CashDrawers.Shifts.GetAsync(
    ///     new GetShiftsRequest { ShiftId = "shift_id", LocationId = "location_id" }
    /// );
    /// </code></example>
    public async Task<GetCashDrawerShiftResponse> GetAsync(
        GetShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["location_id"] = request.LocationId;
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/cash-drawers/shifts/{0}",
                        ValueConvert.ToPathParameterString(request.ShiftId)
                    ),
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
                return JsonUtils.Deserialize<GetCashDrawerShiftResponse>(responseBody)!;
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
    /// Provides a paginated list of events for a single cash drawer shift.
    /// </summary>
    /// <example><code>
    /// await client.CashDrawers.Shifts.ListEventsAsync(
    ///     new ListEventsShiftsRequest { ShiftId = "shift_id", LocationId = "location_id" }
    /// );
    /// </code></example>
    public async Task<Pager<CashDrawerShiftEvent>> ListEventsAsync(
        ListEventsShiftsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListEventsShiftsRequest,
            RequestOptions?,
            ListCashDrawerShiftEventsResponse,
            string?,
            CashDrawerShiftEvent
        >
            .CreateInstanceAsync(
                request,
                options,
                ListEventsInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.CashDrawerShiftEvents?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
