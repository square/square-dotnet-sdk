using NUnit.Framework;
using Square.Default;
using Square.Default.Devices.Codes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Devices.Codes;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "device_codes": [
                {
                  "id": "B3Z6NAMYQSMTM",
                  "name": "Counter 1",
                  "code": "EBCARJ",
                  "device_id": "907CS13101300122",
                  "product_type": "TERMINAL_API",
                  "location_id": "B5E4484SHHNYH",
                  "status": "PAIRED",
                  "pair_by": "2020-02-06T18:49:33.000Z",
                  "created_at": "2020-02-06T18:44:33.000Z",
                  "status_changed_at": "2020-02-06T18:47:28.000Z",
                  "paired_at": "paired_at"
                },
                {
                  "id": "YKGMJMYK8H4PQ",
                  "name": "Unused device code",
                  "code": "GVXNYN",
                  "device_id": "device_id",
                  "product_type": "TERMINAL_API",
                  "location_id": "A6SYFRSV4WAFW",
                  "status": "UNPAIRED",
                  "pair_by": "2020-02-07T20:00:04.000Z",
                  "created_at": "2020-02-07T19:55:04.000Z",
                  "status_changed_at": "2020-02-07T19:55:04.000Z",
                  "paired_at": "paired_at"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/devices/codes")
                    .WithParam("cursor", "cursor")
                    .WithParam("location_id", "location_id")
                    .WithParam("product_type", "TERMINAL_API")
                    .WithParam("status", "UNKNOWN")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Devices.Codes.ListAsync(
            new ListCodesRequest
            {
                Cursor = "cursor",
                LocationId = "location_id",
                ProductType = "TERMINAL_API",
                Status = DeviceCodeStatus.Unknown,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
