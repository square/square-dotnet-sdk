using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Labor.WorkweekConfigs;

public partial class WorkweekConfigsClient
{
    private RawClient _client;

    internal WorkweekConfigsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of `WorkweekConfig` instances for a business.
    /// </summary>
    private async Task<ListWorkweekConfigsResponse> ListInternalAsync(
        ListWorkweekConfigsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
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
                    Path = "v2/labor/workweek-configs",
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
                return JsonUtils.Deserialize<ListWorkweekConfigsResponse>(responseBody)!;
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
    /// Returns a list of `WorkweekConfig` instances for a business.
    /// </summary>
    /// <example><code>
    /// await client.Labor.WorkweekConfigs.ListAsync(
    ///     new ListWorkweekConfigsRequest { Limit = 1, Cursor = "cursor" }
    /// );
    /// </code></example>
    public async Task<Pager<WorkweekConfig>> ListAsync(
        ListWorkweekConfigsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListWorkweekConfigsRequest,
            RequestOptions?,
            ListWorkweekConfigsResponse,
            string?,
            WorkweekConfig
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
                response => response?.WorkweekConfigs?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Updates a `WorkweekConfig`.
    /// </summary>
    /// <example><code>
    /// await client.Labor.WorkweekConfigs.GetAsync(
    ///     new UpdateWorkweekConfigRequest
    ///     {
    ///         Id = "id",
    ///         WorkweekConfig = new WorkweekConfig
    ///         {
    ///             StartOfWeek = Weekday.Mon,
    ///             StartOfDayLocalTime = "10:00",
    ///             Version = 10,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateWorkweekConfigResponse> GetAsync(
        UpdateWorkweekConfigRequest request,
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
                        "v2/labor/workweek-configs/{0}",
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
                return JsonUtils.Deserialize<UpdateWorkweekConfigResponse>(responseBody)!;
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
