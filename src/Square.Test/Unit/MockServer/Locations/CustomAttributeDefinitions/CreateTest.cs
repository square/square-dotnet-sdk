using NUnit.Framework;
using Square;
using Square.Core;
using Square.Locations.CustomAttributeDefinitions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Locations.CustomAttributeDefinitions;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {
                "key": "bestseller",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Bestseller",
                "description": "Bestselling item at location",
                "visibility": "VISIBILITY_READ_WRITE_VALUES"
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "bestseller",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Bestseller",
                "description": "Bestselling item at location",
                "visibility": "VISIBILITY_READ_WRITE_VALUES",
                "version": 1,
                "updated_at": "2022-12-02T19:06:36.559Z",
                "created_at": "2022-12-02T19:06:36.559Z"
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
                    .WithPath("/v2/locations/custom-attribute-definitions")
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

        var response = await Client.Locations.CustomAttributeDefinitions.CreateAsync(
            new CreateLocationCustomAttributeDefinitionRequest
            {
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Key = "bestseller",
                    Schema = new Dictionary<string, object?>()
                    {
                        {
                            "$ref",
                            "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                        },
                    },
                    Name = "Bestseller",
                    Description = "Bestselling item at location",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<CreateLocationCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
