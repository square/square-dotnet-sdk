using NUnit.Framework;
using Square;
using Square.Core;
using Square.TeamMembers.WageSetting;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.TeamMembers.WageSetting;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "wage_setting": {
                "job_assignments": [
                  {
                    "job_title": "Manager",
                    "pay_type": "SALARY",
                    "annual_rate": {
                      "amount": 3000000,
                      "currency": "USD"
                    },
                    "weekly_hours": 40
                  },
                  {
                    "job_title": "Cashier",
                    "pay_type": "HOURLY",
                    "hourly_rate": {
                      "amount": 2000,
                      "currency": "USD"
                    }
                  }
                ],
                "is_overtime_exempt": true
              }
            }
            """;

        const string mockResponse = """
            {
              "wage_setting": {
                "team_member_id": "-3oZQKPKVk6gUXU_V5Qa",
                "job_assignments": [
                  {
                    "job_title": "Manager",
                    "pay_type": "SALARY",
                    "hourly_rate": {
                      "amount": 1443,
                      "currency": "USD"
                    },
                    "annual_rate": {
                      "amount": 3000000,
                      "currency": "USD"
                    },
                    "weekly_hours": 40
                  },
                  {
                    "job_title": "Cashier",
                    "pay_type": "HOURLY",
                    "hourly_rate": {
                      "amount": 2000,
                      "currency": "USD"
                    }
                  }
                ],
                "is_overtime_exempt": true,
                "version": 1,
                "created_at": "2019-07-10T17:26:48.000Z",
                "updated_at": "2020-06-11T23:12:04.000Z"
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
                    .WithPath("/v2/team-members/team_member_id/wage-setting")
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

        var response = await Client.TeamMembers.WageSetting.UpdateAsync(
            new UpdateWageSettingRequest
            {
                TeamMemberId = "team_member_id",
                WageSetting = new Square.WageSetting
                {
                    JobAssignments = new List<JobAssignment>()
                    {
                        new JobAssignment
                        {
                            JobTitle = "Manager",
                            PayType = JobAssignmentPayType.Salary,
                            AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
                            WeeklyHours = 40,
                        },
                        new JobAssignment
                        {
                            JobTitle = "Cashier",
                            PayType = JobAssignmentPayType.Hourly,
                            HourlyRate = new Money { Amount = 2000, Currency = Currency.Usd },
                        },
                    },
                    IsOvertimeExempt = true,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateWageSettingResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
