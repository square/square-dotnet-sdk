using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Default;

public partial class PayoutsClient : IPayoutsClient
{
    private RawClient _client;

    internal PayoutsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of all payouts for the default location.
    /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    private async Task<ListPayoutsResponse> ListInternalAsync(
        ListPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        if (request.Status != null)
        {
            _query["status"] = request.Status.Value.ToString();
        }
        if (request.BeginTime != null)
        {
            _query["begin_time"] = request.BeginTime;
        }
        if (request.EndTime != null)
        {
            _query["end_time"] = request.EndTime;
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/payouts",
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
                return JsonUtils.Deserialize<ListPayoutsResponse>(responseBody)!;
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
    /// Retrieves a list of all payout entries for a specific payout.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    private async Task<ListPayoutEntriesResponse> ListEntriesInternalAsync(
        ListEntriesPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/payouts/{0}/payout-entries",
                        ValueConvert.ToPathParameterString(request.PayoutId)
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
                return JsonUtils.Deserialize<ListPayoutEntriesResponse>(responseBody)!;
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
    /// Retrieves a list of all payouts for the default location.
    /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payouts.ListAsync(
    ///     new ListPayoutsRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Status = PayoutStatus.Sent,
    ///         BeginTime = "begin_time",
    ///         EndTime = "end_time",
    ///         SortOrder = SortOrder.Desc,
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Payout>> ListAsync(
        ListPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListPayoutsRequest,
            RequestOptions?,
            ListPayoutsResponse,
            string?,
            Payout
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
                response => response.Payouts?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves details of a specific payout identified by a payout ID.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payouts.GetAsync(new GetPayoutsRequest { PayoutId = "payout_id" });
    /// </code></example>
    public async Task<GetPayoutResponse> GetAsync(
        GetPayoutsRequest request,
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
                        "v2/payouts/{0}",
                        ValueConvert.ToPathParameterString(request.PayoutId)
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
                return JsonUtils.Deserialize<GetPayoutResponse>(responseBody)!;
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
    /// Retrieves a list of all payout entries for a specific payout.
    /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payouts.ListEntriesAsync(
    ///     new ListEntriesPayoutsRequest
    ///     {
    ///         PayoutId = "payout_id",
    ///         SortOrder = SortOrder.Desc,
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<PayoutEntry>> ListEntriesAsync(
        ListEntriesPayoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListEntriesPayoutsRequest,
            RequestOptions?,
            ListPayoutEntriesResponse,
            string?,
            PayoutEntry
        >
            .CreateInstanceAsync(
                request,
                options,
                ListEntriesInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.PayoutEntries?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
