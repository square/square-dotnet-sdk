using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Programs;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class CalculateTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CalculateLoyaltyPointsResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
