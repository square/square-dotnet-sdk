using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class CreateTimecardTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "HIDSNG5KS478L",
              "timecard": {
                "location_id": "PAA1RJZZKXBFG",
                "start_at": "2019-01-25T08:11:00.000Z",
                "end_at": "2019-01-25T18:11:00.000Z",
                "wage": {
                  "title": "Barista",
                  "hourly_rate": {
                    "amount": 1100,
                    "currency": "USD"
                  },
                  "tip_eligible": true
                },
                "breaks": [
                  {
                    "start_at": "2019-01-25T11:11:00.000Z",
                    "end_at": "2019-01-25T11:16:00.000Z",
                    "break_type_id": "REGS1EQR1TPZ5",
                    "name": "Tea Break",
                    "expected_duration": "PT5M",
                    "is_paid": true
                  }
                ],
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
                "created_at": "2019-02-28T00:39:02.000Z",
                "updated_at": "2019-02-28T00:39:02.000Z",
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
                    .WithPath("/v2/labor/timecards")
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

        var response = await Client.Labor.CreateTimecardAsync(
            new CreateTimecardRequest
            {
                IdempotencyKey = "HIDSNG5KS478L",
                Timecard = new Timecard
                {
                    LocationId = "PAA1RJZZKXBFG",
                    StartAt = "2019-01-25T03:11:00-05:00",
                    EndAt = "2019-01-25T13:11:00-05:00",
                    Wage = new TimecardWage
                    {
                        Title = "Barista",
                        HourlyRate = new Money { Amount = 1100, Currency = Currency.Usd },
                        TipEligible = true,
                    },
                    Breaks = new List<Break>()
                    {
                        new Break
                        {
                            StartAt = "2019-01-25T06:11:00-05:00",
                            EndAt = "2019-01-25T06:16:00-05:00",
                            BreakTypeId = "REGS1EQR1TPZ5",
                            Name = "Tea Break",
                            ExpectedDuration = "PT5M",
                            IsPaid = true,
                        },
                    },
                    TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
                    DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateTimecardResponse>(mockResponse)).UsingDefaults()
        );
    }
}
