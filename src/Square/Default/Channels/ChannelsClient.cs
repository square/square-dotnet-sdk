using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Channels;

public partial class ChannelsClient : IChannelsClient
{
    private RawClient _client;

    internal ChannelsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<ListChannelsResponse> ListInternalAsync(
        ListChannelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ReferenceType != null)
        {
            _query["reference_type"] = request.ReferenceType.Value.ToString();
        }
        if (request.ReferenceId != null)
        {
            _query["reference_id"] = request.ReferenceId;
        }
        if (request.Status != null)
        {
            _query["status"] = request.Status.Value.ToString();
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
                    Path = "v2/channels",
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
                return JsonUtils.Deserialize<ListChannelsResponse>(responseBody)!;
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

    /// <example><code>
    /// await client.Default.Channels.ListAsync(
    ///     new ListChannelsRequest
    ///     {
    ///         ReferenceType = ReferenceType.UnknownType,
    ///         ReferenceId = "reference_id",
    ///         Status = ChannelStatus.Active,
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Channel>> ListAsync(
        ListChannelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListChannelsRequest,
            RequestOptions?,
            ListChannelsResponse,
            string?,
            Channel
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
                response => response.Channels?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <example><code>
    /// await client.Default.Channels.BulkRetrieveAsync(
    ///     new BulkRetrieveChannelsRequest
    ///     {
    ///         ChannelIds = new List&lt;string&gt;() { "CH_9C03D0B59", "CH_6X139B5MN", "NOT_EXISTING" },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkRetrieveChannelsResponse> BulkRetrieveAsync(
        BulkRetrieveChannelsRequest request,
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
                    Path = "v2/channels/bulk-retrieve",
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
                return JsonUtils.Deserialize<BulkRetrieveChannelsResponse>(responseBody)!;
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

    /// <example><code>
    /// await client.Default.Channels.GetAsync(new GetChannelsRequest { ChannelId = "channel_id" });
    /// </code></example>
    public async Task<RetrieveChannelResponse> GetAsync(
        GetChannelsRequest request,
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
                        "v2/channels/{0}",
                        ValueConvert.ToPathParameterString(request.ChannelId)
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
                return JsonUtils.Deserialize<RetrieveChannelResponse>(responseBody)!;
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
