using System.Threading.Tasks;
using NUnit.Framework;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.CustomAttributeDefinitions;

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
                  "key": "favoriteShampoo",
                  "schema": {
                    "\\$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                  },
                  "name": "Favorite shampoo",
                  "description": "Update the description as desired.",
                  "visibility": "VISIBILITY_READ_ONLY",
                  "version": 3,
                  "updated_at": "2022-11-16T15:39:38.000Z",
                  "created_at": "2022-11-16T15:27:30.000Z"
                },
                {
                  "key": "partySize",
                  "schema": {
                    "\\$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                  },
                  "name": "Party size",
                  "description": "Number of people in the party for dine-in",
                  "visibility": "VISIBILITY_HIDDEN",
                  "version": 1,
                  "updated_at": "2022-11-16T15:49:05.000Z",
                  "created_at": "2022-11-16T15:49:05.000Z"
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
                    .WithPath("/v2/bookings/custom-attribute-definitions")
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

        var items = await Client.Bookings.CustomAttributeDefinitions.ListAsync(
            new Square.Bookings.CustomAttributeDefinitions.ListCustomAttributeDefinitionsRequest
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
