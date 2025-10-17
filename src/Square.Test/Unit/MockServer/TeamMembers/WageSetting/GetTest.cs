using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.TeamMembers.WageSetting;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "wage_setting": {
                "team_member_id": "1yJlHapkseYnNPETIU1B",
                "job_assignments": [
                  {
                    "job_title": "Manager",
                    "pay_type": "SALARY",
                    "hourly_rate": {
                      "amount": 2164,
                      "currency": "USD"
                    },
                    "annual_rate": {
                      "amount": 4500000,
                      "currency": "USD"
                    },
                    "weekly_hours": 40
                  }
                ],
                "is_overtime_exempt": false,
                "version": 1,
                "created_at": "2020-06-11T23:01:21.000Z",
                "updated_at": "2020-06-11T23:01:21.000Z"
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TeamMembers.WageSetting.GetAsync(
            new Square.TeamMembers.WageSetting.GetWageSettingRequest
            {
                TeamMemberId = "team_member_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetWageSettingResponse>(mockResponse)).UsingDefaults()
        );
    }
}
