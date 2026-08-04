using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Terminal.Actions;

public partial class ActionsClient : IActionsClient
{
    private RawClient _client;

    internal ActionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a Terminal action request and sends it to the specified device.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Actions.CreateAsync(
    ///     new CreateTerminalActionRequest
    ///     {
    ///         IdempotencyKey = "thahn-70e75c10-47f7-4ab6-88cc-aaa4076d065e",
    ///         Action = new TerminalAction
    ///         {
    ///             DeviceId = "{{DEVICE_ID}}",
    ///             DeadlineDuration = "PT5M",
    ///             Type = TerminalActionActionType.SaveCard,
    ///             SaveCardOptions = new SaveCardOptions
    ///             {
    ///                 CustomerId = "{{CUSTOMER_ID}}",
    ///                 ReferenceId = "user-id-1",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateTerminalActionResponse> CreateAsync(
        CreateTerminalActionRequest request,
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
                    Path = "v2/terminals/actions",
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
                return JsonUtils.Deserialize<CreateTerminalActionResponse>(responseBody)!;
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
    /// Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Actions.SearchAsync(
    ///     new SearchTerminalActionsRequest
    ///     {
    ///         Query = new TerminalActionQuery
    ///         {
    ///             Filter = new TerminalActionQueryFilter
    ///             {
    ///                 CreatedAt = new TimeRange { StartAt = "2022-04-01T00:00:00.000Z" },
    ///             },
    ///             Sort = new TerminalActionQuerySort { SortOrder = SortOrder.Desc },
    ///         },
    ///         Limit = 2,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchTerminalActionsResponse> SearchAsync(
        SearchTerminalActionsRequest request,
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
                    Path = "v2/terminals/actions/search",
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
                return JsonUtils.Deserialize<SearchTerminalActionsResponse>(responseBody)!;
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
    /// Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Actions.GetAsync(new GetActionsRequest { ActionId = "action_id" });
    /// </code></example>
    public async Task<GetTerminalActionResponse> GetAsync(
        GetActionsRequest request,
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
                        "v2/terminals/actions/{0}",
                        ValueConvert.ToPathParameterString(request.ActionId)
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
                return JsonUtils.Deserialize<GetTerminalActionResponse>(responseBody)!;
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
    /// Cancels a Terminal action request if the status of the request permits it.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Actions.CancelAsync(new CancelActionsRequest { ActionId = "action_id" });
    /// </code></example>
    public async Task<CancelTerminalActionResponse> CancelAsync(
        CancelActionsRequest request,
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
                    Path = string.Format(
                        "v2/terminals/actions/{0}/cancel",
                        ValueConvert.ToPathParameterString(request.ActionId)
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
                return JsonUtils.Deserialize<CancelTerminalActionResponse>(responseBody)!;
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
