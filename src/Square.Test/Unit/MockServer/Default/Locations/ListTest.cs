using NUnit.Framework;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations;

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
                  "key": "phone-number",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.PhoneNumber"
                  },
                  "name": "phone number",
                  "description": "Location's phone number",
                  "visibility": "VISIBILITY_READ_ONLY",
                  "version": 1,
                  "updated_at": "2022-12-02T19:50:21.832Z",
                  "created_at": "2022-12-02T19:50:21.832Z"
                },
                {
                  "key": "bestseller",
                  "schema": {
                    "$ref": "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                  },
                  "name": "Bestseller",
                  "description": "Bestselling item at location",
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "version": 4,
                  "updated_at": "2022-12-03T10:17:52.341Z",
                  "created_at": "2022-12-02T19:06:36.559Z"
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
                    .WithPath("/v2/locations/custom-attribute-definitions")
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

        var items = await Client.Default.Locations.CustomAttributeDefinitions.ListAsync(
            new Square.Default.Locations.ListCustomAttributeDefinitionsRequest
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
