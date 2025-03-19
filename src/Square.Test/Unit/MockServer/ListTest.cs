using global::System.Threading.Tasks;
using NUnit.Framework;
using Square.Webhooks.Subscriptions;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "subscriptions": [
                {
                  "id": "wbhk_b35f6b3145074cf9ad513610786c19d5",
                  "name": "Example Webhook Subscription",
                  "enabled": true,
                  "event_types": [
                    "payment.created",
                    "payment.updated"
                  ],
                  "notification_url": "https://example-webhook-url.com",
                  "api_version": "2021-12-15",
                  "signature_key": "signature_key",
                  "created_at": "2022-01-10T23:29:48.000Z",
                  "updated_at": "2022-01-10T23:29:48.000Z"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var pager = await Client.Webhooks.Subscriptions.ListAsync(
            new ListSubscriptionsRequest(),
            RequestOptions
        );
        await foreach (var item in pager)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
