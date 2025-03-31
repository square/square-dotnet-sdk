using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Team;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class UpdateJobTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "job": {
                "title": "Cashier 1",
                "is_tip_eligible": true
              }
            }
            """;

        const string mockResponse = """
            {
              "job": {
                "id": "1yJlHapkseYnNPETIU1B",
                "title": "Cashier 1",
                "is_tip_eligible": true,
                "created_at": "2021-06-11T22:55:45.000Z",
                "updated_at": "2021-06-13T12:55:45.000Z",
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
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.UpdateJobAsync(
            new UpdateJobRequest
            {
                JobId = "job_id",
                Job = new Job { Title = "Cashier 1", IsTipEligible = true },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateJobResponse>(mockResponse)).UsingDefaults()
        );
    }
}
