using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.V1Transactions;

public partial class V1TransactionsClient
{
    private RawClient _client;

    internal V1TransactionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Provides summary information for a merchant's online store orders.
    /// </summary>
    /// <example><code>
    /// await client.V1Transactions.V1ListOrdersAsync(
    ///     new V1ListOrdersRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Order = SortOrder.Desc,
    ///         Limit = 1,
    ///         BatchToken = "batch_token",
    ///     }
    /// );
    /// </code></example>
    public async Task<IEnumerable<V1Order>> V1ListOrdersAsync(
        V1ListOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Order != null)
        {
            _query["order"] = request.Order.Value.ToString();
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.BatchToken != null)
        {
            _query["batch_token"] = request.BatchToken;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v1/{0}/orders",
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
                return JsonUtils.Deserialize<IEnumerable<V1Order>>(responseBody)!;
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
    /// Provides comprehensive information for a single online store order, including the order's history.
    /// </summary>
    /// <example><code>
    /// await client.V1Transactions.V1RetrieveOrderAsync(
    ///     new V1RetrieveOrderRequest { LocationId = "location_id", OrderId = "order_id" }
    /// );
    /// </code></example>
    public async Task<V1Order> V1RetrieveOrderAsync(
        V1RetrieveOrderRequest request,
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
                        "v1/{0}/orders/{1}",
                        ValueConvert.ToPathParameterString(request.LocationId),
                        ValueConvert.ToPathParameterString(request.OrderId)
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
                return JsonUtils.Deserialize<V1Order>(responseBody)!;
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
    /// Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:
    /// </summary>
    /// <example><code>
    /// await client.V1Transactions.V1UpdateOrderAsync(
    ///     new V1UpdateOrderRequest
    ///     {
    ///         LocationId = "location_id",
    ///         OrderId = "order_id",
    ///         Action = V1UpdateOrderRequestAction.Complete,
    ///     }
    /// );
    /// </code></example>
    public async Task<V1Order> V1UpdateOrderAsync(
        V1UpdateOrderRequest request,
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
                        "v1/{0}/orders/{1}",
                        ValueConvert.ToPathParameterString(request.LocationId),
                        ValueConvert.ToPathParameterString(request.OrderId)
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
                return JsonUtils.Deserialize<V1Order>(responseBody)!;
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
