using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Webhooks.Subscriptions;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
                "created_at": "2022-01-10T23:29:48.000Z",
                "updated_at": "2022-01-10T23:29:48.000Z"
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

        var response = await Client.Webhooks.Subscriptions.GetAsync(
            new GetSubscriptionsRequest { SubscriptionId = "subscription_id" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetWebhookSubscriptionResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
