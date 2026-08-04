using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor;

[TestFixture]
public class UpdateTimecardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "timecard": {
                "location_id": "PAA1RJZZKXBFG",
                "start_at": "2019-01-25T08:11:00.000Z",
                "end_at": "2019-01-25T18:11:00.000Z",
                "wage": {
                  "title": "Bartender",
                  "hourly_rate": {
                    "amount": 1500,
                    "currency": "USD"
                  },
                  "tip_eligible": true
                },
                "breaks": [
                  {
                    "id": "X7GAQYVVRRG6P",
                    "start_at": "2019-01-25T11:11:00.000Z",
                    "end_at": "2019-01-25T11:16:00.000Z",
                    "break_type_id": "REGS1EQR1TPZ5",
                    "name": "Tea Break",
                    "expected_duration": "PT5M",
                    "is_paid": true
                  }
                ],
                "status": "CLOSED",
                "version": 1,
                "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                "declared_cash_tip_money": {
                  "amount": 500,
                  "currency": "USD"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "timecard": {
                "id": "K0YH4CV5462JB",
                "location_id": "PAA1RJZZKXBFG",
                "timezone": "America/New_York",
                "start_at": "2019-01-25T08:11:00.000Z",
                "end_at": "2019-01-25T18:11:00.000Z",
                "wage": {
                  "title": "Bartender",
                  "hourly_rate": {
                    "amount": 1500,
                    "currency": "USD"
                  },
                  "job_id": "dZtrPh5GSDGugyXGByesVp51",
                  "tip_eligible": true
                },
                "breaks": [
                  {
                    "id": "X7GAQYVVRRG6P",
                    "start_at": "2019-01-25T11:11:00.000Z",
                    "end_at": "2019-01-25T11:16:00.000Z",
                    "break_type_id": "REGS1EQR1TPZ5",
                    "name": "Tea Break",
                    "expected_duration": "PT5M",
                    "is_paid": true
                  }
                ],
                "status": "CLOSED",
                "version": 2,
                "created_at": "2019-02-28T00:39:02.000Z",
                "updated_at": "2019-02-28T00:42:41.000Z",
                "team_member_id": "ormj0jJJZ5OZIzxrZYJI",
                "declared_cash_tip_money": {
                  "amount": 500,
                  "currency": "USD"
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
                    .WithPath("/v2/labor/timecards/id")
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

        var response = await Client.Labor.UpdateTimecardAsync(
            new UpdateTimecardRequest
            {
                Id = "id",
                Timecard = new Timecard
                {
                    LocationId = "PAA1RJZZKXBFG",
                    StartAt = "2019-01-25T03:11:00-05:00",
                    EndAt = "2019-01-25T13:11:00-05:00",
                    Wage = new TimecardWage
                    {
                        Title = "Bartender",
                        HourlyRate = new Money { Amount = 1500, Currency = Currency.Usd },
                        TipEligible = true,
                    },
                    Breaks = new List<Break>()
                    {
                        new Break
                        {
                            Id = "X7GAQYVVRRG6P",
                            StartAt = "2019-01-25T06:11:00-05:00",
                            EndAt = "2019-01-25T06:16:00-05:00",
                            BreakTypeId = "REGS1EQR1TPZ5",
                            Name = "Tea Break",
                            ExpectedDuration = "PT5M",
                            IsPaid = true,
                        },
                    },
                    Status = TimecardStatus.Closed,
                    Version = 1,
                    TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
                    DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateTimecardResponse>(mockResponse)).UsingDefaults()
        );
    }
}
