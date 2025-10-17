using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Catalog;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog;

[TestFixture]
public class BatchDeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "object_ids": [
                "W62UWFY35CWMYGVWK6TWJDNI",
                "AA27W3M2GGTF3H6AVPNB77CK"
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
              "deleted_object_ids": [
                "W62UWFY35CWMYGVWK6TWJDNI",
                "AA27W3M2GGTF3H6AVPNB77CK"
              ],
              "deleted_at": "2016-11-16T22:25:24.878Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/batch-delete")
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

        var response = await Client.Catalog.BatchDeleteAsync(
            new BatchDeleteCatalogObjectsRequest
            {
                ObjectIds = new List<string>()
                {
                    "W62UWFY35CWMYGVWK6TWJDNI",
                    "AA27W3M2GGTF3H6AVPNB77CK",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchDeleteCatalogObjectsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
