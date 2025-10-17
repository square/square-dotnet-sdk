using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Events;

[TestFixture]
public class ListEventTypesTest : BaseMockServerTest
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
              "event_types": [
                "inventory.count.updated"
              ],
              "metadata": [
                {
                  "event_type": "inventory.count.updated",
                  "api_version_introduced": "2018-07-12",
                  "release_status": "PUBLIC"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/events/types")
                    .WithParam("api_version", "api_version")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Events.ListEventTypesAsync(
            new Square.Events.ListEventTypesRequest { ApiVersion = "api_version" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListEventTypesResponse>(mockResponse)).UsingDefaults()
        );
    }
}
