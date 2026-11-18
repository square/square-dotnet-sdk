using Square;

namespace Square.Webhooks.EventTypes;

public partial interface IEventTypesClient
{
    /// <summary>
    /// Lists all webhook event types that can be subscribed to.
    /// </summary>
    Task<ListWebhookEventTypesResponse> ListAsync(
        ListEventTypesBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
