using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Snippets;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Snippets;

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
              "snippet": {
                "id": "snippet_5d178150-a6c0-11eb-a9f1-437e6a2881e7",
                "site_id": "site_278075276488921835",
                "content": "<script>var js = 1;</script>",
                "created_at": "2021-03-11T25:40:09.000000Z",
                "updated_at": "2021-03-11T25:40:09.000000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/sites/site_id/snippet")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Snippets.GetAsync(
            new GetSnippetsRequest { SiteId = "site_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetSnippetResponse>(mockResponse)).UsingDefaults()
        );
    }
}
