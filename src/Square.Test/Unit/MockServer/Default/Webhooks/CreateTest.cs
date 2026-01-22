using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Webhooks;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Webhooks;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "63f84c6c-2200-4c99-846c-2670a1311fbf",
              "subscription": {
                "name": "Example Webhook Subscription",
                "event_types": [
                  "payment.created",
                  "payment.updated"
                ],
                "notification_url": "https://example-webhook-url.com",
                "api_version": "2021-12-15"
              }
            }
            """;

        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "subscription": {
                "id": "wbhk_b35f6b3145074cf9ad513610786c19d5",
                "name": "Example Webhook Subscription",
                "enabled": true,
                "event_types": [
                  "payment.created",
                  "payment.updated"
                ],
                "notification_url": "https://example-webhook-url.com",
                "api_version": "2021-12-15",
                "signature_key": "1k9bIJKCeTmSQwyagtNRLg",
                "created_at": "2022-01-10 23:29:48 +0000 UTC",
                "updated_at": "2022-01-10 23:29:48 +0000 UTC"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Webhooks.Subscriptions.CreateAsync(
            new CreateWebhookSubscriptionRequest
            {
                IdempotencyKey = "63f84c6c-2200-4c99-846c-2670a1311fbf",
                Subscription = new WebhookSubscription
                {
                    Name = "Example Webhook Subscription",
                    EventTypes = new List<string>() { "payment.created", "payment.updated" },
                    NotificationUrl = "https://example-webhook-url.com",
                    ApiVersion = "2021-12-15",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateWebhookSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
