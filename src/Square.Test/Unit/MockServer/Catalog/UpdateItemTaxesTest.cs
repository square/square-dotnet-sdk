using NUnit.Framework;
using Square;
using Square.Catalog;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class UpdateItemTaxesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "item_ids": [
                "H42BRLUJ5KTZTTMPVSLFAACQ",
                "2JXOBJIHCWBQ4NZ3RIXQGJA6"
              ],
              "taxes_to_enable": [
                "4WRCNHCJZDVLSNDQ35PP6YAD"
              ],
              "taxes_to_disable": [
                "AQCEGCEBBQONINDOHRGZISEX"
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
              "updated_at": "2016-11-16T22:25:24.878Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/update-item-taxes")
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

        var response = await Client.Catalog.UpdateItemTaxesAsync(
            new UpdateItemTaxesRequest
            {
                ItemIds = new List<string>()
                {
                    "H42BRLUJ5KTZTTMPVSLFAACQ",
                    "2JXOBJIHCWBQ4NZ3RIXQGJA6",
                },
                TaxesToEnable = new List<string>() { "4WRCNHCJZDVLSNDQ35PP6YAD" },
                TaxesToDisable = new List<string>() { "AQCEGCEBBQONINDOHRGZISEX" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateItemTaxesResponse>(mockResponse)).UsingDefaults()
        );
    }
}
