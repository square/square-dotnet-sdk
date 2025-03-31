using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.GiftCards;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class GetFromGanTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "gan": "7783320001001635"
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
                "id": "gftc:6944163553804e439d89adb47caf806a",
                "type": "DIGITAL",
                "gan_source": "SQUARE",
                "state": "ACTIVE",
                "balance_money": {
                  "amount": 5000,
                  "currency": "USD"
                },
                "gan": "7783320001001635",
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
                    .WithPath("/v2/gift-cards/from-gan")
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

        var response = await Client.GiftCards.GetFromGanAsync(
            new GetGiftCardFromGanRequest { Gan = "7783320001001635" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetGiftCardFromGanResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
