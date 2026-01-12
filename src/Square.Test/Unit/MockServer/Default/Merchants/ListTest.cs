using NUnit.Framework;
using Square.Default.Merchants;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants;

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
              "merchant": [
                {
                  "id": "DM7VKY8Q63GNP",
                  "business_name": "Apple A Day",
                  "country": "US",
                  "language_code": "en-US",
                  "currency": "USD",
                  "status": "ACTIVE",
                  "main_location_id": "9A65CGC72ZQG1",
                  "created_at": "2021-12-10T19:25:52.484Z"
                }
              ],
              "cursor": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/merchants")
                    .WithParam("cursor", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Merchants.ListAsync(
            new ListMerchantsRequest { Cursor = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
