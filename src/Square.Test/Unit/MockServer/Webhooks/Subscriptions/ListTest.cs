using NUnit.Framework;
using Square;
using Square.Test.Unit.MockServer;
using Square.Webhooks.Subscriptions;

namespace Square.Test.Unit.MockServer.Webhooks.Subscriptions;

[TestFixture]
public class ListTest : BaseMockServerTest
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
                  "created_at": "2022-01-10 23:29:48 +0000 UTC",
                  "updated_at": "2022-01-10 23:29:48 +0000 UTC"
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
                    .WithParam("cursor", "cursor")
                    .WithParam("sort_order", "DESC")
                    .WithParam("limit", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Webhooks.Subscriptions.ListAsync(
            new ListSubscriptionsRequest
            {
                Cursor = "cursor",
                IncludeDisabled = true,
                SortOrder = SortOrder.Desc,
                Limit = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
