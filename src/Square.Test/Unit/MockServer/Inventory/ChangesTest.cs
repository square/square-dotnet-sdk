using System.Threading.Tasks;
using NUnit.Framework;
using Square.Inventory;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Inventory;

[TestFixture]
public class ChangesTest : BaseMockServerTest
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
              "changes": [
                {
                  "type": "ADJUSTMENT",
                  "adjustment": {
                    "id": "OJKJIUANKLMLQANZADNPLKAD",
                    "reference_id": "d8207693-168f-4b44-a2fd-a7ff533ddd26",
                    "from_state": "IN_STOCK",
                    "to_state": "SOLD",
                    "location_id": "C6W5YS5QM06F5",
                    "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                    "catalog_object_type": "ITEM_VARIATION",
                    "quantity": "3",
                    "total_price_money": {
                      "amount": 5000,
                      "currency": "USD"
                    },
                    "occurred_at": "2016-11-16T22:25:24.878Z",
                    "created_at": "2016-11-16T22:25:24.878Z",
                    "source": {
                      "product": "SQUARE_POS",
                      "application_id": "416ff29c-86c4-4feb-b58c-9705f21f3ea0",
                      "name": "Square Point of Sale 4.37"
                    },
                    "team_member_id": "AV7YRCGI2H1J5NQ8E1XIZCNA",
                    "transaction_id": "5APV6JYK1SNCZD11AND2RX1Z"
                  },
                  "measurement_unit_id": "measurement_unit_id"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/catalog_object_id/changes")
                    .WithParam("location_ids", "location_ids")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Inventory.ChangesAsync(
            new ChangesInventoryRequest
            {
                CatalogObjectId = "catalog_object_id",
                LocationIds = "location_ids",
                Cursor = "cursor",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
