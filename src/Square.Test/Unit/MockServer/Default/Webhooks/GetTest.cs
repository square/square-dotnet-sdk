using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Webhooks;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/v2/webhooks/subscriptions/subscription_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Webhooks.Subscriptions.GetAsync(
            new Square.Default.Webhooks.GetSubscriptionsRequest
            {
                SubscriptionId = "subscription_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetWebhookSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
