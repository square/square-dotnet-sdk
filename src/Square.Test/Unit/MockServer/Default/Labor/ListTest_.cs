using NUnit.Framework;
using Square.Default.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "workweek_configs": [
                {
                  "id": "FY4VCAQN700GM",
                  "start_of_week": "MON",
                  "start_of_day_local_time": "10:00",
                  "version": 11,
                  "created_at": "2016-02-04T00:58:24.000Z",
                  "updated_at": "2019-02-28T01:04:35.000Z"
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
                    .WithPath("/v2/labor/workweek-configs")
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

        var items = await Client.Default.Labor.WorkweekConfigs.ListAsync(
            new ListWorkweekConfigsRequest { Limit = 1, Cursor = "cursor" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
