using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Merchants.CustomAttributeDefinitions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributeDefinitions;

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
                "key": "alternative_seller_name",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Alternative Merchant Name",
                "description": "Update the description as desired.",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 2,
                "updated_at": "2023-05-05T19:34:10.181Z",
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
                    .WithPath("/v2/merchants/custom-attribute-definitions/key")
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

        var response = await Client.Default.Merchants.CustomAttributeDefinitions.UpdateAsync(
            new UpdateMerchantCustomAttributeDefinitionRequest
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
                    JsonUtils.Deserialize<UpdateMerchantCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
