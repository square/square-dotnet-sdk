using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;
using Square.Loyalty.Accounts;
using Square.Loyalty.Programs;
using Square.Loyalty.Rewards;

namespace Square.Loyalty;

public partial class LoyaltyClient
{
    private RawClient _client;

    internal LoyaltyClient(RawClient client)
    {
        _client = client;
        Accounts = new AccountsClient(_client);
        Programs = new ProgramsClient(_client);
        Rewards = new RewardsClient(_client);
    }

    public AccountsClient Accounts { get; }

    public ProgramsClient Programs { get; }

    public RewardsClient Rewards { get; }

    /// <summary>
    /// Searches for loyalty events.
    ///
    /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a
    /// buyer's loyalty account. Each change in the point balance
    /// (for example, points earned, points redeemed, and points expired) is
    /// recorded in the ledger. Using this endpoint, you can search the ledger for events.
    ///
    /// Search results are sorted by `created_at` in descending order.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.SearchEventsAsync(
    ///     new SearchLoyaltyEventsRequest
    ///     {
    ///         Query = new LoyaltyEventQuery
    ///         {
    ///             Filter = new LoyaltyEventFilter
    ///             {
    ///                 OrderFilter = new LoyaltyEventOrderFilter
    ///                 {
    ///                     OrderId = "PyATxhYLfsMqpVkcKJITPydgEYfZY",
    ///                 },
    ///             },
    ///         },
    ///         Limit = 30,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchLoyaltyEventsResponse> SearchEventsAsync(
        SearchLoyaltyEventsRequest request,
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
                    Path = "v2/loyalty/events/search",
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
                return JsonUtils.Deserialize<SearchLoyaltyEventsResponse>(responseBody)!;
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
