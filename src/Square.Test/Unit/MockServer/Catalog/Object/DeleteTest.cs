using NUnit.Framework;
using Square;
using Square.Catalog.Object;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Catalog.Object;

[TestFixture]
public class DeleteTest : BaseMockServerTest
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
              "deleted_object_ids": [
                "7SB3ZQYJ5GDMVFL7JK46JCHT",
                "KQLFFHA6K6J3YQAQAWDQAL57"
              ],
              "deleted_at": "2016-11-16T22:25:24.878Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/catalog/object/object_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.Object.DeleteAsync(
            new DeleteObjectRequest { ObjectId = "object_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteCatalogObjectResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
