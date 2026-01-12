using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributeDefinitions;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/v2/merchants/custom-attribute-definitions/key")
                    .WithParam("version", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Merchants.CustomAttributeDefinitions.GetAsync(
            new Square.Default.Merchants.CustomAttributeDefinitions.GetCustomAttributeDefinitionsRequest
            {
                Key = "key",
                Version = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<RetrieveMerchantCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
