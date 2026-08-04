using System.Text.Json;
using Square;
using Square.Core;
using Square.Terminal.Actions;
using Square.Terminal.Checkouts;

namespace Square.Terminal;

public partial class TerminalClient : ITerminalClient
{
    private RawClient _client;

    internal TerminalClient(RawClient client)
    {
        _client = client;
        Actions = new ActionsClient(_client);
        Checkouts = new CheckoutsClient(_client);
        Refunds = new Square.Terminal.Refunds.RefundsClient(_client);
    }

    public ActionsClient Actions { get; }

    public CheckoutsClient Checkouts { get; }

    public Square.Terminal.Refunds.RefundsClient Refunds { get; }

    /// <summary>
    /// Dismisses a Terminal action request if the status and type of the request permits it.
    ///
    /// See [Link and Dismiss Actions](https://developer.squareup.com/docs/terminal-api/advanced-features/custom-workflows/link-and-dismiss-actions) for more details.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.DismissTerminalActionAsync(
    ///     new DismissTerminalActionRequest { ActionId = "action_id" }
    /// );
    /// </code></example>
    public async Task<DismissTerminalActionResponse> DismissTerminalActionAsync(
        DismissTerminalActionRequest request,
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
                        "v2/terminals/actions/{0}/dismiss",
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
                return JsonUtils.Deserialize<DismissTerminalActionResponse>(responseBody)!;
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
    /// Dismisses a Terminal checkout request if the status and type of the request permits it.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.DismissTerminalCheckoutAsync(
    ///     new DismissTerminalCheckoutRequest { CheckoutId = "checkout_id" }
    /// );
    /// </code></example>
    public async Task<DismissTerminalCheckoutResponse> DismissTerminalCheckoutAsync(
        DismissTerminalCheckoutRequest request,
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
                        "v2/terminals/checkouts/{0}/dismiss",
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
                return JsonUtils.Deserialize<DismissTerminalCheckoutResponse>(responseBody)!;
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
    /// Dismisses a Terminal refund request if the status and type of the request permits it.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.DismissTerminalRefundAsync(
    ///     new DismissTerminalRefundRequest { TerminalRefundId = "terminal_refund_id" }
    /// );
    /// </code></example>
    public async Task<DismissTerminalRefundResponse> DismissTerminalRefundAsync(
        DismissTerminalRefundRequest request,
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
                        "v2/terminals/refunds/{0}/dismiss",
                        ValueConvert.ToPathParameterString(request.TerminalRefundId)
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
                return JsonUtils.Deserialize<DismissTerminalRefundResponse>(responseBody)!;
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
