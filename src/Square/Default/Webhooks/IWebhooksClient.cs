using Square.Default.Webhooks.EventTypes;

namespace Square.Default.Webhooks;

public partial interface IWebhooksClient
{
    public EventTypesClient EventTypes { get; }
    public Square.Default.Webhooks.Subscriptions.SubscriptionsClient Subscriptions { get; }
}
