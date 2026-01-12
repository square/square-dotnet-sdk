using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders.CustomAttributeDefinitions;

[TestFixture]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
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
                    .WithPath("/v2/orders/custom-attribute-definitions/key")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Orders.CustomAttributeDefinitions.DeleteAsync(
            new Square.Default.Orders.CustomAttributeDefinitions.DeleteCustomAttributeDefinitionsRequest
            {
                Key = "key",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<DeleteOrderCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
