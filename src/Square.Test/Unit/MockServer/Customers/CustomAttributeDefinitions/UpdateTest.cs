using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.CustomAttributeDefinitions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.CustomAttributeDefinitions;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {
                "description": "Update the description as desired.",
                "visibility": "VISIBILITY_READ_ONLY"
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "favoritemovie",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Favorite Movie",
                "description": "Update the description as desired.",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 2,
                "updated_at": "2022-04-26T15:39:38.000Z",
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
                    .WithPath("/v2/customers/custom-attribute-definitions/key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.CustomAttributeDefinitions.UpdateAsync(
            new UpdateCustomerCustomAttributeDefinitionRequest
            {
                Key = "key",
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Description = "Update the description as desired.",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<UpdateCustomerCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
