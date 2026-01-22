using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Catalog;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Catalog;

[TestFixture]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "af3d1afc-7212-4300-b463-0bfc5314a5ae",
              "object": {
                "id": "id",
                "type": "ITEM"
              }
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
              "catalog_object": {
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
                "item_data": {
                  "name": "name",
                  "description": "description",
                  "abbreviation": "abbreviation",
                  "label_color": "label_color",
                  "is_taxable": true,
                  "category_id": "category_id",
                  "buyer_facing_name": "buyer_facing_name",
                  "tax_ids": [
                    "tax_ids"
                  ],
                  "modifier_list_info": [
                    {
                      "modifier_list_id": "modifier_list_id"
                    }
                  ],
                  "product_type": "REGULAR",
                  "skip_modifier_screen": true,
                  "item_options": [
                    {}
                  ],
                  "ecom_uri": "ecom_uri",
                  "ecom_image_uris": [
                    "ecom_image_uris"
                  ],
                  "image_ids": [
                    "image_ids"
                  ],
                  "sort_name": "sort_name",
                  "description_html": "description_html",
                  "description_plaintext": "description_plaintext",
                  "kitchen_name": "kitchen_name",
                  "channels": [
                    "channels"
                  ],
                  "is_archived": true,
                  "is_alcoholic": true
                },
                "type": "ITEM"
              },
              "id_mappings": [
                {
                  "client_object_id": "#Cocoa",
                  "object_id": "R2TA2FOBUGCJZNIWJSOSNAI4"
                },
                {
                  "client_object_id": "#Small",
                  "object_id": "QRT53UP4LITLWGOGBZCUWP63"
                },
                {
                  "client_object_id": "#Large",
                  "object_id": "NS77DKEIQ3AEQTCP727DSA7U"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/object")
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

        var response = await Client.Default.Catalog.Object.UpsertAsync(
            new UpsertCatalogObjectRequest
            {
                IdempotencyKey = "af3d1afc-7212-4300-b463-0bfc5314a5ae",
                Object = new CatalogObject(
                    new CatalogObject.Item(new CatalogObjectItem { Id = "id" })
                ),
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpsertCatalogObjectResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
