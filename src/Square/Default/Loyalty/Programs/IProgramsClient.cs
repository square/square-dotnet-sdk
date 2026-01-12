using Square;
using Square.Default;
using Square.Default.Loyalty.Programs.Promotions;

namespace Square.Default.Loyalty.Programs;

public partial interface IProgramsClient
{
    public PromotionsClient Promotions { get; }

    /// <summary>
    /// Returns a list of loyalty programs in the seller's account.
    /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
    ///
    ///
    /// Replaced with [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) when used with the keyword `main`.
    /// </summary>
    Task<ListLoyaltyProgramsResponse> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the loyalty program in a seller's account, specified by the program ID or the keyword `main`.
    ///
    /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
    /// </summary>
    Task<GetLoyaltyProgramResponse> GetAsync(
        GetProgramsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Calculates the number of points a buyer can earn from a purchase. Applications might call this endpoint
    /// to display the points to the buyer.
    ///
    /// - If you are using the Orders API to manage orders, provide the `order_id` and (optional) `loyalty_account_id`.
    /// Square reads the order to compute the points earned from the base loyalty program and an associated
    /// [loyalty promotion](entity:LoyaltyPromotion).
    ///
    /// - If you are not using the Orders API to manage orders, provide `transaction_amount_money` with the
    /// purchase amount. Square uses this amount to calculate the points earned from the base loyalty program,
    /// but not points earned from a loyalty promotion. For spend-based and visit-based programs, the `tax_mode`
    /// setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
    /// If the purchase qualifies for program points, call
    /// [ListLoyaltyPromotions](api-endpoint:Loyalty-ListLoyaltyPromotions) and perform a client-side computation
    /// to calculate whether the purchase also qualifies for promotion points. For more information, see
    /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
    /// </summary>
    Task<CalculateLoyaltyPointsResponse> CalculateAsync(
        CalculateLoyaltyPointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
