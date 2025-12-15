using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Locations.Transactions;

public partial class TransactionsClient
{
    private RawClient _client;

    internal TransactionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists transactions for a particular location.
    ///
    /// Transactions include payment information from sales and exchanges and refund
    /// information from returns and exchanges.
    ///
    /// Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50
    /// </summary>
    /// <example><code>
    /// await client.Locations.Transactions.ListAsync(
    ///     new ListTransactionsRequest
    ///     {
    ///         LocationId = "location_id",
    ///         BeginTime = "begin_time",
    ///         EndTime = "end_time",
    ///         SortOrder = SortOrder.Desc,
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<ListTransactionsResponse> ListAsync(
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.BeginTime != null)
        {
            _query["begin_time"] = request.BeginTime;
        }
        if (request.EndTime != null)
        {
            _query["end_time"] = request.EndTime;
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
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
                    Path = string.Format(
                        "v2/locations/{0}/transactions",
                        ValueConvert.ToPathParameterString(request.LocationId)
                    ),
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
                return JsonUtils.Deserialize<ListTransactionsResponse>(responseBody)!;
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
    /// Retrieves details for a single transaction.
    /// </summary>
    /// <example><code>
    /// await client.Locations.Transactions.GetAsync(
    ///     new GetTransactionsRequest { LocationId = "location_id", TransactionId = "transaction_id" }
    /// );
    /// </code></example>
    public async Task<GetTransactionResponse> GetAsync(
        GetTransactionsRequest request,
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
                        "v2/locations/{0}/transactions/{1}",
                        ValueConvert.ToPathParameterString(request.LocationId),
                        ValueConvert.ToPathParameterString(request.TransactionId)
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
                return JsonUtils.Deserialize<GetTransactionResponse>(responseBody)!;
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
    /// Captures a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
    /// endpoint with a `delay_capture` value of `true`.
    ///
    ///
    /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
    /// for more information.
    /// </summary>
    /// <example><code>
    /// await client.Locations.Transactions.CaptureAsync(
    ///     new CaptureTransactionsRequest { LocationId = "location_id", TransactionId = "transaction_id" }
    /// );
    /// </code></example>
    public async Task<CaptureTransactionResponse> CaptureAsync(
        CaptureTransactionsRequest request,
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
                        "v2/locations/{0}/transactions/{1}/capture",
                        ValueConvert.ToPathParameterString(request.LocationId),
                        ValueConvert.ToPathParameterString(request.TransactionId)
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
                return JsonUtils.Deserialize<CaptureTransactionResponse>(responseBody)!;
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
    /// Cancels a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
    /// endpoint with a `delay_capture` value of `true`.
    ///
    ///
    /// See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
    /// for more information.
    /// </summary>
    /// <example><code>
    /// await client.Locations.Transactions.VoidAsync(
    ///     new VoidTransactionsRequest { LocationId = "location_id", TransactionId = "transaction_id" }
    /// );
    /// </code></example>
    public async Task<VoidTransactionResponse> VoidAsync(
        VoidTransactionsRequest request,
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
                        "v2/locations/{0}/transactions/{1}/void",
                        ValueConvert.ToPathParameterString(request.LocationId),
                        ValueConvert.ToPathParameterString(request.TransactionId)
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
                return JsonUtils.Deserialize<VoidTransactionResponse>(responseBody)!;
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
