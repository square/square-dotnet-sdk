using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Labor.TeamMemberWages;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor.TeamMemberWages;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "team_member_wage": {
                "id": "pXS3qCv7BERPnEGedM4S8mhm",
                "team_member_id": "33fJchumvVdJwxV0H6L9",
                "title": "Manager",
                "hourly_rate": {
                  "amount": 2000,
                  "currency": "USD"
                },
                "job_id": "jxJNN6eCJsLrhg5UFJrDWDGE",
                "tip_eligible": false
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
                    .WithPath("/v2/labor/team-member-wages/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Labor.TeamMemberWages.GetAsync(
            new GetTeamMemberWagesRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetTeamMemberWageResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
