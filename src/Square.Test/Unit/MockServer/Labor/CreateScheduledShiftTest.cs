using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor;

[TestFixture]
public class CreateScheduledShiftTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "HIDSNG5KS478L",
              "scheduled_shift": {
                "draft_shift_details": {
                  "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                  "location_id": "PAA1RJZZKXBFG",
                  "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                  "start_at": "2019-01-25T08:11:00.000Z",
                  "end_at": "2019-01-25T18:11:00.000Z",
                  "notes": "Dont forget to prep the vegetables",
                  "is_deleted": false
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "scheduled_shift": {
                "id": "K0YH4CV5462JB",
                "draft_shift_details": {
                  "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                  "location_id": "PAA1RJZZKXBFG",
                  "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                  "start_at": "2019-01-25T08:11:00.000Z",
                  "end_at": "2019-01-25T18:11:00.000Z",
                  "notes": "Dont forget to prep the vegetables",
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
                "version": 1,
                "created_at": "2019-02-25T08:11:00.000Z",
                "updated_at": "2019-02-25T08:11:00.000Z"
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
                    .WithPath("/v2/labor/scheduled-shifts")
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

        var response = await Client.Labor.CreateScheduledShiftAsync(
            new CreateScheduledShiftRequest
            {
                IdempotencyKey = "HIDSNG5KS478L",
                ScheduledShift = new ScheduledShift
                {
                    DraftShiftDetails = new ScheduledShiftDetails
                    {
                        TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
                        LocationId = "PAA1RJZZKXBFG",
                        JobId = "FzbJAtt9qEWncK1BWgVCxQ6M",
                        StartAt = "2019-01-25T03:11:00-05:00",
                        EndAt = "2019-01-25T13:11:00-05:00",
                        Notes = "Dont forget to prep the vegetables",
                        IsDeleted = false,
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateScheduledShiftResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
