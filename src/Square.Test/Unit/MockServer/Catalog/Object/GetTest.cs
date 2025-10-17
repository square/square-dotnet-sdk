using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Catalog.Object;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog.Object;

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
              "object": {
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
                  "channels": [
                    "channels"
                  ],
                  "is_archived": true,
                  "is_alcoholic": true
                },
                "type": "ITEM"
              },
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
                    .WithPath("/v2/catalog/object/object_id")
                    .WithParam("catalog_version", "1000000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.Object.GetAsync(
            new GetObjectRequest
            {
                ObjectId = "object_id",
                IncludeRelatedObjects = true,
                CatalogVersion = 1000000,
                IncludeCategoryPathToRoot = true,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetCatalogObjectResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
