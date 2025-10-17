using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Bookings;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "booking": {}
            }
            """;

        const string mockResponse = """
            {
              "booking": {
                "id": "zkras0xv0xwswx",
                "version": 2,
                "status": "ACCEPTED",
                "created_at": "2020-10-28T15:47:41.000Z",
                "updated_at": "2020-10-28T15:49:25.000Z",
                "start_at": "2020-11-26T13:00:00.000Z",
                "location_id": "LEQHH0YY8B42M",
                "customer_id": "EX2QSVGTZN4K1E5QE1CBFNVQ8M",
                "customer_note": "I would like to sit near the window please",
                "seller_note": "",
                "appointment_segments": [
                  {
                    "duration_minutes": 60,
                    "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                    "team_member_id": "TMXUrsBWWcHTt79t",
                    "service_variation_version": 1599775456731
                  }
                ],
                "transition_time_minutes": 1,
                "all_day": true,
                "location_type": "CUSTOMER_LOCATION",
                "creator_details": {
                  "creator_type": "TEAM_MEMBER",
                  "team_member_id": "team_member_id",
                  "customer_id": "customer_id"
                },
                "source": "FIRST_PARTY_MERCHANT",
                "address": {
                  "address_line_1": "1955 Broadway",
                  "address_line_2": "Suite 600",
                  "address_line_3": "address_line_3",
                  "locality": "Oakland",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "CA",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "94612",
                  "country": "ZZ",
                  "first_name": "first_name",
                  "last_name": "last_name"
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
                    .WithPath("/v2/bookings/booking_id")
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

        var response = await Client.Bookings.UpdateAsync(
            new UpdateBookingRequest { BookingId = "booking_id", Booking = new Booking() }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateBookingResponse>(mockResponse)).UsingDefaults()
        );
    }
}
