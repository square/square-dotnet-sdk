using NUnit.Framework;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attribute_definitions": [
                {
                  "key": "cover-count",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                  },
                  "name": "Cover count",
                  "description": "The number of people seated at a table",
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "version": 1,
                  "updated_at": "2022-11-16T18:03:44.051Z",
                  "created_at": "2022-11-16T18:03:44.051Z"
                },
                {
                  "key": "seat-number",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                  },
                  "name": "Seat number",
                  "description": "The identifier for a particular seat",
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "version": 1,
                  "updated_at": "2022-11-16T18:04:32.059Z",
                  "created_at": "2022-11-16T18:04:32.059Z"
                },
                {
                  "key": "table-number",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                  },
                  "name": "Table number",
                  "description": "The identifier for a particular table",
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "version": 1,
                  "updated_at": "2022-11-16T18:04:21.912Z",
                  "created_at": "2022-11-16T18:04:21.912Z"
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
                    .WithPath("/v2/orders/custom-attribute-definitions")
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

        var items = await Client.Default.Orders.CustomAttributeDefinitions.ListAsync(
            new Square.Default.Orders.ListCustomAttributeDefinitionsRequest
            {
                VisibilityFilter = VisibilityFilter.All,
                Cursor = "cursor",
                Limit = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
