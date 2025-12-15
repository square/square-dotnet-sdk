using NUnit.Framework;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.CustomAttributes;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attributes": [
                {
                  "key": "favoriteShampoo",
                  "value": "Hydro-Cool",
                  "version": 1,
                  "visibility": "VISIBILITY_READ_ONLY",
                  "updated_at": "2022-11-16T15:50:27.000Z",
                  "created_at": "2022-11-16T15:50:27.000Z"
                },
                {
                  "key": "hasShoes",
                  "value": false,
                  "version": 1,
                  "visibility": "VISIBILITY_HIDDEN",
                  "updated_at": "2022-11-16T15:51:53.000Z",
                  "created_at": "2022-11-16T15:51:53.000Z"
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
                    .WithPath("/v2/bookings/booking_id/custom-attributes")
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

        var items = await Client.Bookings.CustomAttributes.ListAsync(
            new Square.Bookings.CustomAttributes.ListCustomAttributesRequest
            {
                BookingId = "booking_id",
                Limit = 1,
                Cursor = "cursor",
                WithDefinitions = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
