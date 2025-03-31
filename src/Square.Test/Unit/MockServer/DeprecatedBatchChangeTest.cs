using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class DeprecatedBatchChangeTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
              "changes": [
                {
                  "type": "PHYSICAL_COUNT",
                  "physical_count": {
                    "reference_id": "1536bfbf-efed-48bf-b17d-a197141b2a92",
                    "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                    "state": "IN_STOCK",
                    "location_id": "C6W5YS5QM06F5",
                    "quantity": "53",
                    "team_member_id": "LRK57NSQ5X7PUD05",
                    "occurred_at": "2016-11-16T22:25:24.878Z"
                  }
                }
              ],
              "ignore_unchanged_counts": true
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
              "counts": [
                {
                  "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                  "catalog_object_type": "ITEM_VARIATION",
                  "state": "IN_STOCK",
                  "location_id": "C6W5YS5QM06F5",
                  "quantity": "53",
                  "calculated_at": "2016-11-16T22:28:01.223Z",
                  "is_estimated": true
                }
              ],
              "changes": [
                {
                  "type": "PHYSICAL_COUNT",
                  "measurement_unit_id": "measurement_unit_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/batch-change")
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

        var response = await Client.Inventory.DeprecatedBatchChangeAsync(
            new BatchChangeInventoryRequest
            {
                IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
                Changes = new List<InventoryChange>()
                {
                    new InventoryChange
                    {
                        Type = InventoryChangeType.PhysicalCount,
                        PhysicalCount = new InventoryPhysicalCount
                        {
                            ReferenceId = "1536bfbf-efed-48bf-b17d-a197141b2a92",
                            CatalogObjectId = "W62UWFY35CWMYGVWK6TWJDNI",
                            State = InventoryState.InStock,
                            LocationId = "C6W5YS5QM06F5",
                            Quantity = "53",
                            TeamMemberId = "LRK57NSQ5X7PUD05",
                            OccurredAt = "2016-11-16T22:25:24.878Z",
                        },
                    },
                },
                IgnoreUnchangedCounts = true,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchChangeInventoryResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
