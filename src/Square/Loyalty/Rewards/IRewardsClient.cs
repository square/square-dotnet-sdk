using Square;

namespace Square.Loyalty.Rewards;

public partial interface IRewardsClient
{
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
    Task<CreateLoyaltyRewardResponse> CreateAsync(
        CreateLoyaltyRewardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts.
    /// If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.
    ///
    /// If you know a reward ID, use the
    /// [RetrieveLoyaltyReward](api-endpoint:Loyalty-RetrieveLoyaltyReward) endpoint.
    ///
    /// Search results are sorted by `updated_at` in descending order.
    /// </summary>
    Task<SearchLoyaltyRewardsResponse> SearchAsync(
        SearchLoyaltyRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a loyalty reward.
    /// </summary>
    Task<GetLoyaltyRewardResponse> GetAsync(
        GetRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
    Task<DeleteLoyaltyRewardResponse> DeleteAsync(
        DeleteRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
    Task<RedeemLoyaltyRewardResponse> RedeemAsync(
        RedeemLoyaltyRewardRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
