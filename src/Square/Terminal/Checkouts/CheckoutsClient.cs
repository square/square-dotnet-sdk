using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Terminal.Checkouts;

public partial class CheckoutsClient : ICheckoutsClient
{
    private RawClient _client;

    internal CheckoutsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a Terminal checkout request and sends it to the specified device to take a payment
    /// for the requested amount.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Checkouts.CreateAsync(
    ///     new CreateTerminalCheckoutRequest
    ///     {
    ///         IdempotencyKey = "28a0c3bc-7839-11ea-bc55-0242ac130003",
    ///         Checkout = new TerminalCheckout
    ///         {
    ///             AmountMoney = new Money { Amount = 2610, Currency = Currency.Usd },
    ///             ReferenceId = "id11572",
    ///             Note = "A brief note",
    ///             DeviceOptions = new DeviceCheckoutOptions
    ///             {
    ///                 DeviceId = "dbb5d83a-7838-11ea-bc55-0242ac130003",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateTerminalCheckoutResponse> CreateAsync(
        CreateTerminalCheckoutRequest request,
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
                    Path = "v2/terminals/checkouts",
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
                return JsonUtils.Deserialize<CreateTerminalCheckoutResponse>(responseBody)!;
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
    /// Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Checkouts.SearchAsync(
    ///     new SearchTerminalCheckoutsRequest
    ///     {
    ///         Query = new TerminalCheckoutQuery
    ///         {
    ///             Filter = new TerminalCheckoutQueryFilter { Status = "COMPLETED" },
    ///         },
    ///         Limit = 2,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchTerminalCheckoutsResponse> SearchAsync(
        SearchTerminalCheckoutsRequest request,
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
                    Path = "v2/terminals/checkouts/search",
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
                return JsonUtils.Deserialize<SearchTerminalCheckoutsResponse>(responseBody)!;
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
    /// Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Checkouts.GetAsync(new GetCheckoutsRequest { CheckoutId = "checkout_id" });
    /// </code></example>
    public async Task<GetTerminalCheckoutResponse> GetAsync(
        GetCheckoutsRequest request,
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
                        "v2/terminals/checkouts/{0}",
                        ValueConvert.ToPathParameterString(request.CheckoutId)
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
                return JsonUtils.Deserialize<GetTerminalCheckoutResponse>(responseBody)!;
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
    /// Cancels a Terminal checkout request if the status of the request permits it.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Checkouts.CancelAsync(
    ///     new CancelCheckoutsRequest { CheckoutId = "checkout_id" }
    /// );
    /// </code></example>
    public async Task<CancelTerminalCheckoutResponse> CancelAsync(
        CancelCheckoutsRequest request,
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
                        "v2/terminals/checkouts/{0}/cancel",
                        ValueConvert.ToPathParameterString(request.CheckoutId)
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
                return JsonUtils.Deserialize<CancelTerminalCheckoutResponse>(responseBody)!;
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
