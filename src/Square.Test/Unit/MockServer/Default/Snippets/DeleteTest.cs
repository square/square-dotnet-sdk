using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Snippets;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Snippets;

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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/sites/site_id/snippet")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Snippets.DeleteAsync(
            new DeleteSnippetsRequest { SiteId = "site_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteSnippetResponse>(mockResponse)).UsingDefaults()
        );
    }
}
