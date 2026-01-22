using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Bookings;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Bookings;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute_definition": {}
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute_definition": {
                "key": "favoriteShampoo",
                "schema": {
                  "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
                "name": "Favorite shampoo",
                "description": "Update the description as desired.",
                "visibility": "VISIBILITY_READ_ONLY",
                "version": 2,
                "updated_at": "2022-11-16T15:39:38.000Z",
                "created_at": "2022-11-16T15:27:30.000Z"
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
                    .WithPath("/v2/bookings/custom-attribute-definitions/key")
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

        var response = await Client.Default.Bookings.CustomAttributeDefinitions.UpdateAsync(
            new UpdateBookingCustomAttributeDefinitionRequest
            {
                Key = "key",
                CustomAttributeDefinition = new CustomAttributeDefinition(),
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<UpdateBookingCustomAttributeDefinitionResponse>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
