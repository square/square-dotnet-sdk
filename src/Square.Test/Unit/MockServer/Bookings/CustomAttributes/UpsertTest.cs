using NUnit.Framework;
using Square;
using Square.Bookings.CustomAttributes;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.CustomAttributes;

[TestFixture]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute": {}
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute": {
                "key": "favoriteShampoo",
                "value": "Spring Fresh",
                "version": 1,
                "visibility": "VISIBILITY_READ_ONLY",
                "definition": {
                  "key": "key",
                  "schema": {
                    "key": "value"
                  },
                  "name": "name",
                  "description": "description",
                  "visibility": "VISIBILITY_HIDDEN",
                  "version": 1,
                  "updated_at": "updated_at",
                  "created_at": "created_at"
                },
                "updated_at": "2022-11-16T15:50:27.000Z",
                "created_at": "2022-11-16T15:50:27.000Z"
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
                    .WithPath("/v2/bookings/booking_id/custom-attributes/key")
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

        var response = await Client.Bookings.CustomAttributes.UpsertAsync(
            new UpsertBookingCustomAttributeRequest
            {
                BookingId = "booking_id",
                Key = "key",
                CustomAttribute = new CustomAttribute(),
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpsertBookingCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
