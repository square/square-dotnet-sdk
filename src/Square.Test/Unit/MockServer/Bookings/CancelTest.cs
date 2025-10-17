using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Bookings;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings;

[TestFixture]
public class CancelTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "booking": {
                "id": "zkras0xv0xwswx",
                "version": 1,
                "status": "CANCELLED_BY_CUSTOMER",
                "created_at": "2020-10-28T15:47:41.000Z",
                "updated_at": "2020-10-28T15:49:25.000Z",
                "start_at": "2020-11-26T13:00:00.000Z",
                "location_id": "LEQHH0YY8B42M",
                "customer_id": "EX2QSVGTZN4K1E5QE1CBFNVQ8M",
                "customer_note": "",
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
                "location_type": "BUSINESS_LOCATION",
                "creator_details": {
                  "creator_type": "TEAM_MEMBER",
                  "team_member_id": "team_member_id",
                  "customer_id": "customer_id"
                },
                "source": "FIRST_PARTY_MERCHANT",
                "address": {
                  "address_line_1": "address_line_1",
                  "address_line_2": "address_line_2",
                  "address_line_3": "address_line_3",
                  "locality": "locality",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "administrative_district_level_1",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "postal_code",
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
                    .WithPath("/v2/bookings/booking_id/cancel")
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

        var response = await Client.Bookings.CancelAsync(
            new CancelBookingRequest { BookingId = "booking_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelBookingResponse>(mockResponse)).UsingDefaults()
        );
    }
}
