using Square.Core;

namespace Square.Default.Webhooks;

public partial class WebhooksClient : IWebhooksClient
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
