using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor.EmployeeWages;

public partial class EmployeeWagesClient : IEmployeeWagesClient
{
    private RawClient _client;

    internal EmployeeWagesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a paginated list of `EmployeeWage` instances for a business.
    /// </summary>
    private async Task<ListEmployeeWagesResponse> ListInternalAsync(
        ListEmployeeWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.EmployeeId != null)
        {
            _query["employee_id"] = request.EmployeeId;
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
                    Path = "v2/labor/employee-wages",
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
                return JsonUtils.Deserialize<ListEmployeeWagesResponse>(responseBody)!;
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
    /// Returns a paginated list of `EmployeeWage` instances for a business.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.EmployeeWages.ListAsync(
    ///     new ListEmployeeWagesRequest
    ///     {
    ///         EmployeeId = "employee_id",
    ///         Limit = 1,
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<EmployeeWage>> ListAsync(
        ListEmployeeWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListEmployeeWagesRequest,
            RequestOptions?,
            ListEmployeeWagesResponse,
            string?,
            EmployeeWage
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
                response => response.EmployeeWages?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns a single `EmployeeWage` specified by `id`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.EmployeeWages.GetAsync(new GetEmployeeWagesRequest { Id = "id" });
    /// </code></example>
    public async Task<GetEmployeeWageResponse> GetAsync(
        GetEmployeeWagesRequest request,
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
                        "v2/labor/employee-wages/{0}",
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
                return JsonUtils.Deserialize<GetEmployeeWageResponse>(responseBody)!;
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
