using Square.Core;
using Square.Webhooks.EventTypes;
using Square.Webhooks.Subscriptions;

namespace Square.Webhooks;

public partial class WebhooksClient
{
    private RawClient _client;

    internal WebhooksClient(RawClient client)
    {
        _client = client;
        EventTypes = new EventTypesClient(_client);
        Subscriptions = new SubscriptionsClient(_client);
    }

    public EventTypesClient EventTypes { get; }

    public SubscriptionsClient Subscriptions { get; }
}
