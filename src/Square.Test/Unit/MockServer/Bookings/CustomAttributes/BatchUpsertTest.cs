using NUnit.Framework;
using Square;
using Square.Bookings.CustomAttributes;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.CustomAttributes;

[TestFixture]
public class BatchUpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "key": {
                  "booking_id": "booking_id",
                  "custom_attribute": {}
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "booking_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "custom_attribute": {
                    "key": "favoriteShampoo",
                    "value": "Spring Fresh",
                    "version": 1,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2022-11-16T00:16:23.000Z",
                    "created_at": "2022-11-16T23:14:47.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
                  "booking_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "custom_attribute": {
                    "key": "hasShoes",
                    "value": false,
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2022-11-16T00:16:23.000Z",
                    "created_at": "2022-11-16T00:16:20.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id3": {
                  "booking_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "custom_attribute": {
                    "key": "favoriteShampoo",
                    "value": "Hydro-Cool",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2022-11-16T00:16:23.000Z",
                    "created_at": "2022-11-16T00:16:20.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id4": {
                  "booking_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "custom_attribute": {
                    "key": "partySize",
                    "value": 4,
                    "version": 1,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2022-11-16T00:16:23.000Z",
                    "created_at": "2022-11-16T23:14:47.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id5": {
                  "booking_id": "70548QG1HN43B05G0KCZ4MMC1G",
                  "custom_attribute": {
                    "key": "celebrating",
                    "value": "birthday",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2022-11-16T00:16:23.000Z",
                    "created_at": "2022-11-16T00:16:20.000Z"
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
                    .WithPath("/v2/bookings/custom-attributes/bulk-upsert")
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

        var response = await Client.Bookings.CustomAttributes.BatchUpsertAsync(
            new BulkUpsertBookingCustomAttributesRequest
            {
                Values = new Dictionary<string, BookingCustomAttributeUpsertRequest>()
                {
                    {
                        "key",
                        new BookingCustomAttributeUpsertRequest
                        {
                            BookingId = "booking_id",
                            CustomAttribute = new CustomAttribute(),
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkUpsertBookingCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
