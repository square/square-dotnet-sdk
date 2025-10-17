using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Terminal.Refunds;

public partial class RefundsClient
{
    private RawClient _client;

    internal RefundsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API](api:Refunds).
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Refunds.CreateAsync(
    ///     new CreateTerminalRefundRequest
    ///     {
    ///         IdempotencyKey = "402a640b-b26f-401f-b406-46f839590c04",
    ///         Refund = new TerminalRefund
    ///         {
    ///             PaymentId = "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
    ///             AmountMoney = new Money { Amount = 111, Currency = Currency.Cad },
    ///             Reason = "Returning items",
    ///             DeviceId = "f72dfb8e-4d65-4e56-aade-ec3fb8d33291",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateTerminalRefundResponse> CreateAsync(
        CreateTerminalRefundRequest request,
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
                    Path = "v2/terminals/refunds",
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
                return JsonUtils.Deserialize<CreateTerminalRefundResponse>(responseBody)!;
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
    /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Refunds.SearchAsync(
    ///     new SearchTerminalRefundsRequest
    ///     {
    ///         Query = new TerminalRefundQuery
    ///         {
    ///             Filter = new TerminalRefundQueryFilter { Status = "COMPLETED" },
    ///         },
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchTerminalRefundsResponse> SearchAsync(
        SearchTerminalRefundsRequest request,
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
                    Path = "v2/terminals/refunds/search",
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
                return JsonUtils.Deserialize<SearchTerminalRefundsResponse>(responseBody)!;
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
    /// Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Refunds.GetAsync(
    ///     new Square.Terminal.Refunds.GetRefundsRequest { TerminalRefundId = "terminal_refund_id" }
    /// );
    /// </code></example>
    public async Task<GetTerminalRefundResponse> GetAsync(
        GetRefundsRequest request,
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
                        "v2/terminals/refunds/{0}",
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
                return JsonUtils.Deserialize<GetTerminalRefundResponse>(responseBody)!;
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
    /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
    /// </summary>
    /// <example><code>
    /// await client.Terminal.Refunds.CancelAsync(
    ///     new CancelRefundsRequest { TerminalRefundId = "terminal_refund_id" }
    /// );
    /// </code></example>
    public async Task<CancelTerminalRefundResponse> CancelAsync(
        CancelRefundsRequest request,
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
                        "v2/terminals/refunds/{0}/cancel",
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
                return JsonUtils.Deserialize<CancelTerminalRefundResponse>(responseBody)!;
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
