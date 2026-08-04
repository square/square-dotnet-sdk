using NUnit.Framework;
using Square;
using Square.Catalog;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class BatchUpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "789ff020-f723-43a9-b4b5-43b5dc1fa3dc",
              "batches": [
                {
                  "objects": [
                    {
                      "id": "id",
                      "type": "ITEM"
                    },
                    {
                      "id": "id",
                      "type": "ITEM"
                    },
                    {
                      "id": "id",
                      "type": "ITEM"
                    },
                    {
                      "id": "id",
                      "type": "TAX"
                    }
                  ]
                }
              ]
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
              ],
              "updated_at": "updated_at",
              "id_mappings": [
                {
                  "client_object_id": "#Tea",
                  "object_id": "67GA7XA2FWMRYY2VCONTYZJR"
                },
                {
                  "client_object_id": "#Coffee",
                  "object_id": "MQ4TZKOG3SR2EQI3TWEK4AH7"
                },
                {
                  "client_object_id": "#Beverages",
                  "object_id": "XCS4SCGN4WQYE2VU4U3TKXEH"
                },
                {
                  "client_object_id": "#SalesTax",
                  "object_id": "HP5VNYPKZKTNCKZ2Z5NPUH6A"
                },
                {
                  "client_object_id": "#Tea_Mug",
                  "object_id": "CAJBHUIQH7ONTSZI2KTVOUP6"
                },
                {
                  "client_object_id": "#Coffee_Regular",
                  "object_id": "GY2GXJTVVPQAPW43GFRR3NG6"
                },
                {
                  "client_object_id": "#Coffee_Large",
                  "object_id": "JE6VHPSRQL6IWSN26C36CJ7W"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/batch-upsert")
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

        var response = await Client.Catalog.BatchUpsertAsync(
            new BatchUpsertCatalogObjectsRequest
            {
                IdempotencyKey = "789ff020-f723-43a9-b4b5-43b5dc1fa3dc",
                Batches = new List<CatalogObjectBatch>()
                {
                    new CatalogObjectBatch
                    {
                        Objects = new List<CatalogObject>()
                        {
                            new CatalogObject(
                                new CatalogObject.Item(new CatalogObjectItem { Id = "id" })
                            ),
                            new CatalogObject(
                                new CatalogObject.Item(new CatalogObjectItem { Id = "id" })
                            ),
                            new CatalogObject(
                                new CatalogObject.Item(new CatalogObjectItem { Id = "id" })
                            ),
                            new CatalogObject(
                                new CatalogObject.Tax(new CatalogObjectTax { Id = "id" })
                            ),
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchUpsertCatalogObjectsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
