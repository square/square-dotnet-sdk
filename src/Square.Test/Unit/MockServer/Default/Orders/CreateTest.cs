using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Orders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {
                "key": "cover-count",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                },
                "name": "Cover count",
                "description": "The number of people seated at a table",
                "visibility": "VISIBILITY_READ_WRITE_VALUES"
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
                "visibility": "VISIBILITY_READ_WRITE_VALUES",
                "version": 1,
                "updated_at": "2022-10-06T16:53:23.141Z",
                "created_at": "2022-10-06T16:53:23.141Z"
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
                    .WithPath("/v2/orders/custom-attribute-definitions")
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

        var response = await Client.Default.Orders.CustomAttributeDefinitions.CreateAsync(
            new CreateOrderCustomAttributeDefinitionRequest
            {
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Key = "cover-count",
                    Schema = new Dictionary<string, object?>()
                    {
                        {
                            "$ref",
                            "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                        },
                    },
                    Name = "Cover count",
                    Description = "The number of people seated at a table",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
                },
                IdempotencyKey = "IDEMPOTENCY_KEY",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<CreateOrderCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
