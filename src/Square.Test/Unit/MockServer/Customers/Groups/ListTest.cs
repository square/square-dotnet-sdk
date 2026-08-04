using NUnit.Framework;
using Square.Customers.Groups;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.Groups;

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
              "groups": [
                {
                  "id": "2TAT3CMH4Q0A9M87XJZED0WMR3",
                  "name": "Loyal Customers",
                  "created_at": "2020-04-13T21:54:57.863Z",
                  "updated_at": "2020-04-13T21:54:58.000Z"
                },
                {
                  "id": "4XMEHESXJBNE9S9JAKZD2FGB14",
                  "name": "Super Loyal Customers",
                  "created_at": "2020-04-13T21:55:18.795Z",
                  "updated_at": "2020-04-13T21:55:19.000Z"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/groups")
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

        var items = await Client.Customers.Groups.ListAsync(
            new ListGroupsRequest { Cursor = "cursor", Limit = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
