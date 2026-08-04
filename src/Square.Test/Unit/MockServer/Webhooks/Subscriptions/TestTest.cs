using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;
using Square.Webhooks.Subscriptions;

namespace Square.Test.Unit.MockServer.Webhooks.Subscriptions;

[TestFixture]
public class TestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "event_type": "payment.created"
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
              "subscription_test_result": {
                "id": "23eed5a9-2b12-403e-b212-7e2889aea0f6",
                "status_code": 404,
                "payload": {
                  "key": "value"
                },
                "created_at": "2022-01-11 00:06:48.322945116 +0000 UTC m=+3863.054453746",
                "updated_at": "2022-01-11 00:06:48.322945116 +0000 UTC m=+3863.054453746",
                "notification_url": "notification_url",
                "passes_filter": true
              },
              "notification_url": "notification_url",
              "status_code": 1,
              "passes_filter": true,
              "payload": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions/subscription_id/test")
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

        var response = await Client.Webhooks.Subscriptions.TestAsync(
            new TestWebhookSubscriptionRequest
            {
                SubscriptionId = "subscription_id",
                EventType = "payment.created",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<TestWebhookSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
