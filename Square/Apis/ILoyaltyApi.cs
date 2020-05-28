using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface ILoyaltyApi
    {
        /// <summary>
        /// Creates a loyalty account. For more information, see 
        /// [Create a loyalty account](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-create-account).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyAccountResponse response from the API call</return>
        Models.CreateLoyaltyAccountResponse CreateLoyaltyAccount(Models.CreateLoyaltyAccountRequest body);

        /// <summary>
        /// Creates a loyalty account. For more information, see 
        /// [Create a loyalty account](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-create-account).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyAccountResponse response from the API call</return>
        Task<Models.CreateLoyaltyAccountResponse> CreateLoyaltyAccountAsync(Models.CreateLoyaltyAccountRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for loyalty accounts. 
        /// In the current implementation, you can search for a loyalty account using the phone number associated with the account. 
        /// If no phone number is provided, all loyalty accounts are returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyAccountsResponse response from the API call</return>
        Models.SearchLoyaltyAccountsResponse SearchLoyaltyAccounts(Models.SearchLoyaltyAccountsRequest body);

        /// <summary>
        /// Searches for loyalty accounts. 
        /// In the current implementation, you can search for a loyalty account using the phone number associated with the account. 
        /// If no phone number is provided, all loyalty accounts are returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyAccountsResponse response from the API call</return>
        Task<Models.SearchLoyaltyAccountsResponse> SearchLoyaltyAccountsAsync(Models.SearchLoyaltyAccountsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a loyalty account.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyAccountResponse response from the API call</return>
        Models.RetrieveLoyaltyAccountResponse RetrieveLoyaltyAccount(string accountId);

        /// <summary>
        /// Retrieves a loyalty account.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyAccountResponse response from the API call</return>
        Task<Models.RetrieveLoyaltyAccountResponse> RetrieveLoyaltyAccountAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds points to a loyalty account.
        /// - If you are using the Orders API to manage orders, you only provide the `order_id`. 
        /// The endpoint reads the order to compute points to add to the buyer's account.
        /// - If you are not using the Orders API to manage orders, 
        /// you first perform a client-side computation to compute the points.  
        /// For spend-based and visit-based programs, you can call 
        /// `CalculateLoyaltyPoints` to compute the points. For more information, 
        /// see [Loyalty Program Overview](https://developer.squareup.com/docs/docs/loyalty/overview). 
        /// You then provide the points in a request to this endpoint. 
        /// For more information, see [Accumulate points](https://developer.squareup.com/docs/docs/loyalty-api/overview/#accumulate-points).
        /// </summary>
        /// <param name="accountId">Required parameter: The [loyalty account](#type-LoyaltyAccount) ID to which to add the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AccumulateLoyaltyPointsResponse response from the API call</return>
        Models.AccumulateLoyaltyPointsResponse AccumulateLoyaltyPoints(string accountId, Models.AccumulateLoyaltyPointsRequest body);

        /// <summary>
        /// Adds points to a loyalty account.
        /// - If you are using the Orders API to manage orders, you only provide the `order_id`. 
        /// The endpoint reads the order to compute points to add to the buyer's account.
        /// - If you are not using the Orders API to manage orders, 
        /// you first perform a client-side computation to compute the points.  
        /// For spend-based and visit-based programs, you can call 
        /// `CalculateLoyaltyPoints` to compute the points. For more information, 
        /// see [Loyalty Program Overview](https://developer.squareup.com/docs/docs/loyalty/overview). 
        /// You then provide the points in a request to this endpoint. 
        /// For more information, see [Accumulate points](https://developer.squareup.com/docs/docs/loyalty-api/overview/#accumulate-points).
        /// </summary>
        /// <param name="accountId">Required parameter: The [loyalty account](#type-LoyaltyAccount) ID to which to add the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AccumulateLoyaltyPointsResponse response from the API call</return>
        Task<Models.AccumulateLoyaltyPointsResponse> AccumulateLoyaltyPointsAsync(string accountId, Models.AccumulateLoyaltyPointsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds points to or subtracts points from a buyer's account. 
        /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call 
        /// [AccumulateLoyaltyPoints](https://developer.squareup.com/docs/reference/square/loyalty-api/accumulate-loyalty-points) 
        /// to add points when a buyer pays for the purchase.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) in which to adjust the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AdjustLoyaltyPointsResponse response from the API call</return>
        Models.AdjustLoyaltyPointsResponse AdjustLoyaltyPoints(string accountId, Models.AdjustLoyaltyPointsRequest body);

        /// <summary>
        /// Adds points to or subtracts points from a buyer's account. 
        /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call 
        /// [AccumulateLoyaltyPoints](https://developer.squareup.com/docs/reference/square/loyalty-api/accumulate-loyalty-points) 
        /// to add points when a buyer pays for the purchase.
        /// </summary>
        /// <param name="accountId">Required parameter: The ID of the [loyalty account](#type-LoyaltyAccount) in which to adjust the points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.AdjustLoyaltyPointsResponse response from the API call</return>
        Task<Models.AdjustLoyaltyPointsResponse> AdjustLoyaltyPointsAsync(string accountId, Models.AdjustLoyaltyPointsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for loyalty events.
        /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a 
        /// buyer's loyalty account. Each change in the point balance 
        /// (for example, points earned, points redeemed, and points expired) is 
        /// recorded in the ledger. Using this endpoint, you can search the ledger for events. 
        /// For more information, see 
        /// [Loyalty events](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-events).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyEventsResponse response from the API call</return>
        Models.SearchLoyaltyEventsResponse SearchLoyaltyEvents(Models.SearchLoyaltyEventsRequest body);

        /// <summary>
        /// Searches for loyalty events.
        /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a 
        /// buyer's loyalty account. Each change in the point balance 
        /// (for example, points earned, points redeemed, and points expired) is 
        /// recorded in the ledger. Using this endpoint, you can search the ledger for events. 
        /// For more information, see 
        /// [Loyalty events](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-events).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyEventsResponse response from the API call</return>
        Task<Models.SearchLoyaltyEventsResponse> SearchLoyaltyEventsAsync(Models.SearchLoyaltyEventsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of loyalty programs in the seller's account.
        /// Currently, a seller can only have one loyalty program. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
        /// .
        /// </summary>
        /// <return>Returns the Models.ListLoyaltyProgramsResponse response from the API call</return>
        Models.ListLoyaltyProgramsResponse ListLoyaltyPrograms();

        /// <summary>
        /// Returns a list of loyalty programs in the seller's account.
        /// Currently, a seller can only have one loyalty program. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
        /// .
        /// </summary>
        /// <return>Returns the Models.ListLoyaltyProgramsResponse response from the API call</return>
        Task<Models.ListLoyaltyProgramsResponse> ListLoyaltyProgramsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Calculates the points a purchase earns.
        /// - If you are using the Orders API to manage orders, you provide `order_id` in the request. The 
        /// endpoint calculates the points by reading the order.
        /// - If you are not using the Orders API to manage orders, you provide the purchase amount in 
        /// the request for the endpoint to calculate the points.
        /// An application might call this endpoint to show the points that a buyer can earn with the 
        /// specific purchase.
        /// </summary>
        /// <param name="programId">Required parameter: The [loyalty program](#type-LoyaltyProgram) ID, which defines the rules for accruing points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateLoyaltyPointsResponse response from the API call</return>
        Models.CalculateLoyaltyPointsResponse CalculateLoyaltyPoints(string programId, Models.CalculateLoyaltyPointsRequest body);

        /// <summary>
        /// Calculates the points a purchase earns.
        /// - If you are using the Orders API to manage orders, you provide `order_id` in the request. The 
        /// endpoint calculates the points by reading the order.
        /// - If you are not using the Orders API to manage orders, you provide the purchase amount in 
        /// the request for the endpoint to calculate the points.
        /// An application might call this endpoint to show the points that a buyer can earn with the 
        /// specific purchase.
        /// </summary>
        /// <param name="programId">Required parameter: The [loyalty program](#type-LoyaltyProgram) ID, which defines the rules for accruing points.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CalculateLoyaltyPointsResponse response from the API call</return>
        Task<Models.CalculateLoyaltyPointsResponse> CalculateLoyaltyPointsAsync(string programId, Models.CalculateLoyaltyPointsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a loyalty reward. In the process, the endpoint does following:
        /// - Uses the `reward_tier_id` in the request to determine the number of points 
        /// to lock for this reward. 
        /// - If the request includes `order_id`, it adds the reward and related discount to the order. 
        /// After a reward is created, the points are locked and 
        /// not available for the buyer to redeem another reward. 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyRewardResponse response from the API call</return>
        Models.CreateLoyaltyRewardResponse CreateLoyaltyReward(Models.CreateLoyaltyRewardRequest body);

        /// <summary>
        /// Creates a loyalty reward. In the process, the endpoint does following:
        /// - Uses the `reward_tier_id` in the request to determine the number of points 
        /// to lock for this reward. 
        /// - If the request includes `order_id`, it adds the reward and related discount to the order. 
        /// After a reward is created, the points are locked and 
        /// not available for the buyer to redeem another reward. 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLoyaltyRewardResponse response from the API call</return>
        Task<Models.CreateLoyaltyRewardResponse> CreateLoyaltyRewardAsync(Models.CreateLoyaltyRewardRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for loyalty rewards in a loyalty account. 
        /// In the current implementation, the endpoint supports search by the reward `status`.
        /// If you know a reward ID, use the 
        /// [RetrieveLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/retrieve-loyalty-reward) endpoint.
        /// For more information about loyalty rewards, see 
        /// [Loyalty Rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyRewardsResponse response from the API call</return>
        Models.SearchLoyaltyRewardsResponse SearchLoyaltyRewards(Models.SearchLoyaltyRewardsRequest body);

        /// <summary>
        /// Searches for loyalty rewards in a loyalty account. 
        /// In the current implementation, the endpoint supports search by the reward `status`.
        /// If you know a reward ID, use the 
        /// [RetrieveLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/retrieve-loyalty-reward) endpoint.
        /// For more information about loyalty rewards, see 
        /// [Loyalty Rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-rewards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchLoyaltyRewardsResponse response from the API call</return>
        Task<Models.SearchLoyaltyRewardsResponse> SearchLoyaltyRewardsAsync(Models.SearchLoyaltyRewardsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a loyalty reward by doing the following:
        /// - Returns the loyalty points back to the loyalty account.
        /// - If an order ID was specified when the reward was created 
        /// (see [CreateLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/create-loyalty-reward)), 
        /// it updates the order by removing the reward and related 
        /// discounts.
        /// You cannot delete a reward that has reached the terminal state (REDEEMED). 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to delete.</param>
        /// <return>Returns the Models.DeleteLoyaltyRewardResponse response from the API call</return>
        Models.DeleteLoyaltyRewardResponse DeleteLoyaltyReward(string rewardId);

        /// <summary>
        /// Deletes a loyalty reward by doing the following:
        /// - Returns the loyalty points back to the loyalty account.
        /// - If an order ID was specified when the reward was created 
        /// (see [CreateLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/create-loyalty-reward)), 
        /// it updates the order by removing the reward and related 
        /// discounts.
        /// You cannot delete a reward that has reached the terminal state (REDEEMED). 
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to delete.</param>
        /// <return>Returns the Models.DeleteLoyaltyRewardResponse response from the API call</return>
        Task<Models.DeleteLoyaltyRewardResponse> DeleteLoyaltyRewardAsync(string rewardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a loyalty reward.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyRewardResponse response from the API call</return>
        Models.RetrieveLoyaltyRewardResponse RetrieveLoyaltyReward(string rewardId);

        /// <summary>
        /// Retrieves a loyalty reward.
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to retrieve.</param>
        /// <return>Returns the Models.RetrieveLoyaltyRewardResponse response from the API call</return>
        Task<Models.RetrieveLoyaltyRewardResponse> RetrieveLoyaltyRewardAsync(string rewardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Redeems a loyalty reward.
        /// The endpoint sets the reward to the terminal state (`REDEEMED`). 
        /// If you are using your own order processing system (not using the 
        /// Orders API), you call this endpoint after the buyer paid for the 
        /// purchase.
        /// After the reward reaches the terminal state, it cannot be deleted. 
        /// In other words, points used for the reward cannot be returned 
        /// to the account.
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to redeem.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RedeemLoyaltyRewardResponse response from the API call</return>
        Models.RedeemLoyaltyRewardResponse RedeemLoyaltyReward(string rewardId, Models.RedeemLoyaltyRewardRequest body);

        /// <summary>
        /// Redeems a loyalty reward.
        /// The endpoint sets the reward to the terminal state (`REDEEMED`). 
        /// If you are using your own order processing system (not using the 
        /// Orders API), you call this endpoint after the buyer paid for the 
        /// purchase.
        /// After the reward reaches the terminal state, it cannot be deleted. 
        /// In other words, points used for the reward cannot be returned 
        /// to the account.
        /// For more information, see 
        /// [Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).
        /// </summary>
        /// <param name="rewardId">Required parameter: The ID of the [loyalty reward](#type-LoyaltyReward) to redeem.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RedeemLoyaltyRewardResponse response from the API call</return>
        Task<Models.RedeemLoyaltyRewardResponse> RedeemLoyaltyRewardAsync(string rewardId, Models.RedeemLoyaltyRewardRequest body, CancellationToken cancellationToken = default);

    }
}