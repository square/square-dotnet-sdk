using NUnit.Framework;
using Square.Default.GiftCards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.GiftCards;

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
              "gift_cards": [
                {
                  "id": "gftc:00113070ba5745f0b2377c1b9570cb03",
                  "type": "DIGITAL",
                  "gan_source": "SQUARE",
                  "state": "ACTIVE",
                  "balance_money": {
                    "amount": 3900,
                    "currency": "USD"
                  },
                  "gan": "7783320008524605",
                  "created_at": "2021-06-09T22:26:54.000Z",
                  "customer_ids": [
                    "customer_ids"
                  ]
                },
                {
                  "id": "gftc:00128a12725b41e58e0de1d20497a9dd",
                  "type": "DIGITAL",
                  "gan_source": "SQUARE",
                  "state": "ACTIVE",
                  "balance_money": {
                    "amount": 2000,
                    "currency": "USD"
                  },
                  "gan": "7783320002692465",
                  "created_at": "2021-05-20T22:26:54.000Z",
                  "customer_ids": [
                    "customer_ids"
                  ]
                }
              ],
              "cursor": "JbFmyvUpaNKsfC1hoLSA4WlqkgkZXTWeKuStajR5BkP7OE0ETAbeWSi6U6u7sH"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/gift-cards")
                    .WithParam("type", "type")
                    .WithParam("state", "state")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .WithParam("customer_id", "customer_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.GiftCards.ListAsync(
            new ListGiftCardsRequest
            {
                Type = "type",
                State = "state",
                Limit = 1,
                Cursor = "cursor",
                CustomerId = "customer_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
