using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class BatchGetCountsTest : BaseMockServerTest
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
                "59TNP9SA8VGDA"
              ],
              "updated_after": "2016-11-16T00:00:00.000Z"
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
                  "location_id": "59TNP9SA8VGDA",
                  "quantity": "79",
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
                    .WithPath("/v2/inventory/counts/batch-retrieve")
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

        var pager = await Client.Inventory.BatchGetCountsAsync(
            new BatchGetInventoryCountsRequest
            {
                CatalogObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI" },
                LocationIds = new List<string>() { "59TNP9SA8VGDA" },
                UpdatedAfter = "2016-11-16T00:00:00.000Z",
            }
        );
        await foreach (var item in pager)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
