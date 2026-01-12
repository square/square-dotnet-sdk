using NUnit.Framework;
using Square.Default.Customers.Segments;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers.Segments;

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
              "segments": [
                {
                  "id": "GMNXRZVEXNQDF.CHURN_RISK",
                  "name": "Lapsed",
                  "created_at": "2020-01-09T19:33:24.469Z",
                  "updated_at": "2020-04-13T21:47:04.000Z"
                },
                {
                  "id": "GMNXRZVEXNQDF.LOYAL",
                  "name": "Regulars",
                  "created_at": "2020-01-09T19:33:24.486Z",
                  "updated_at": "2020-04-13T21:47:04.000Z"
                },
                {
                  "id": "GMNXRZVEXNQDF.REACHABLE",
                  "name": "Reachable",
                  "created_at": "2020-01-09T19:33:21.813Z",
                  "updated_at": "2020-04-13T21:47:04.000Z"
                },
                {
                  "id": "gv2:KF92J19VXN5FK30GX2E8HSGQ20",
                  "name": "Instant Profile",
                  "created_at": "2020-01-09T19:33:25.000Z",
                  "updated_at": "2020-04-13T23:01:03.000Z"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/segments")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Customers.Segments.ListAsync(
            new ListSegmentsRequest { Cursor = "cursor", Limit = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
