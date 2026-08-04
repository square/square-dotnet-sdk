using Square;
using Square.Core;

namespace Square.Loyalty.Programs.Promotions;

public partial interface IPromotionsClient
{
    /// <summary>
    /// Lists the loyalty promotions associated with a [loyalty program](entity:LoyaltyProgram).
    /// Results are sorted by the `created_at` date in descending order (newest to oldest).
    /// </summary>
    Task<Pager<LoyaltyPromotion>> ListAsync(
        ListPromotionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a loyalty promotion for a [loyalty program](entity:LoyaltyProgram). A loyalty promotion
    /// enables buyers to earn points in addition to those earned from the base loyalty program.
    ///
    /// This endpoint sets the loyalty promotion to the `ACTIVE` or `SCHEDULED` status, depending on the
    /// `available_time` setting. A loyalty program can have a maximum of 10 loyalty promotions with an
    /// `ACTIVE` or `SCHEDULED` status.
    /// </summary>
    Task<CreateLoyaltyPromotionResponse> CreateAsync(
        CreateLoyaltyPromotionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a loyalty promotion.
    /// </summary>
    Task<GetLoyaltyPromotionResponse> GetAsync(
        GetPromotionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a loyalty promotion. Use this endpoint to cancel an `ACTIVE` promotion earlier than the
    /// end date, cancel an `ACTIVE` promotion when an end date is not specified, or cancel a `SCHEDULED` promotion.
    /// Because updating a promotion is not supported, you can also use this endpoint to cancel a promotion before
    /// you create a new one.
    ///
    /// This endpoint sets the loyalty promotion to the `CANCELED` state
    /// </summary>
    Task<CancelLoyaltyPromotionResponse> CancelAsync(
        CancelPromotionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
