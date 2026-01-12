using NUnit.Framework;
using Square.Default.Labor.BreakTypes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor.BreakTypes;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "break_types": [
                {
                  "id": "REGS1EQR1TPZ5",
                  "location_id": "PAA1RJZZKXBFG",
                  "break_name": "Coffee Break",
                  "expected_duration": "PT5M",
                  "is_paid": false,
                  "version": 1,
                  "created_at": "2019-01-22T20:47:37.000Z",
                  "updated_at": "2019-01-22T20:47:37.000Z"
                },
                {
                  "id": "92EPDRQKJ5088",
                  "location_id": "PAA1RJZZKXBFG",
                  "break_name": "Lunch Break",
                  "expected_duration": "PT1H",
                  "is_paid": true,
                  "version": 3,
                  "created_at": "2019-01-25T19:26:30.000Z",
                  "updated_at": "2019-01-25T19:26:30.000Z"
                }
              ],
              "cursor": "2fofTniCgT0yIPAq26kmk0YyFQJZfbWkh73OOnlTHmTAx13NgED",
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
                    .WithPath("/v2/labor/break-types")
                    .WithParam("location_id", "location_id")
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

        var items = await Client.Default.Labor.BreakTypes.ListAsync(
            new ListBreakTypesRequest
            {
                LocationId = "location_id",
                Limit = 1,
                Cursor = "cursor",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
