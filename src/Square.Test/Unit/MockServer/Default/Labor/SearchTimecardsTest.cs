using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor;

[TestFixture]
public class SearchTimecardsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "workday": {
                    "date_range": {
                      "start_date": "2019-01-20",
                      "end_date": "2019-02-03"
                    },
                    "match_timecards_by": "START_AT",
                    "default_timezone": "America/Los_Angeles"
                  }
                }
              },
              "limit": 100
            }
            """;

        const string mockResponse = """
            {
              "timecards": [
                {
                  "id": "X714F3HA6D1PT",
                  "location_id": "PAA1RJZZKXBFG",
                  "timezone": "America/New_York",
                  "start_at": "2019-01-21T08:11:00.000Z",
                  "end_at": "2019-01-21T18:11:00.000Z",
                  "wage": {
                    "title": "Barista",
                    "hourly_rate": {
                      "amount": 1100,
                      "currency": "USD"
                    },
                    "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                    "tip_eligible": true
                  },
                  "breaks": [
                    {
                      "id": "SJW7X6AKEJQ65",
                      "start_at": "2019-01-21T11:11:00.000Z",
                      "end_at": "2019-01-21T11:11:00.000Z",
                      "break_type_id": "REGS1EQR1TPZ5",
                      "name": "Tea Break",
                      "expected_duration": "PT10M",
                      "is_paid": true
                    }
                  ],
                  "status": "CLOSED",
                  "version": 6,
                  "created_at": "2019-01-24T01:12:03.000Z",
                  "updated_at": "2019-02-07T22:21:08.000Z",
                  "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                  "declared_cash_tip_money": {
                    "amount": 500,
                    "currency": "USD"
                  }
                },
                {
                  "id": "GDHYBZYWK0P2V",
                  "location_id": "PAA1RJZZKXBFG",
                  "timezone": "America/New_York",
                  "start_at": "2019-01-22T17:02:00.000Z",
                  "end_at": "2019-01-22T18:02:00.000Z",
                  "wage": {
                    "title": "Cook",
                    "hourly_rate": {
                      "amount": 1600,
                      "currency": "USD"
                    },
                    "job_id": "gcbz15vKGnMKmaWJJ152kjim",
                    "tip_eligible": true
                  },
                  "breaks": [
                    {
                      "id": "BKS6VR7WR748A",
                      "start_at": "2019-01-22T19:30:00.000Z",
                      "end_at": "2019-01-22T19:40:00.000Z",
                      "break_type_id": "WQX00VR99F53J",
                      "name": "Tea Break",
                      "expected_duration": "PT10M",
                      "is_paid": true
                    },
                    {
                      "id": "BQFEZSHFZSC51",
                      "start_at": "2019-01-22T17:30:00.000Z",
                      "end_at": "2019-01-22T17:44:00.000Z",
                      "break_type_id": "P6Q468ZFRN1AC",
                      "name": "Coffee Break",
                      "expected_duration": "PT15M",
                      "is_paid": false
                    }
                  ],
                  "status": "CLOSED",
                  "version": 16,
                  "created_at": "2019-01-23T23:32:45.000Z",
                  "updated_at": "2019-01-24T00:56:25.000Z",
                  "team_member_id": "33fJchumvVdJwxV0H6L9",
                  "declared_cash_tip_money": {
                    "amount": 0,
                    "currency": "USD"
                  }
                }
              ],
              "cursor": "cursor",
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
                    .WithPath("/v2/labor/timecards/search")
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

        var response = await Client.Default.Labor.SearchTimecardsAsync(
            new SearchTimecardsRequest
            {
                Query = new TimecardQuery
                {
                    Filter = new TimecardFilter
                    {
                        Workday = new TimecardWorkday
                        {
                            DateRange = new DateRange
                            {
                                StartDate = "2019-01-20",
                                EndDate = "2019-02-03",
                            },
                            MatchTimecardsBy = TimecardWorkdayMatcher.StartAt,
                            DefaultTimezone = "America/Los_Angeles",
                        },
                    },
                },
                Limit = 100,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchTimecardsResponse>(mockResponse)).UsingDefaults()
        );
    }
}
