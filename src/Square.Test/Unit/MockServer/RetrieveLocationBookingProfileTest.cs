using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Bookings;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RetrieveLocationBookingProfileTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "location_booking_profile": {
                "location_id": "L3HETDGYQ4A2C",
                "booking_site_url": "https://square.site/book/L3HETDGYQ4A2C/prod-business",
                "online_booking_enabled": true
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
                    .WithPath("/v2/bookings/location-booking-profiles/location_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bookings.RetrieveLocationBookingProfileAsync(
            new RetrieveLocationBookingProfileRequest { LocationId = "location_id" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveLocationBookingProfileResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
