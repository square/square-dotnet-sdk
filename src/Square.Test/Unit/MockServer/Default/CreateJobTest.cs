using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class CreateJobTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "job": {
                "title": "Cashier",
                "is_tip_eligible": true
              },
              "idempotency_key": "idempotency-key-0"
            }
            """;

        const string mockResponse = """
            {
              "job": {
                "id": "1yJlHapkseYnNPETIU1B",
                "title": "Cashier",
                "is_tip_eligible": true,
                "created_at": "2021-06-11T22:55:45.000Z",
                "updated_at": "2021-06-11T22:55:45.000Z",
                "version": 1
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
                    .WithPath("/v2/team-members/jobs")
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

        var response = await Client.Default.Team.CreateJobAsync(
            new CreateJobRequest
            {
                Job = new Job { Title = "Cashier", IsTipEligible = true },
                IdempotencyKey = "idempotency-key-0",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateJobResponse>(mockResponse)).UsingDefaults()
        );
    }
}
