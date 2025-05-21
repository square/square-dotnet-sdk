using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class BulkPublishScheduledShiftsTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "scheduled_shifts": {
                "key": {}
              },
              "scheduled_shift_notification_audience": "AFFECTED"
            }
            """;

        const string mockResponse = """
            {
              "responses": {
                "idp_key_1": {
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
                      "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                      "location_id": "PAA1RJZZKXBFG",
                      "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                      "start_at": "2019-03-25T08:11:00.000Z",
                      "end_at": "2019-03-25T18:18:00.000Z",
                      "notes": "Don't forget to prep the vegetables",
                      "is_deleted": false,
                      "timezone": "America/New_York"
                    },
                    "version": 3,
                    "created_at": "2019-02-25T08:11:00.000Z",
                    "updated_at": "2019-02-25T08:11:15.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "idp_key_2": {
                  "errors": [
                    {
                      "category": "INVALID_REQUEST_ERROR",
                      "code": "INVALID_VALUE",
                      "detail": "Scheduled shift with id 'scheduled-shift-2' not found",
                      "field": "scheduled-shifts.scheduled-shift-2"
                    }
                  ]
                }
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
                    .WithPath("/v2/labor/scheduled-shifts/bulk-publish")
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

        var response = await Client.Labor.BulkPublishScheduledShiftsAsync(
            new BulkPublishScheduledShiftsRequest
            {
                ScheduledShifts = new Dictionary<string, BulkPublishScheduledShiftsData>()
                {
                    { "key", new BulkPublishScheduledShiftsData() },
                },
                ScheduledShiftNotificationAudience = ScheduledShiftNotificationAudience.Affected,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkPublishScheduledShiftsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
