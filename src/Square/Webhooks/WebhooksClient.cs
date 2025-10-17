using Square.Core;
using Square.Webhooks.EventTypes;

namespace Square.Webhooks;

public partial class WebhooksClient
{
    private RawClient _client;

    internal WebhooksClient(RawClient client)
    {
        _client = client;
        EventTypes = new EventTypesClient(_client);
        Subscriptions = new Square.Webhooks.Subscriptions.SubscriptionsClient(_client);
    }

    public EventTypesClient EventTypes { get; }

    public Square.Webhooks.Subscriptions.SubscriptionsClient Subscriptions { get; }
}
