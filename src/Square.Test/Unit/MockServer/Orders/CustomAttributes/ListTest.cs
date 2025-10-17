using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Orders.CustomAttributes;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attributes": [
                {
                  "key": "wayne-test-15",
                  "value": "TEST",
                  "version": 1,
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "updated_at": "2022-11-10T17:31:36.111Z",
                  "created_at": "2022-11-10T17:31:36.111Z"
                }
              ],
              "cursor": "cursor",
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
                    .WithPath("/v2/orders/order_id/custom-attributes")
                    .WithParam("visibility_filter", "ALL")
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

        var items = await Client.Orders.CustomAttributes.ListAsync(
            new Square.Orders.CustomAttributes.ListCustomAttributesRequest
            {
                OrderId = "order_id",
                VisibilityFilter = VisibilityFilter.All,
                Cursor = "cursor",
                Limit = 1,
                WithDefinitions = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
