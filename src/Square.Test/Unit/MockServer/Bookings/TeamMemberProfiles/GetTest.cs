using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Bookings.TeamMemberProfiles;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.TeamMemberProfiles;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "team_member_booking_profile": {
                "team_member_id": "TMaJcbiRqPIGZuS9",
                "description": "description",
                "display_name": "Sandbox Staff",
                "is_bookable": true,
                "profile_image_url": "profile_image_url"
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
                    .WithPath("/v2/bookings/team-member-booking-profiles/team_member_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bookings.TeamMemberProfiles.GetAsync(
            new GetTeamMemberProfilesRequest { TeamMemberId = "team_member_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetTeamMemberBookingProfileResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
