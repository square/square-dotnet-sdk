using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.GiftCards;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class LinkCustomerTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "customer_id": "GKY0FZ3V717AH8Q2D821PNT2ZW"
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
                "id": "gftc:71ea002277a34f8a945e284b04822edb",
                "type": "DIGITAL",
                "gan_source": "SQUARE",
                "state": "ACTIVE",
                "balance_money": {
                  "amount": 2500,
                  "currency": "USD"
                },
                "gan": "7783320005440920",
                "created_at": "2021-03-25T05:13:01.000Z",
                "customer_ids": [
                  "GKY0FZ3V717AH8Q2D821PNT2ZW"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/gift-cards/gift_card_id/link-customer")
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

        var response = await Client.GiftCards.LinkCustomerAsync(
            new LinkCustomerToGiftCardRequest
            {
                GiftCardId = "gift_card_id",
                CustomerId = "GKY0FZ3V717AH8Q2D821PNT2ZW",
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<LinkCustomerToGiftCardResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
