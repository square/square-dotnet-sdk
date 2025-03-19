using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class BatchGetChangesTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "catalog_object_ids": [
                "W62UWFY35CWMYGVWK6TWJDNI"
              ],
              "location_ids": [
                "C6W5YS5QM06F5"
              ],
              "types": [
                "PHYSICAL_COUNT"
              ],
              "states": [
                "IN_STOCK"
              ],
              "updated_after": "2016-11-01T00:00:00.000Z",
              "updated_before": "2016-12-01T00:00:00.000Z"
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
              "changes": [
                {
                  "type": "PHYSICAL_COUNT",
                  "physical_count": {
                    "id": "46YDTW253DWGGK9HMAE6XCAO",
                    "reference_id": "22c07cf4-5626-4224-89f9-691112019399",
                    "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                    "catalog_object_type": "ITEM_VARIATION",
                    "state": "IN_STOCK",
                    "location_id": "C6W5YS5QM06F5",
                    "quantity": "86",
                    "source": {
                      "product": "SQUARE_POS",
                      "application_id": "416ff29c-86c4-4feb-b58c-9705f21f3ea0",
                      "name": "Square Point of Sale 4.37"
                    },
                    "team_member_id": "LRK57NSQ5X7PUD05",
                    "occurred_at": "2016-11-16T22:24:49.028Z",
                    "created_at": "2016-11-16T22:25:24.878Z"
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
                    .WithPath("/v2/inventory/changes/batch-retrieve")
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

        var pager = await Client.Inventory.BatchGetChangesAsync(
            new BatchRetrieveInventoryChangesRequest
            {
                CatalogObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI" },
                LocationIds = new List<string>() { "C6W5YS5QM06F5" },
                Types = new List<InventoryChangeType>() { InventoryChangeType.PhysicalCount },
                States = new List<InventoryState>() { InventoryState.InStock },
                UpdatedAfter = "2016-11-01T00:00:00.000Z",
                UpdatedBefore = "2016-12-01T00:00:00.000Z",
            },
            RequestOptions
        );
        await foreach (var item in pager)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
