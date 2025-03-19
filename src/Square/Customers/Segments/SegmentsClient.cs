using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Customers.Segments;

public partial class SegmentsClient
{
    private RawClient _client;

    internal SegmentsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves the list of customer segments of a business.
    /// </summary>
    private async Task<ListCustomerSegmentsResponse> ListInternalAsync(
        ListSegmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
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
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/customers/segments",
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
                return JsonUtils.Deserialize<ListCustomerSegmentsResponse>(responseBody)!;
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
    /// Retrieves the list of customer segments of a business.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Segments.ListAsync(new ListSegmentsRequest());
    /// </code></example>
    public async Task<Pager<CustomerSegment>> ListAsync(
        ListSegmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListSegmentsRequest,
            RequestOptions?,
            ListCustomerSegmentsResponse,
            string?,
            CustomerSegment
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
                response => response?.Segments?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a specific customer segment as identified by the `segment_id` value.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Segments.GetAsync(new GetSegmentsRequest { SegmentId = "segment_id" });
    /// </code></example>
    public async Task<GetCustomerSegmentResponse> GetAsync(
        GetSegmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/customers/segments/{0}",
                        ValueConvert.ToPathParameterString(request.SegmentId)
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
                return JsonUtils.Deserialize<GetCustomerSegmentResponse>(responseBody)!;
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
