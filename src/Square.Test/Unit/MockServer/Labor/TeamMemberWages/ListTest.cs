using NUnit.Framework;
using Square.Labor.TeamMemberWages;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor.TeamMemberWages;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "team_member_wages": [
                {
                  "id": "pXS3qCv7BERPnEGedM4S8mhm",
                  "team_member_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Manager",
                  "hourly_rate": {
                    "amount": 3250,
                    "currency": "USD"
                  },
                  "job_id": "jxJNN6eCJsLrhg5UFJrDWDGE",
                  "tip_eligible": false
                },
                {
                  "id": "rZduCkzYDUVL3ovh1sQgbue6",
                  "team_member_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Cook",
                  "hourly_rate": {
                    "amount": 2600,
                    "currency": "USD"
                  },
                  "job_id": "gcbz15vKGnMKmaWJJ152kjim",
                  "tip_eligible": true
                },
                {
                  "id": "FxLbs5KpPUHa8wyt5ctjubDX",
                  "team_member_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Barista",
                  "hourly_rate": {
                    "amount": 1600,
                    "currency": "USD"
                  },
                  "job_id": "FzbJAtt9qEWncK1BWgVCxQ6M",
                  "tip_eligible": true
                },
                {
                  "id": "vD1wCgijMDR3cX5TPnu7VXto",
                  "team_member_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Cashier",
                  "hourly_rate": {
                    "amount": 1700,
                    "currency": "USD"
                  },
                  "job_id": "N4YKVLzFj3oGtNocqoYHYpW3",
                  "tip_eligible": true
                }
              ],
              "cursor": "2fofTniCgT0yIPAq26kmk0YyFQJZfbWkh73OOnlTHmTAx13NgED",
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
                    .WithPath("/v2/labor/team-member-wages")
                    .WithParam("team_member_id", "team_member_id")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Labor.TeamMemberWages.ListAsync(
            new ListTeamMemberWagesRequest
            {
                TeamMemberId = "team_member_id",
                Limit = 1,
                Cursor = "cursor",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
