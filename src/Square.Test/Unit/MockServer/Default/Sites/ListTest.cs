using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Sites;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "sites": [
                {
                  "id": "site_278075276488921835",
                  "site_title": "My Second Site",
                  "domain": "mysite2.square.site",
                  "is_published": false,
                  "created_at": "2020-10-28T13:22:51.000Z",
                  "updated_at": "2020-10-28T13:22:51.000Z"
                },
                {
                  "id": "site_102725345836253849",
                  "site_title": "My First Site",
                  "domain": "mysite1.square.site",
                  "is_published": true,
                  "created_at": "2020-06-18T17:45:13.000Z",
                  "updated_at": "2020-11-23T02:19:10.000Z"
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/sites").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Sites.ListAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListSitesResponse>(mockResponse)).UsingDefaults()
        );
    }
}
