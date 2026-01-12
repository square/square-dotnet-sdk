using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Bookings;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Bookings;

[TestFixture]
public class BulkRetrieveBookingsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "booking_ids": [
                "booking_ids"
              ]
            }
            """;

        const string mockResponse = """
            {
              "bookings": {
                "sc3p3m7dvctfr1": {
                  "booking": {
                    "id": "sc3p3m7dvctfr1",
                    "version": 0,
                    "status": "ACCEPTED",
                    "created_at": "2023-04-26T18:19:21.000Z",
                    "updated_at": "2023-04-26T18:19:21.000Z",
                    "start_at": "2023-05-01T14:00:00.000Z",
                    "location_id": "LY6WNBPVM6VGV",
                    "customer_id": "4TDWKN9E8165X8Z77MRS0VFMJM",
                    "appointment_segments": [
                      {
                        "duration_minutes": 60,
                        "service_variation_id": "VG4FYBKK3UL6UITOEYQ6MFLS",
                        "team_member_id": "TMjiqI3PxyLMKr4k",
                        "service_variation_version": 1641341724039,
                        "any_team_member": false
                      }
                    ],
                    "all_day": false
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "tdegug1dvctdef": {
                  "errors": [
                    {
                      "category": "INVALID_REQUEST_ERROR",
                      "code": "NOT_FOUND",
                      "detail": "Specified booking was not found.",
                      "field": "booking_id"
                    }
                  ]
                },
                "tdegug1fqni3wh": {
                  "booking": {
                    "id": "tdegug1fqni3wh",
                    "version": 0,
                    "status": "ACCEPTED",
                    "created_at": "2023-04-26T18:19:30.000Z",
                    "updated_at": "2023-04-26T18:19:30.000Z",
                    "start_at": "2023-05-02T14:00:00.000Z",
                    "location_id": "LY6WNBPVM6VGV",
                    "customer_id": "4TDWKN9E8165X8Z77MRS0VFMJM",
                    "appointment_segments": [
                      {
                        "duration_minutes": 60,
                        "service_variation_id": "VG4FYBKK3UL6UITOEYQ6MFLS",
                        "team_member_id": "TMjiqI3PxyLMKr4k",
                        "service_variation_version": 1641341724039,
                        "any_team_member": false
                      }
                    ],
                    "all_day": false
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
                    .WithPath("/v2/bookings/bulk-retrieve")
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

        var response = await Client.Default.Bookings.BulkRetrieveBookingsAsync(
            new BulkRetrieveBookingsRequest { BookingIds = new List<string>() { "booking_ids" } }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkRetrieveBookingsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
