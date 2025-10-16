using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Loyalty.Rewards;

public partial class RewardsClient
{
    private RawClient _client;

    internal RewardsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts.
    /// If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.
    ///
    /// If you know a reward ID, use the
    /// [RetrieveLoyaltyReward](api-endpoint:Loyalty-RetrieveLoyaltyReward) endpoint.
    ///
    /// Search results are sorted by `updated_at` in descending order.
    /// </summary>
    private async Task<SearchLoyaltyRewardsResponse> SearchInternalAsync(
        SearchLoyaltyRewardsRequest request,
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
                    Path = "v2/loyalty/rewards/search",
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
                return JsonUtils.Deserialize<SearchLoyaltyRewardsResponse>(responseBody)!;
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
    /// Creates a loyalty reward. In the process, the endpoint does following:
    ///
    /// - Uses the `reward_tier_id` in the request to determine the number of points
    /// to lock for this reward.
    /// - If the request includes `order_id`, it adds the reward and related discount to the order.
    ///
    /// After a reward is created, the points are locked and
    /// not available for the buyer to redeem another reward.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Rewards.CreateAsync(
    ///     new CreateLoyaltyRewardRequest
    ///     {
    ///         Reward = new LoyaltyReward
    ///         {
    ///             LoyaltyAccountId = "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
    ///             RewardTierId = "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
    ///             OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
    ///         },
    ///         IdempotencyKey = "18c2e5ea-a620-4b1f-ad60-7b167285e451",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateLoyaltyRewardResponse> CreateAsync(
        CreateLoyaltyRewardRequest request,
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
                    Path = "v2/loyalty/rewards",
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
                return JsonUtils.Deserialize<CreateLoyaltyRewardResponse>(responseBody)!;
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
    /// Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts.
    /// If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.
    ///
    /// If you know a reward ID, use the
    /// [RetrieveLoyaltyReward](api-endpoint:Loyalty-RetrieveLoyaltyReward) endpoint.
    ///
    /// Search results are sorted by `updated_at` in descending order.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Rewards.SearchAsync(
    ///     new SearchLoyaltyRewardsRequest
    ///     {
    ///         Query = new SearchLoyaltyRewardsRequestLoyaltyRewardQuery
    ///         {
    ///             LoyaltyAccountId = "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
    ///         },
    ///         Limit = 10,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<LoyaltyReward>> SearchAsync(
        SearchLoyaltyRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            SearchLoyaltyRewardsRequest,
            RequestOptions?,
            SearchLoyaltyRewardsResponse,
            string?,
            LoyaltyReward
        >
            .CreateInstanceAsync(
                request,
                options,
                SearchInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Rewards?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a loyalty reward.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Rewards.GetAsync(new GetRewardsRequest { RewardId = "reward_id" });
    /// </code></example>
    public async Task<GetLoyaltyRewardResponse> GetAsync(
        GetRewardsRequest request,
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
                        "v2/loyalty/rewards/{0}",
                        ValueConvert.ToPathParameterString(request.RewardId)
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
                return JsonUtils.Deserialize<GetLoyaltyRewardResponse>(responseBody)!;
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
    /// Deletes a loyalty reward by doing the following:
    ///
    /// - Returns the loyalty points back to the loyalty account.
    /// - If an order ID was specified when the reward was created
    /// (see [CreateLoyaltyReward](api-endpoint:Loyalty-CreateLoyaltyReward)),
    /// it updates the order by removing the reward and related
    /// discounts.
    ///
    /// You cannot delete a reward that has reached the terminal state (REDEEMED).
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Rewards.DeleteAsync(new DeleteRewardsRequest { RewardId = "reward_id" });
    /// </code></example>
    public async Task<DeleteLoyaltyRewardResponse> DeleteAsync(
        DeleteRewardsRequest request,
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
                        "v2/loyalty/rewards/{0}",
                        ValueConvert.ToPathParameterString(request.RewardId)
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
                return JsonUtils.Deserialize<DeleteLoyaltyRewardResponse>(responseBody)!;
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
    /// Redeems a loyalty reward.
    ///
    /// The endpoint sets the reward to the `REDEEMED` terminal state.
    ///
    /// If you are using your own order processing system (not using the
    /// Orders API), you call this endpoint after the buyer paid for the
    /// purchase.
    ///
    /// After the reward reaches the terminal state, it cannot be deleted.
    /// In other words, points used for the reward cannot be returned
    /// to the account.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Rewards.RedeemAsync(
    ///     new RedeemLoyaltyRewardRequest
    ///     {
    ///         RewardId = "reward_id",
    ///         IdempotencyKey = "98adc7f7-6963-473b-b29c-f3c9cdd7d994",
    ///         LocationId = "P034NEENMD09F",
    ///     }
    /// );
    /// </code></example>
    public async Task<RedeemLoyaltyRewardResponse> RedeemAsync(
        RedeemLoyaltyRewardRequest request,
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
                        "v2/loyalty/rewards/{0}/redeem",
                        ValueConvert.ToPathParameterString(request.RewardId)
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
                return JsonUtils.Deserialize<RedeemLoyaltyRewardResponse>(responseBody)!;
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
