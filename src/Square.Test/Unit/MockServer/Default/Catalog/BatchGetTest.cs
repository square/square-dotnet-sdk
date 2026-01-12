using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Catalog;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Catalog;

[TestFixture]
public class BatchGetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "object_ids": [
                "W62UWFY35CWMYGVWK6TWJDNI",
                "AA27W3M2GGTF3H6AVPNB77CK"
              ],
              "include_related_objects": true
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
                  "type": "ITEM"
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
                  "type": "ITEM"
                }
              ],
              "related_objects": [
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
                    .WithPath("/v2/catalog/batch-retrieve")
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

        var response = await Client.Default.Catalog.BatchGetAsync(
            new BatchGetCatalogObjectsRequest
            {
                ObjectIds = new List<string>()
                {
                    "W62UWFY35CWMYGVWK6TWJDNI",
                    "AA27W3M2GGTF3H6AVPNB77CK",
                },
                IncludeRelatedObjects = true,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchGetCatalogObjectsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
