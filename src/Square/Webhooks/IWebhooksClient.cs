using Square.Webhooks.EventTypes;

namespace Square.Webhooks;

public partial interface IWebhooksClient
{
    public EventTypesClient EventTypes { get; }
    public Square.Webhooks.Subscriptions.SubscriptionsClient Subscriptions { get; }
}
