using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;
using Square.Devices.Codes;

namespace Square.Devices;

public partial class DevicesClient
{
    private RawClient _client;

    internal DevicesClient(RawClient client)
    {
        _client = client;
        Codes = new CodesClient(_client);
    }

    public CodesClient Codes { get; }

    /// <summary>
    /// List devices associated with the merchant. Currently, only Terminal API
    /// devices are supported.
    /// </summary>
    private async Task<ListDevicesResponse> ListInternalAsync(
        ListDevicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/devices",
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
                return JsonUtils.Deserialize<ListDevicesResponse>(responseBody)!;
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
    /// List devices associated with the merchant. Currently, only Terminal API
    /// devices are supported.
    /// </summary>
    /// <example><code>
    /// await client.Devices.ListAsync(
    ///     new ListDevicesRequest
    ///     {
    ///         Cursor = "cursor",
    ///         SortOrder = SortOrder.Desc,
    ///         Limit = 1,
    ///         LocationId = "location_id",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Device>> ListAsync(
        ListDevicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListDevicesRequest,
            RequestOptions?,
            ListDevicesResponse,
            string?,
            Device
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
                response => response?.Devices?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves Device with the associated `device_id`.
    /// </summary>
    /// <example><code>
    /// await client.Devices.GetAsync(new GetDevicesRequest { DeviceId = "device_id" });
    /// </code></example>
    public async Task<GetDeviceResponse> GetAsync(
        GetDevicesRequest request,
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
                        "v2/devices/{0}",
                        ValueConvert.ToPathParameterString(request.DeviceId)
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
                return JsonUtils.Deserialize<GetDeviceResponse>(responseBody)!;
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
