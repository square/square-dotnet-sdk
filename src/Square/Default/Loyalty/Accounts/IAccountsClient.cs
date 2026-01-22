using Square;
using Square.Default;

namespace Square.Default.Loyalty;

public partial interface IAccountsClient
{
    /// <summary>
    /// Creates a loyalty account. To create a loyalty account, you must provide the `program_id` and a `mapping` with the `phone_number` of the buyer.
    /// </summary>
    Task<CreateLoyaltyAccountResponse> CreateAsync(
        CreateLoyaltyAccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for loyalty accounts in a loyalty program.
    ///
    /// You can search for a loyalty account using the phone number or customer ID associated with the account. To return all loyalty accounts, specify an empty `query` object or omit it entirely.
    ///
    /// Search results are sorted by `created_at` in ascending order.
    /// </summary>
    Task<SearchLoyaltyAccountsResponse> SearchAsync(
        SearchLoyaltyAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a loyalty account.
    /// </summary>
    Task<GetLoyaltyAccountResponse> GetAsync(
        GetAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds points earned from a purchase to a [loyalty account](entity:LoyaltyAccount).
    ///
    /// - If you are using the Orders API to manage orders, provide the `order_id`. Square reads the order
    /// to compute the points earned from both the base loyalty program and an associated
    /// [loyalty promotion](entity:LoyaltyPromotion). For purchases that qualify for multiple accrual
    /// rules, Square computes points based on the accrual rule that grants the most points.
    /// For purchases that qualify for multiple promotions, Square computes points based on the most
    /// recently created promotion. A purchase must first qualify for program points to be eligible for promotion points.
    ///
    /// - If you are not using the Orders API to manage orders, provide `points` with the number of points to add.
    /// You must first perform a client-side computation of the points earned from the loyalty program and
    /// loyalty promotion. For spend-based and visit-based programs, you can call [CalculateLoyaltyPoints](api-endpoint:Loyalty-CalculateLoyaltyPoints)
    /// to compute the points earned from the base loyalty program. For information about computing points earned from a loyalty promotion, see
    /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
    /// </summary>
    Task<AccumulateLoyaltyPointsResponse> AccumulatePointsAsync(
        AccumulateLoyaltyPointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds points to or subtracts points from a buyer's account.
    ///
    /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call
    /// [AccumulateLoyaltyPoints](api-endpoint:Loyalty-AccumulateLoyaltyPoints)
    /// to add points when a buyer pays for the purchase.
    /// </summary>
    Task<AdjustLoyaltyPointsResponse> AdjustAsync(
        AdjustLoyaltyPointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
