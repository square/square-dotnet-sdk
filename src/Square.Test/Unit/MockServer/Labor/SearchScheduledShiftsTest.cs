using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor;

[TestFixture]
public class SearchScheduledShiftsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "assignment_status": "ASSIGNED"
                },
                "sort": {
                  "field": "CREATED_AT",
                  "order": "ASC"
                }
              },
              "limit": 2,
              "cursor": "xoxp-1234-5678-90123"
            }
            """;

        const string mockResponse = """
            {
              "scheduled_shifts": [
                {
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
                  "version": 1,
                  "created_at": "2019-02-25T08:11:00.000Z",
                  "updated_at": "2019-02-25T08:11:00.000Z"
                }
              ],
              "cursor": "xoxp-123-2123-123232",
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
                    .WithPath("/v2/labor/scheduled-shifts/search")
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

        var response = await Client.Labor.SearchScheduledShiftsAsync(
            new SearchScheduledShiftsRequest
            {
                Query = new ScheduledShiftQuery
                {
                    Filter = new ScheduledShiftFilter
                    {
                        AssignmentStatus = ScheduledShiftFilterAssignmentStatus.Assigned,
                    },
                    Sort = new ScheduledShiftSort
                    {
                        Field = ScheduledShiftSortField.CreatedAt,
                        Order = SortOrder.Asc,
                    },
                },
                Limit = 2,
                Cursor = "xoxp-1234-5678-90123",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchScheduledShiftsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
