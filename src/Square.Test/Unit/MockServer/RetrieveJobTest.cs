using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Team;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RetrieveJobTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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

        var response = await Client.Team.RetrieveJobAsync(
            new RetrieveJobRequest { JobId = "job_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveJobResponse>(mockResponse)).UsingDefaults()
        );
    }
}
