using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers.CustomAttributeDefinitions;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "favoritemovie",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Favorite Movie",
                "description": "The favorite movie of the customer.",
                "visibility": "VISIBILITY_READ_WRITE_VALUES",
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
                    .WithPath("/v2/customers/custom-attribute-definitions/key")
                    .WithParam("version", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Customers.CustomAttributeDefinitions.GetAsync(
            new Square.Default.Customers.CustomAttributeDefinitions.GetCustomAttributeDefinitionsRequest
            {
                Key = "key",
                Version = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<GetCustomerCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
