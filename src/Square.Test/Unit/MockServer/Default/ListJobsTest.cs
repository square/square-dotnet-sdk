using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class ListJobsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "jobs": [
                {
                  "id": "VDNpRv8da51NU8qZFC5zDWpF",
                  "title": "Cashier",
                  "is_tip_eligible": true,
                  "created_at": "2021-06-11T22:55:45.000Z",
                  "updated_at": "2021-06-11T22:55:45.000Z",
                  "version": 2
                },
                {
                  "id": "FjS8x95cqHiMenw4f1NAUH4P",
                  "title": "Chef",
                  "is_tip_eligible": false,
                  "created_at": "2021-06-11T22:55:45.000Z",
                  "updated_at": "2021-06-11T22:55:45.000Z",
                  "version": 1
                }
              ],
              "cursor": "cursor",
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
                    .WithPath("/v2/team-members/jobs")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Team.ListJobsAsync(
            new ListJobsRequest { Cursor = "cursor" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListJobsResponse>(mockResponse)).UsingDefaults()
        );
    }
}
