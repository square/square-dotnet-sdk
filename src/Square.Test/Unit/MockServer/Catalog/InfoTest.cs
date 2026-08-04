using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class InfoTest : BaseMockServerTest
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
              "limits": {
                "batch_upsert_max_objects_per_batch": 1000,
                "batch_upsert_max_total_objects": 10000,
                "batch_retrieve_max_object_ids": 1000,
                "search_max_page_limit": 1000,
                "batch_delete_max_object_ids": 200,
                "update_item_taxes_max_item_ids": 1000,
                "update_item_taxes_max_taxes_to_enable": 1000,
                "update_item_taxes_max_taxes_to_disable": 1000,
                "update_item_modifier_lists_max_item_ids": 1000,
                "update_item_modifier_lists_max_modifier_lists_to_enable": 1000,
                "update_item_modifier_lists_max_modifier_lists_to_disable": 1000
              },
              "standard_unit_description_group": {
                "standard_unit_descriptions": [
                  {}
                ],
                "language_code": "language_code"
              }
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/v2/catalog/info").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.InfoAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CatalogInfoResponse>(mockResponse)).UsingDefaults()
        );
    }
}
