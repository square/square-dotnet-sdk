using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor;

[TestFixture]
public class UpdateScheduledShiftTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "scheduled_shift": {
                "draft_shift_details": {
                  "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                  "location_id": "PAA1RJZZKXBFG",
                  "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                  "start_at": "2019-03-25T08:11:00.000Z",
                  "end_at": "2019-03-25T18:18:00.000Z",
                  "notes": "Dont forget to prep the vegetables",
                  "is_deleted": false
                },
                "version": 1
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
                  "start_at": "2019-03-25T08:11:00.000Z",
                  "end_at": "2019-03-25T18:18:00.000Z",
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

        var response = await Client.Default.Labor.UpdateScheduledShiftAsync(
            new UpdateScheduledShiftRequest
            {
                Id = "id",
                ScheduledShift = new ScheduledShift
                {
                    DraftShiftDetails = new ScheduledShiftDetails
                    {
                        TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
                        LocationId = "PAA1RJZZKXBFG",
                        JobId = "FzbJAtt9qEWncK1BWgVCxQ6M",
                        StartAt = "2019-03-25T03:11:00-05:00",
                        EndAt = "2019-03-25T13:18:00-05:00",
                        Notes = "Dont forget to prep the vegetables",
                        IsDeleted = false,
                    },
                    Version = 1,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateScheduledShiftResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
