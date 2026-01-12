using NUnit.Framework;
using Square.Bookings.LocationProfiles;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.LocationProfiles;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "location_booking_profiles": [
                {
                  "location_id": "LY6WNBPVM6VGV",
                  "booking_site_url": "https://squareup.com/book/LY6WNBPVM6VGV/testbusiness",
                  "online_booking_enabled": true
                },
                {
                  "location_id": "PYTRNBPVMJUPV",
                  "booking_site_url": "booking_site_url",
                  "online_booking_enabled": false
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
                    .WithPath("/v2/bookings/location-booking-profiles")
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

        var items = await Client.Bookings.LocationProfiles.ListAsync(
            new ListLocationProfilesRequest { Limit = 1, Cursor = "cursor" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
