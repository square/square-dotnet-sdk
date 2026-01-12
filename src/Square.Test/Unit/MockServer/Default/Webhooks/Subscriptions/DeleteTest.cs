using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Webhooks.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Webhooks.Subscriptions;

[TestFixture]
public class DeleteTest : BaseMockServerTest
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions/subscription_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Webhooks.Subscriptions.DeleteAsync(
            new DeleteSubscriptionsRequest { SubscriptionId = "subscription_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteWebhookSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
