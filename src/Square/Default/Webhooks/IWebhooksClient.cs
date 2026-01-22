namespace Square.Default.Webhooks;

public partial interface IWebhooksClient
{
    public EventTypesClient EventTypes { get; }
    public SubscriptionsClient Subscriptions { get; }
}
