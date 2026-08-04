using NUnit.Framework;
using Square;
using Square.Catalog;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "object_types": [
                "ITEM"
              ],
              "query": {
                "prefix_query": {
                  "attribute_name": "name",
                  "attribute_prefix": "tea"
                }
              },
              "limit": 100
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
                  "type": "ITEM"
                }
              ],
              "latest_time": "latest_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/search")
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

        var response = await Client.Catalog.SearchAsync(
            new SearchCatalogObjectsRequest
            {
                ObjectTypes = new List<CatalogObjectType>() { CatalogObjectType.Item },
                Query = new CatalogQuery
                {
                    PrefixQuery = new CatalogQueryPrefix
                    {
                        AttributeName = "name",
                        AttributePrefix = "tea",
                    },
                },
                Limit = 100,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchCatalogObjectsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
