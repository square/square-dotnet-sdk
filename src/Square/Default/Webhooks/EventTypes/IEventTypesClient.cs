using Square;
using Square.Default;

namespace Square.Default.Webhooks.EventTypes;

public partial interface IEventTypesClient
{
    /// <summary>
    /// Lists all webhook event types that can be subscribed to.
    /// </summary>
    Task<ListWebhookEventTypesResponse> ListAsync(
        ListEventTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
