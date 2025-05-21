using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RetrieveScheduledShiftTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "scheduled_shift": {
                "id": "K0YH4CV5462JB",
                "draft_shift_details": {
                  "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                  "location_id": "PAA1RJZZKXBFG",
                  "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                  "start_at": "2019-03-25T08:11:00.000Z",
                  "end_at": "2019-03-25T18:18:00.000Z",
                  "notes": "Don't forget to prep the vegetables",
                  "is_deleted": false,
                  "timezone": "America/New_York"
                },
                "published_shift_details": {
                  "team_member_id": "team_member_id",
                  "location_id": "location_id",
                  "job_id": "job_id",
                  "start_at": "start_at",
                  "end_at": "end_at",
                  "notes": "notes",
                  "is_deleted": true,
                  "timezone": "timezone"
                },
                "version": 2,
                "created_at": "2019-02-25T08:11:00.000Z",
                "updated_at": "2019-02-25T08:11:15.000Z"
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
                    .WithPath("/v2/labor/scheduled-shifts/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.RetrieveScheduledShiftAsync(
            new RetrieveScheduledShiftRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveScheduledShiftResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
