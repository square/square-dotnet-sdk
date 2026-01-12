using Square.Core;
using Square.Default.Webhooks.EventTypes;

namespace Square.Default.Webhooks;

public partial class WebhooksClient : IWebhooksClient
{
    private RawClient _client;

    internal WebhooksClient(RawClient client)
    {
        _client = client;
        EventTypes = new EventTypesClient(_client);
        Subscriptions = new Square.Default.Webhooks.Subscriptions.SubscriptionsClient(_client);
    }

    public EventTypesClient EventTypes { get; }

    public Square.Default.Webhooks.Subscriptions.SubscriptionsClient Subscriptions { get; }
}
