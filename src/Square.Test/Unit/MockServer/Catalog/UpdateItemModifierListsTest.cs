using NUnit.Framework;
using Square;
using Square.Catalog;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class UpdateItemModifierListsTest : BaseMockServerTest
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
              "modifier_lists_to_enable": [
                "H42BRLUJ5KTZTTMPVSLFAACQ",
                "2JXOBJIHCWBQ4NZ3RIXQGJA6"
              ],
              "modifier_lists_to_disable": [
                "7WRC16CJZDVLSNDQ35PP6YAD"
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
                    .WithPath("/v2/catalog/update-item-modifier-lists")
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

        var response = await Client.Catalog.UpdateItemModifierListsAsync(
            new UpdateItemModifierListsRequest
            {
                ItemIds = new List<string>()
                {
                    "H42BRLUJ5KTZTTMPVSLFAACQ",
                    "2JXOBJIHCWBQ4NZ3RIXQGJA6",
                },
                ModifierListsToEnable = new List<string>()
                {
                    "H42BRLUJ5KTZTTMPVSLFAACQ",
                    "2JXOBJIHCWBQ4NZ3RIXQGJA6",
                },
                ModifierListsToDisable = new List<string>() { "7WRC16CJZDVLSNDQ35PP6YAD" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateItemModifierListsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
