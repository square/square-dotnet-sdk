using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Bookings.CustomAttributeDefinitions;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings.CustomAttributeDefinitions;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {}
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "favoriteShampoo",
                "schema": {
                  "\\$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Favorite Shampoo",
                "description": "The favorite shampoo of the customer.",
                "visibility": "VISIBILITY_HIDDEN",
                "version": 1,
                "updated_at": "2022-11-16T15:27:30.000Z",
                "created_at": "2022-11-16T15:27:30.000Z"
              },
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
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bookings.CustomAttributeDefinitions.CreateAsync(
            new CreateBookingCustomAttributeDefinitionRequest
            {
                CustomAttributeDefinition = new CustomAttributeDefinition(),
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<CreateBookingCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
