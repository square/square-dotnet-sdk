using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Orders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {
                "key": "cover-count",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 1
              },
              "idempotency_key": "IDEMPOTENCY_KEY"
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "cover-count",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                },
                "name": "Cover count",
                "description": "The number of people seated at a table",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 2,
                "updated_at": "2022-11-16T17:44:11.436Z",
                "created_at": "2022-11-16T16:53:23.141Z"
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
                    .WithPath("/v2/orders/custom-attribute-definitions/key")
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

        var response = await Client.Default.Orders.CustomAttributeDefinitions.UpdateAsync(
            new UpdateOrderCustomAttributeDefinitionRequest
            {
                Key = "key",
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Key = "cover-count",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
                    Version = 1,
                },
                IdempotencyKey = "IDEMPOTENCY_KEY",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<UpdateOrderCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
