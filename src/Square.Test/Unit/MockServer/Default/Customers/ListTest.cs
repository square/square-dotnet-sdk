using NUnit.Framework;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers;

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
                  "key": "favoritemovie",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                  },
                  "name": "Favorite Movie",
                  "description": "Update the description as desired.",
                  "visibility": "VISIBILITY_READ_ONLY",
                  "version": 3,
                  "updated_at": "2022-04-26T15:39:38.000Z",
                  "created_at": "2022-04-26T15:27:30.000Z"
                },
                {
                  "key": "ownsmovie",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Boolean"
                  },
                  "name": "Owns Movie",
                  "description": "Customer owns movie.",
                  "visibility": "VISIBILITY_HIDDEN",
                  "version": 1,
                  "updated_at": "2022-04-26T15:49:05.000Z",
                  "created_at": "2022-04-26T15:49:05.000Z"
                }
              ],
              "cursor": "YEk4UPbUEsu8MUV0xouO5hCiFcD9T5ztB6UWEJq5vZnqBFmoBEi0j1j6HWYTFGMRre4p7T5wAQBj3Th1NX3XgBFcQVEVsIxUQ2NsbwjRitfoEZDml9uxxQXepowyRvCuSThHPbJSn7M7wInl3x8XypQF9ahVVQXegJ0CxEKc0SBH",
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
                    .WithPath("/v2/customers/custom-attribute-definitions")
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

        var items = await Client.Default.Customers.CustomAttributeDefinitions.ListAsync(
            new Square.Default.Customers.ListCustomAttributeDefinitionsRequest
            {
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
