using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Bookings.LocationProfiles;

public partial class LocationProfilesClient : ILocationProfilesClient
{
    private RawClient _client;

    internal LocationProfilesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists location booking profiles of a seller.
    /// </summary>
    private async Task<ListLocationBookingProfilesResponse> ListInternalAsync(
        ListLocationProfilesRequest request,
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
                    Path = "v2/bookings/location-booking-profiles",
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
                return JsonUtils.Deserialize<ListLocationBookingProfilesResponse>(responseBody)!;
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
    /// Lists location booking profiles of a seller.
    /// </summary>
    /// <example><code>
    /// await client.Default.Bookings.LocationProfiles.ListAsync(
    ///     new ListLocationProfilesRequest { Limit = 1, Cursor = "cursor" }
    /// );
    /// </code></example>
    public async Task<Pager<LocationBookingProfile>> ListAsync(
        ListLocationProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListLocationProfilesRequest,
            RequestOptions?,
            ListLocationBookingProfilesResponse,
            string?,
            LocationBookingProfile
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
                response => response.LocationBookingProfiles?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
