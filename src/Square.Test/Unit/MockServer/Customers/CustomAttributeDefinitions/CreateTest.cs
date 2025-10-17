using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.CustomAttributeDefinitions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.CustomAttributeDefinitions;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {
                "key": "favoritemovie",
                "schema": {
                  "\\$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Favorite Movie",
                "description": "The favorite movie of the customer.",
                "visibility": "VISIBILITY_HIDDEN"
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "favoritemovie",
                "schema": {
                  "\\$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Favorite Movie",
                "description": "The favorite movie of the customer.",
                "visibility": "VISIBILITY_HIDDEN",
                "version": 1,
                "updated_at": "2022-04-26T15:27:30.000Z",
                "created_at": "2022-04-26T15:27:30.000Z"
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
                    .WithPath("/v2/customers/custom-attribute-definitions")
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

        var response = await Client.Customers.CustomAttributeDefinitions.CreateAsync(
            new CreateCustomerCustomAttributeDefinitionRequest
            {
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Key = "favoritemovie",
                    Schema = new Dictionary<string, object?>()
                    {
                        {
                            "$ref",
                            "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                        },
                    },
                    Name = "Favorite Movie",
                    Description = "The favorite movie of the customer.",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityHidden,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<CreateCustomerCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
