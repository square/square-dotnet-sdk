using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Subscriptions;

public partial interface ISubscriptionsClient
{
    /// <summary>
    /// Enrolls a customer in a subscription.
    ///
    /// If you provide a card on file in the request, Square charges the card for
    /// the subscription. Otherwise, Square sends an invoice to the customer's email
    /// address. The subscription starts immediately, unless the request includes
    /// the optional `start_date`. Each individual subscription is associated with a particular location.
    ///
    /// For more information, see [Create a subscription](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions#create-a-subscription).
    /// </summary>
    Task<CreateSubscriptionResponse> CreateAsync(
        CreateSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Schedules a plan variation change for all active subscriptions under a given plan
    /// variation. For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).
    /// </summary>
    Task<BulkSwapPlanResponse> BulkSwapPlanAsync(
        BulkSwapPlanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for subscriptions.
    ///
    /// Results are ordered chronologically by subscription creation date. If
    /// the request specifies more than one location ID,
    /// the endpoint orders the result
    /// by location ID, and then by creation date within each location. If no locations are given
    /// in the query, all locations are searched.
    ///
    /// You can also optionally specify `customer_ids` to search by customer.
    /// If left unset, all customers
    /// associated with the specified locations are returned.
    /// If the request specifies customer IDs, the endpoint orders results
    /// first by location, within location by customer ID, and within
    /// customer by subscription creation date.
    /// </summary>
    Task<SearchSubscriptionsResponse> SearchAsync(
        SearchSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific subscription.
    /// </summary>
    Task<GetSubscriptionResponse> GetAsync(
        GetSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a subscription by modifying or clearing `subscription` field values.
    /// To clear a field, set its value to `null`.
    /// </summary>
    Task<UpdateSubscriptionResponse> UpdateAsync(
        UpdateSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a scheduled action for a subscription.
    /// </summary>
    Task<DeleteSubscriptionActionResponse> DeleteActionAsync(
        DeleteActionSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes the [billing anchor date](https://developer.squareup.com/docs/subscriptions-api/subscription-billing#billing-dates)
    /// for a subscription.
    /// </summary>
    Task<ChangeBillingAnchorDateResponse> ChangeBillingAnchorDateAsync(
        ChangeBillingAnchorDateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Schedules a `CANCEL` action to cancel an active subscription. This
    /// sets the `canceled_date` field to the end of the active billing period. After this date,
    /// the subscription status changes from ACTIVE to CANCELED.
    /// </summary>
    Task<CancelSubscriptionResponse> CancelAsync(
        CancelSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all [events](https://developer.squareup.com/docs/subscriptions-api/actions-events) for a specific subscription.
    /// </summary>
    Task<Pager<SubscriptionEvent>> ListEventsAsync(
        ListEventsSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Schedules a `PAUSE` action to pause an active subscription.
    /// </summary>
    Task<PauseSubscriptionResponse> PauseAsync(
        PauseSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
    /// </summary>
    Task<ResumeSubscriptionResponse> ResumeAsync(
        ResumeSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Schedules a `SWAP_PLAN` action to swap a subscription plan variation in an existing subscription.
    /// For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).
    /// </summary>
    Task<SwapPlanResponse> SwapPlanAsync(
        SwapPlanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
