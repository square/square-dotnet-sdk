using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Bookings;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Bookings;

[TestFixture]
public class BulkRetrieveTeamMemberBookingProfilesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "team_member_ids": [
                "team_member_ids"
              ]
            }
            """;

        const string mockResponse = """
            {
              "team_member_booking_profiles": {
                "TMXUrsBWWcHTt79t": {
                  "errors": [
                    {
                      "category": "INVALID_REQUEST_ERROR",
                      "code": "NOT_FOUND",
                      "detail": "Resource not found."
                    }
                  ]
                },
                "TMaJcbiRqPIGZuS9": {
                  "team_member_booking_profile": {
                    "team_member_id": "TMaJcbiRqPIGZuS9",
                    "display_name": "Sandbox Staff 1",
                    "is_bookable": true
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "TMtdegug1fqni3wh": {
                  "team_member_booking_profile": {
                    "team_member_id": "TMtdegug1fqni3wh",
                    "display_name": "Sandbox Staff 2",
                    "is_bookable": true
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
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
                    .WithPath("/v2/bookings/team-member-booking-profiles/bulk-retrieve")
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

        var response = await Client.Default.Bookings.BulkRetrieveTeamMemberBookingProfilesAsync(
            new BulkRetrieveTeamMemberBookingProfilesRequest
            {
                TeamMemberIds = new List<string>() { "team_member_ids" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkRetrieveTeamMemberBookingProfilesResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
