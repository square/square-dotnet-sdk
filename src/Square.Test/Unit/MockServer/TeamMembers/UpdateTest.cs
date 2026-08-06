using NUnit.Framework;
using Square;
using Square.Core;
using Square.TeamMembers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.TeamMembers;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "team_member": {
                "reference_id": "reference_id_1",
                "status": "ACTIVE",
                "given_name": "Joe",
                "family_name": "Doe",
                "email_address": "joe_doe@gmail.com",
                "phone_number": "+14159283333",
                "assigned_locations": {
                  "assignment_type": "EXPLICIT_LOCATIONS",
                  "location_ids": [
                    "YSGH2WBKG94QZ",
                    "GA2Y9HSJ8KRYT"
                  ]
                },
                "wage_setting": {
                  "job_assignments": [
                    {
                      "pay_type": "SALARY",
                      "annual_rate": {
                        "amount": 3000000,
                        "currency": "USD"
                      },
                      "weekly_hours": 40,
                      "job_id": "FjS8x95cqHiMenw4f1NAUH4P"
                    },
                    {
                      "pay_type": "HOURLY",
                      "hourly_rate": {
                        "amount": 1200,
                        "currency": "USD"
                      },
                      "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                    }
                  ],
                  "is_overtime_exempt": true
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "team_member": {
                "id": "1yJlHapkseYnNPETIU1B",
                "reference_id": "reference_id_1",
                "is_owner": false,
                "status": "ACTIVE",
                "given_name": "Joe",
                "family_name": "Doe",
                "email_address": "joe_doe@example.com",
                "phone_number": "+14159283333",
                "created_at": "2021-06-11T22:55:45.000Z",
                "updated_at": "2021-06-15T17:38:05.000Z",
                "assigned_locations": {
                  "assignment_type": "EXPLICIT_LOCATIONS",
                  "location_ids": [
                    "GA2Y9HSJ8KRYT",
                    "YSGH2WBKG94QZ"
                  ]
                },
                "wage_setting": {
                  "team_member_id": "1yJlHapkseYnNPETIU1B",
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
                      "weekly_hours": 40,
                      "job_id": "FjS8x95cqHiMenw4f1NAUH4P"
                    },
                    {
                      "job_title": "Cashier",
                      "pay_type": "HOURLY",
                      "hourly_rate": {
                        "amount": 1200,
                        "currency": "USD"
                      },
                      "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                    }
                  ],
                  "is_overtime_exempt": true,
                  "version": 1,
                  "created_at": "2021-06-11T22:55:45.000Z",
                  "updated_at": "2021-06-11T22:55:45.000Z"
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
                    .WithPath("/v2/team-members/team_member_id")
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

        var response = await Client.TeamMembers.UpdateAsync(
            new UpdateTeamMembersRequest
            {
                TeamMemberId = "team_member_id",
                Body = new UpdateTeamMemberRequest
                {
                    TeamMember = new TeamMember
                    {
                        ReferenceId = "reference_id_1",
                        Status = TeamMemberStatus.Active,
                        GivenName = "Joe",
                        FamilyName = "Doe",
                        EmailAddress = "joe_doe@gmail.com",
                        PhoneNumber = "+14159283333",
                        AssignedLocations = new TeamMemberAssignedLocations
                        {
                            AssignmentType =
                                TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
                            LocationIds = new List<string>() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
                        },
                        WageSetting = new Square.WageSetting
                        {
                            JobAssignments = new List<JobAssignment>()
                            {
                                new JobAssignment
                                {
                                    PayType = JobAssignmentPayType.Salary,
                                    AnnualRate = new Money
                                    {
                                        Amount = 3000000,
                                        Currency = Currency.Usd,
                                    },
                                    WeeklyHours = 40,
                                    JobId = "FjS8x95cqHiMenw4f1NAUH4P",
                                },
                                new JobAssignment
                                {
                                    PayType = JobAssignmentPayType.Hourly,
                                    HourlyRate = new Money
                                    {
                                        Amount = 1200,
                                        Currency = Currency.Usd,
                                    },
                                    JobId = "VDNpRv8da51NU8qZFC5zDWpF",
                                },
                            },
                            IsOvertimeExempt = true,
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateTeamMemberResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
