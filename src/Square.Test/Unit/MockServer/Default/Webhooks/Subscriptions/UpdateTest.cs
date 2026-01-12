using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Webhooks.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Webhooks.Subscriptions;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "subscription": {
                "name": "Updated Example Webhook Subscription",
                "enabled": false
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
                "name": "Updated Example Webhook Subscription",
                "enabled": false,
                "event_types": [
                  "payment.created",
                  "payment.updated"
                ],
                "notification_url": "https://example-webhook-url.com",
                "api_version": "2021-12-15",
                "signature_key": "signature_key",
                "created_at": "2022-01-10 23:29:48 +0000 UTC",
                "updated_at": "2022-01-10 23:45:51 +0000 UTC"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions/subscription_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Webhooks.Subscriptions.UpdateAsync(
            new UpdateWebhookSubscriptionRequest
            {
                SubscriptionId = "subscription_id",
                Subscription = new WebhookSubscription
                {
                    Name = "Updated Example Webhook Subscription",
                    Enabled = false,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateWebhookSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
