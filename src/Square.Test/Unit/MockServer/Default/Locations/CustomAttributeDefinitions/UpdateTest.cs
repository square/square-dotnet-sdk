using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations.CustomAttributeDefinitions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations.CustomAttributeDefinitions;

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
                "key": "bestseller",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Bestseller",
                "description": "Update the description as desired.",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 2,
                "updated_at": "2022-12-02T19:34:10.181Z",
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
                    .WithPath("/v2/locations/custom-attribute-definitions/key")
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

        var response = await Client.Default.Locations.CustomAttributeDefinitions.UpdateAsync(
            new UpdateLocationCustomAttributeDefinitionRequest
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
                    JsonUtils.Deserialize<UpdateLocationCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
