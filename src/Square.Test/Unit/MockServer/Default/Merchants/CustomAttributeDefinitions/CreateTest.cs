using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Merchants.CustomAttributeDefinitions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributeDefinitions;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {
                "key": "alternative_seller_name",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Alternative Merchant Name",
                "description": "This is the other name this merchant goes by.",
                "visibility": "VISIBILITY_READ_ONLY"
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "alternative_seller_name",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Alternative Merchant Name",
                "description": "This is the other name this merchant goes by.",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 1,
                "updated_at": "2023-05-05T19:06:36.559Z",
                "created_at": "2023-05-05T19:06:36.559Z"
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
                    .WithPath("/v2/merchants/custom-attribute-definitions")
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

        var response = await Client.Default.Merchants.CustomAttributeDefinitions.CreateAsync(
            new CreateMerchantCustomAttributeDefinitionRequest
            {
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Key = "alternative_seller_name",
                    Schema = new Dictionary<string, object?>()
                    {
                        {
                            "$ref",
                            "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                        },
                    },
                    Name = "Alternative Merchant Name",
                    Description = "This is the other name this merchant goes by.",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<CreateMerchantCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
