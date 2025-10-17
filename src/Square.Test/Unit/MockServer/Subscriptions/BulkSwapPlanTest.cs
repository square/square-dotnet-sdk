using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Subscriptions;

[TestFixture]
public class BulkSwapPlanTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "new_plan_variation_id": "FQ7CDXXWSLUJRPM3GFJSJGZ7",
              "old_plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H",
              "location_id": "S8GWD5R9QB376"
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
              "affected_subscriptions": 12
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/bulk-swap-plan")
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

        var response = await Client.Subscriptions.BulkSwapPlanAsync(
            new BulkSwapPlanRequest
            {
                NewPlanVariationId = "FQ7CDXXWSLUJRPM3GFJSJGZ7",
                OldPlanVariationId = "6JHXF3B2CW3YKHDV4XEM674H",
                LocationId = "S8GWD5R9QB376",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkSwapPlanResponse>(mockResponse)).UsingDefaults()
        );
    }
}
