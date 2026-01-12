using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.GiftCards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.GiftCards;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "NC9Tm69EjbjtConu",
              "location_id": "81FN9BNFZTKS4",
              "gift_card": {
                "type": "DIGITAL"
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
              "gift_card": {
                "id": "gftc:6cbacbb64cf54e2ca9f573d619038059",
                "type": "DIGITAL",
                "gan_source": "SQUARE",
                "state": "PENDING",
                "balance_money": {
                  "amount": 0,
                  "currency": "USD"
                },
                "gan": "7783320006753271",
                "created_at": "2021-05-20T22:26:54.000Z",
                "customer_ids": [
                  "customer_ids"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/gift-cards")
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

        var response = await Client.Default.GiftCards.CreateAsync(
            new CreateGiftCardRequest
            {
                IdempotencyKey = "NC9Tm69EjbjtConu",
                LocationId = "81FN9BNFZTKS4",
                GiftCard = new GiftCard { Type = GiftCardType.Digital },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateGiftCardResponse>(mockResponse)).UsingDefaults()
        );
    }
}
