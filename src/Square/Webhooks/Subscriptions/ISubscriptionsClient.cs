using Square;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

public partial interface ISubscriptionsClient
{
    /// <summary>
    /// Lists all webhook subscriptions owned by your application.
    /// </summary>
    Task<Pager<WebhookSubscription>> ListAsync(
        ListSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a webhook subscription.
    /// </summary>
    Task<CreateWebhookSubscriptionResponse> CreateAsync(
        CreateWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a webhook subscription identified by its ID.
    /// </summary>
    Task<GetWebhookSubscriptionResponse> GetAsync(
        GetSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a webhook subscription.
    /// </summary>
    Task<UpdateWebhookSubscriptionResponse> UpdateAsync(
        UpdateWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a webhook subscription.
    /// </summary>
    Task<DeleteWebhookSubscriptionResponse> DeleteAsync(
        DeleteSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a webhook subscription by replacing the existing signature key with a new one.
    /// </summary>
    Task<UpdateWebhookSubscriptionSignatureKeyResponse> UpdateSignatureKeyAsync(
        UpdateWebhookSubscriptionSignatureKeyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Tests a webhook subscription by sending a test event to the notification URL.
    /// </summary>
    Task<TestWebhookSubscriptionResponse> TestAsync(
        TestWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
