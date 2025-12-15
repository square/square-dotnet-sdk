using NUnit.Framework;
using Square.Bookings;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "bookings": [
                {
                  "id": "zkras0xv0xwswx",
                  "version": 1,
                  "status": "ACCEPTED",
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
                  "source": "FIRST_PARTY_MERCHANT"
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
                    .WithPath("/v2/bookings")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .WithParam("customer_id", "customer_id")
                    .WithParam("team_member_id", "team_member_id")
                    .WithParam("location_id", "location_id")
                    .WithParam("start_at_min", "start_at_min")
                    .WithParam("start_at_max", "start_at_max")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Bookings.ListAsync(
            new ListBookingsRequest
            {
                Limit = 1,
                Cursor = "cursor",
                CustomerId = "customer_id",
                TeamMemberId = "team_member_id",
                LocationId = "location_id",
                StartAtMin = "start_at_min",
                StartAtMax = "start_at_max",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
