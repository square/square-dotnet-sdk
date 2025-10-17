using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Bookings.CustomAttributes;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.CustomAttributes;

[TestFixture]
public class BatchDeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "key": {
                  "booking_id": "booking_id",
                  "key": "key"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "booking_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
                  "booking_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id3": {
                  "booking_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
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
                    .WithPath("/v2/bookings/custom-attributes/bulk-delete")
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

        var response = await Client.Bookings.CustomAttributes.BatchDeleteAsync(
            new BulkDeleteBookingCustomAttributesRequest
            {
                Values = new Dictionary<string, BookingCustomAttributeDeleteRequest>()
                {
                    {
                        "key",
                        new BookingCustomAttributeDeleteRequest
                        {
                            BookingId = "booking_id",
                            Key = "key",
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkDeleteBookingCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
