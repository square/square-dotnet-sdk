using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor;

[TestFixture]
public class PublishScheduledShiftTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "HIDSNG5KS478L",
              "version": 2,
              "scheduled_shift_notification_audience": "ALL"
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
                  "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                  "location_id": "PAA1RJZZKXBFG",
                  "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                  "start_at": "2019-01-25T08:11:00.000Z",
                  "end_at": "2019-01-25T18:11:00.000Z",
                  "notes": "Dont forget to prep the vegetables",
                  "is_deleted": false,
                  "timezone": "America/New_York"
                },
                "version": 2,
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
                    .WithPath("/v2/labor/scheduled-shifts/id/publish")
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

        var response = await Client.Labor.PublishScheduledShiftAsync(
            new PublishScheduledShiftRequest
            {
                Id = "id",
                IdempotencyKey = "HIDSNG5KS478L",
                Version = 2,
                ScheduledShiftNotificationAudience = ScheduledShiftNotificationAudience.All,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PublishScheduledShiftResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
