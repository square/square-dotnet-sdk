using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.TeamMembers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.TeamMembers;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                        "amount": 2000,
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.TeamMembers.GetAsync(
            new GetTeamMembersRequest { TeamMemberId = "team_member_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetTeamMemberResponse>(mockResponse)).UsingDefaults()
        );
    }
}
