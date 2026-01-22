using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Programs;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Loyalty.Programs;

[TestFixture]
public class CalculateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "order_id": "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
              "loyalty_account_id": "79b807d2-d786-46a9-933b-918028d7a8c5"
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
              "points": 6,
              "promotion_points": 12
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/programs/program_id/calculate")
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

        var response = await Client.Loyalty.Programs.CalculateAsync(
            new CalculateLoyaltyPointsRequest
            {
                ProgramId = "program_id",
                OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
                LoyaltyAccountId = "79b807d2-d786-46a9-933b-918028d7a8c5",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CalculateLoyaltyPointsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
