using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Devices;

public partial class CodesClient : ICodesClient
{
    private RawClient _client;

    internal CodesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists all DeviceCodes associated with the merchant.
    /// </summary>
    private async Task<ListDeviceCodesResponse> ListInternalAsync(
        ListCodesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        if (request.ProductType != null)
        {
            _query["product_type"] = request.ProductType.ToString();
        }
        if (request.Status != null)
        {
            _query["status"] = request.Status.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/devices/codes",
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
                return JsonUtils.Deserialize<ListDeviceCodesResponse>(responseBody)!;
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
    /// Lists all DeviceCodes associated with the merchant.
    /// </summary>
    /// <example><code>
    /// await client.Default.Devices.Codes.ListAsync(
    ///     new ListCodesRequest
    ///     {
    ///         Cursor = "cursor",
    ///         LocationId = "location_id",
    ///         ProductType = "TERMINAL_API",
    ///         Status = DeviceCodeStatus.Unknown,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<DeviceCode>> ListAsync(
        ListCodesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCodesRequest,
            RequestOptions?,
            ListDeviceCodesResponse,
            string?,
            DeviceCode
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
                response => response.DeviceCodes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected
    /// terminal mode.
    /// </summary>
    /// <example><code>
    /// await client.Default.Devices.Codes.CreateAsync(
    ///     new CreateDeviceCodeRequest
    ///     {
    ///         IdempotencyKey = "01bb00a6-0c86-4770-94ed-f5fca973cd56",
    ///         DeviceCode = new DeviceCode
    ///         {
    ///             Name = "Counter 1",
    ///             ProductType = "TERMINAL_API",
    ///             LocationId = "B5E4484SHHNYH",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateDeviceCodeResponse> CreateAsync(
        CreateDeviceCodeRequest request,
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
                    Path = "v2/devices/codes",
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
                return JsonUtils.Deserialize<CreateDeviceCodeResponse>(responseBody)!;
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
    /// Retrieves DeviceCode with the associated ID.
    /// </summary>
    /// <example><code>
    /// await client.Default.Devices.Codes.GetAsync(new GetCodesRequest { Id = "id" });
    /// </code></example>
    public async Task<GetDeviceCodeResponse> GetAsync(
        GetCodesRequest request,
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
                        "v2/devices/codes/{0}",
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
                return JsonUtils.Deserialize<GetDeviceCodeResponse>(responseBody)!;
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
