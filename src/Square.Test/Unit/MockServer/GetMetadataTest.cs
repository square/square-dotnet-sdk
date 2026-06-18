using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class GetMetadataTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "cubes": [
                {
                  "name": "name",
                  "title": "title",
                  "type": "cube",
                  "meta": {
                    "key": "value"
                  },
                  "description": "description",
                  "measures": [
                    {
                      "name": "name",
                      "type": "type"
                    }
                  ],
                  "dimensions": [
                    {
                      "name": "name",
                      "type": "type"
                    }
                  ],
                  "segments": [
                    {
                      "name": "name",
                      "title": "title",
                      "shortTitle": "shortTitle"
                    }
                  ],
                  "joins": [
                    {
                      "name": "name",
                      "relationship": "relationship"
                    }
                  ],
                  "folders": [
                    {
                      "name": "name",
                      "members": [
                        "members"
                      ]
                    }
                  ],
                  "nestedFolders": [
                    {
                      "name": "name",
                      "members": [
                        "members"
                      ]
                    }
                  ],
                  "hierarchies": [
                    {
                      "name": "name",
                      "levels": [
                        "levels"
                      ]
                    }
                  ]
                }
              ],
              "compilerId": "compilerId"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/reporting/v1/meta").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Reporting.GetMetadataAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MetadataResponse>(mockResponse)).UsingDefaults()
        );
    }
}
