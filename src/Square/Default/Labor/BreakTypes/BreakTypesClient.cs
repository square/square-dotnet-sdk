using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

public partial class BreakTypesClient : IBreakTypesClient
{
    private RawClient _client;

    internal BreakTypesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a paginated list of `BreakType` instances for a business.
    /// </summary>
    private async Task<ListBreakTypesResponse> ListInternalAsync(
        ListBreakTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
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
                    Path = "v2/labor/break-types",
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
                return JsonUtils.Deserialize<ListBreakTypesResponse>(responseBody)!;
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
    /// Returns a paginated list of `BreakType` instances for a business.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.BreakTypes.ListAsync(
    ///     new ListBreakTypesRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Limit = 1,
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<BreakType>> ListAsync(
        ListBreakTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListBreakTypesRequest,
            RequestOptions?,
            ListBreakTypesResponse,
            string?,
            BreakType
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
                response => response.BreakTypes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a new `BreakType`.
    ///
    /// A `BreakType` is a template for creating `Break` objects.
    /// You must provide the following values in your request to this
    /// endpoint:
    ///
    /// - `location_id`
    /// - `break_name`
    /// - `expected_duration`
    /// - `is_paid`
    ///
    /// You can only have three `BreakType` instances per location. If you attempt to add a fourth
    /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
    /// is returned.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.BreakTypes.CreateAsync(
    ///     new CreateBreakTypeRequest
    ///     {
    ///         IdempotencyKey = "PAD3NG5KSN2GL",
    ///         BreakType = new BreakType
    ///         {
    ///             LocationId = "CGJN03P1D08GF",
    ///             BreakName = "Lunch Break",
    ///             ExpectedDuration = "PT30M",
    ///             IsPaid = true,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateBreakTypeResponse> CreateAsync(
        CreateBreakTypeRequest request,
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
                    Path = "v2/labor/break-types",
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
                return JsonUtils.Deserialize<CreateBreakTypeResponse>(responseBody)!;
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
    /// Returns a single `BreakType` specified by `id`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.BreakTypes.GetAsync(new GetBreakTypesRequest { Id = "id" });
    /// </code></example>
    public async Task<GetBreakTypeResponse> GetAsync(
        GetBreakTypesRequest request,
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
                        "v2/labor/break-types/{0}",
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
                return JsonUtils.Deserialize<GetBreakTypeResponse>(responseBody)!;
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
    /// Updates an existing `BreakType`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.BreakTypes.UpdateAsync(
    ///     new UpdateBreakTypeRequest
    ///     {
    ///         Id = "id",
    ///         BreakType = new BreakType
    ///         {
    ///             LocationId = "26M7H24AZ9N6R",
    ///             BreakName = "Lunch",
    ///             ExpectedDuration = "PT50M",
    ///             IsPaid = true,
    ///             Version = 1,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateBreakTypeResponse> UpdateAsync(
        UpdateBreakTypeRequest request,
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
                        "v2/labor/break-types/{0}",
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
                return JsonUtils.Deserialize<UpdateBreakTypeResponse>(responseBody)!;
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
    /// Deletes an existing `BreakType`.
    ///
    /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Labor.BreakTypes.DeleteAsync(new DeleteBreakTypesRequest { Id = "id" });
    /// </code></example>
    public async Task<DeleteBreakTypeResponse> DeleteAsync(
        DeleteBreakTypesRequest request,
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
                        "v2/labor/break-types/{0}",
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
                return JsonUtils.Deserialize<DeleteBreakTypeResponse>(responseBody)!;
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
