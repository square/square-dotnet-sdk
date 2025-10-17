using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Inventory;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Inventory;

[TestFixture]
public class GetPhysicalCountTest : BaseMockServerTest
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
              "count": {
                "id": "ANZADNPLKADOJKJIUANKLMLQ",
                "reference_id": "f857ec37-f9a0-4458-8e23-5b5e0bea4e53",
                "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                "catalog_object_type": "ITEM_VARIATION",
                "state": "IN_STOCK",
                "location_id": "C6W5YS5QM06F5",
                "quantity": "15",
                "source": {
                  "product": "SQUARE_POS",
                  "application_id": "416ff29c-86c4-4feb-b58c-9705f21f3ea0",
                  "name": "Square Point of Sale 4.37"
                },
                "employee_id": "employee_id",
                "team_member_id": "LRK57NSQ5X7PUD05",
                "occurred_at": "2016-11-16T22:25:24.878Z",
                "created_at": "2016-11-16T22:25:24.878Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/physical-counts/physical_count_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Inventory.GetPhysicalCountAsync(
            new GetPhysicalCountInventoryRequest { PhysicalCountId = "physical_count_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetInventoryPhysicalCountResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
