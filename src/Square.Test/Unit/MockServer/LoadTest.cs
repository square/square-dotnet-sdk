using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class LoadTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "dataSource": "dataSource",
              "annotation": {
                "measures": {
                  "key": "value"
                },
                "dimensions": {
                  "key": "value"
                },
                "segments": {
                  "key": "value"
                },
                "timeDimensions": {
                  "key": "value"
                }
              },
              "data": [
                {
                  "key": "value"
                }
              ],
              "lastRefreshTime": "lastRefreshTime",
              "query": {
                "key": "value"
              },
              "slowQuery": true,
              "external": true,
              "dbType": "dbType",
              "refreshKeyValues": [
                {
                  "key": "value"
                }
              ],
              "pivotQuery": {
                "key": "value"
              },
              "queryType": "queryType"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/reporting/v1/load")
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

        var response = await Client.Reporting.LoadAsync(new LoadRequest());
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<LoadResponse>(mockResponse)).UsingDefaults()
        );
    }
}
