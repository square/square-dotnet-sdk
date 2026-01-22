using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class SearchItemsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "text_filter": "red",
              "category_ids": [
                "WINE_CATEGORY_ID"
              ],
              "stock_levels": [
                "OUT",
                "LOW"
              ],
              "enabled_location_ids": [
                "ATL_LOCATION_ID"
              ],
              "limit": 100,
              "sort_order": "ASC",
              "product_types": [
                "REGULAR"
              ],
              "custom_attribute_filters": [
                {
                  "custom_attribute_definition_id": "VEGAN_DEFINITION_ID",
                  "bool_filter": true
                },
                {
                  "custom_attribute_definition_id": "BRAND_DEFINITION_ID",
                  "string_filter": "Dark Horse"
                },
                {
                  "key": "VINTAGE",
                  "number_filter": {
                    "min": "min",
                    "max": "max"
                  }
                },
                {
                  "custom_attribute_definition_id": "VARIETAL_DEFINITION_ID"
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
              "items": [
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
              "cursor": "cursor",
              "matched_variation_ids": [
                "VBJNPHCOKDFECR6VU25WRJUD"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/search-catalog-items")
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

        var response = await Client.Default.Catalog.SearchItemsAsync(
            new SearchCatalogItemsRequest
            {
                TextFilter = "red",
                CategoryIds = new List<string>() { "WINE_CATEGORY_ID" },
                StockLevels = new List<SearchCatalogItemsRequestStockLevel>()
                {
                    SearchCatalogItemsRequestStockLevel.Out,
                    SearchCatalogItemsRequestStockLevel.Low,
                },
                EnabledLocationIds = new List<string>() { "ATL_LOCATION_ID" },
                Limit = 100,
                SortOrder = SortOrder.Asc,
                ProductTypes = new List<CatalogItemProductType>()
                {
                    CatalogItemProductType.Regular,
                },
                CustomAttributeFilters = new List<CustomAttributeFilter>()
                {
                    new CustomAttributeFilter
                    {
                        CustomAttributeDefinitionId = "VEGAN_DEFINITION_ID",
                        BoolFilter = true,
                    },
                    new CustomAttributeFilter
                    {
                        CustomAttributeDefinitionId = "BRAND_DEFINITION_ID",
                        StringFilter = "Dark Horse",
                    },
                    new CustomAttributeFilter
                    {
                        Key = "VINTAGE",
                        NumberFilter = new Square.Default.Range { Min = "min", Max = "max" },
                    },
                    new CustomAttributeFilter
                    {
                        CustomAttributeDefinitionId = "VARIETAL_DEFINITION_ID",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchCatalogItemsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
