using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Inventory;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class GetTransferTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
              "transfer": {
                "id": "UDMOEO78BG6GYWA2XDRYX3KB",
                "reference_id": "4a366069-4096-47a2-99a5-0084ac879509",
                "state": "IN_STOCK",
                "from_location_id": "C6W5YS5QM06F5",
                "to_location_id": "59TNP9SA8VGDA",
                "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                "catalog_object_type": "ITEM_VARIATION",
                "quantity": "7",
                "occurred_at": "2016-11-16T25:44:22.837Z",
                "created_at": "2016-11-17T13:02:15.142Z",
                "source": {
                  "product": "SQUARE_POS",
                  "application_id": "416ff29c-86c4-4feb-b58c-9705f21f3ea0",
                  "name": "Square Point of Sale 4.37"
                },
                "employee_id": "employee_id",
                "team_member_id": "LRK57NSQ5X7PUD05"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/transfers/transfer_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Inventory.GetTransferAsync(
            new GetTransferInventoryRequest { TransferId = "transfer_id" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetInventoryTransferResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
