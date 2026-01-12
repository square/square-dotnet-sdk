using NUnit.Framework;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributeDefinitions;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attribute_definitions": [
                {
                  "key": "has_seen_tutorial",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Boolean"
                  },
                  "name": "NAME",
                  "description": "Whether the merchant has seen the tutorial screen for using the app.",
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "version": 1,
                  "updated_at": "2023-05-05T16:50:21.832Z",
                  "created_at": "2023-05-05T16:50:21.832Z"
                },
                {
                  "key": "alternative_seller_name",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                  },
                  "name": "Alternative Merchant Name",
                  "description": "This is the other name this merchant goes by.",
                  "visibility": "VISIBILITY_READ_ONLY",
                  "version": 4,
                  "updated_at": "2023-05-05T10:17:52.341Z",
                  "created_at": "2023-05-05T19:06:36.559Z"
                }
              ],
              "cursor": "ImfNzWVSiAYyiAR4gEcxDJ75KZAOSjX8H2BVHUTR0ofCtp4SdYvrUKbwYY2aCH2WqZ2FsfAuylEVUlTfaINg3ecIlFpP9Y5Ie66w9NSg9nqdI5fCJ6qdH2s0za5m2plFonsjIuFaoN89j78ROUwuSOzD6mFZPcJHhJ0CxEKc0SBH",
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
                    .WithParam("visibility_filter", "ALL")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Merchants.CustomAttributeDefinitions.ListAsync(
            new Square.Default.Merchants.CustomAttributeDefinitions.ListCustomAttributeDefinitionsRequest
            {
                VisibilityFilter = VisibilityFilter.All,
                Limit = 1,
                Cursor = "cursor",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
