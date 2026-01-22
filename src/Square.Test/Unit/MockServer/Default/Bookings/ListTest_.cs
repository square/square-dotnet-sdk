using NUnit.Framework;
using Square.Default.Bookings;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Bookings;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "team_member_booking_profiles": [
                {
                  "team_member_id": "TMXUrsBWWcHTt79t",
                  "description": "description",
                  "display_name": "Sandbox Seller",
                  "is_bookable": true,
                  "profile_image_url": "profile_image_url"
                },
                {
                  "team_member_id": "TMaJcbiRqPIGZuS9",
                  "description": "description",
                  "display_name": "Sandbox Staff",
                  "is_bookable": true,
                  "profile_image_url": "profile_image_url"
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
                    .WithPath("/v2/bookings/team-member-booking-profiles")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .WithParam("location_id", "location_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Bookings.TeamMemberProfiles.ListAsync(
            new ListTeamMemberProfilesRequest
            {
                BookableOnly = true,
                Limit = 1,
                Cursor = "cursor",
                LocationId = "location_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
