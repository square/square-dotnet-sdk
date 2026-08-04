using NUnit.Framework;
using Square.Inventory;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Inventory;

[TestFixture]
public class GetTest : BaseMockServerTest
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
              "counts": [
                {
                  "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                  "catalog_object_type": "ITEM_VARIATION",
                  "state": "IN_STOCK",
                  "location_id": "C6W5YS5QM06F5",
                  "quantity": "22",
                  "calculated_at": "2016-11-16T22:28:01.223Z",
                  "is_estimated": true
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/catalog_object_id")
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

        var items = await Client.Inventory.GetAsync(
            new GetInventoryRequest
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
