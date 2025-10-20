using System.Threading.Tasks;
using NUnit.Framework;
using Square.Catalog;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "cursor": "cursor",
              "objects": [
                {
                  "id": "id",
                  "updated_at": "updated_at",
                  "version": 1000000,
                  "is_deleted": true,
                  "custom_attribute_values": {
                    "key": {}
                  },
                  "catalog_v1_ids": [
                    {}
                  ],
                  "present_at_all_locations": true,
                  "present_at_location_ids": [
                    "present_at_location_ids"
                  ],
                  "absent_at_location_ids": [
                    "absent_at_location_ids"
                  ],
                  "image_id": "image_id",
                  "ordinal": 1000000,
                  "type": "CATEGORY"
                },
                {
                  "id": "id",
                  "updated_at": "updated_at",
                  "version": 1000000,
                  "is_deleted": true,
                  "custom_attribute_values": {
                    "key": {}
                  },
                  "catalog_v1_ids": [
                    {}
                  ],
                  "present_at_all_locations": true,
                  "present_at_location_ids": [
                    "present_at_location_ids"
                  ],
                  "absent_at_location_ids": [
                    "absent_at_location_ids"
                  ],
                  "image_id": "image_id",
                  "type": "TAX"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/list")
                    .WithParam("cursor", "cursor")
                    .WithParam("types", "types")
                    .WithParam("catalog_version", "1000000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Catalog.ListAsync(
            new ListCatalogRequest
            {
                Cursor = "cursor",
                Types = "types",
                CatalogVersion = 1000000,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
