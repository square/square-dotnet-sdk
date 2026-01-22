using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class RetrieveJobTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "job": {
                "id": "1yJlHapkseYnNPETIU1B",
                "title": "Cashier 1",
                "is_tip_eligible": true,
                "created_at": "2021-06-11T22:55:45.000Z",
                "updated_at": "2021-06-11T22:55:45.000Z",
                "version": 2
              },
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
                    .WithPath("/v2/team-members/jobs/job_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Team.RetrieveJobAsync(
            new RetrieveJobRequest { JobId = "job_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveJobResponse>(mockResponse)).UsingDefaults()
        );
    }
}
