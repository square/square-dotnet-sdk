using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations.CustomAttributes;

[TestFixture]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute": {
                "value": "hot cocoa"
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute": {
                "key": "bestseller",
                "value": "hot cocoa",
                "version": 2,
                "visibility": "VISIBILITY_READ_WRITE_VALUES",
                "definition": {
                  "key": "key",
                  "schema": {
                    "key": "value"
                  },
                  "name": "name",
                  "description": "description",
                  "visibility": "VISIBILITY_HIDDEN",
                  "version": 1,
                  "updated_at": "updated_at",
                  "created_at": "created_at"
                },
                "updated_at": "2023-01-09T19:21:04.551Z",
                "created_at": "2023-01-09T19:02:58.647Z"
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
                    .WithPath("/v2/locations/location_id/custom-attributes/key")
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

        var response = await Client.Default.Locations.CustomAttributes.UpsertAsync(
            new UpsertLocationCustomAttributeRequest
            {
                LocationId = "location_id",
                Key = "key",
                CustomAttribute = new CustomAttribute { Value = "hot cocoa" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpsertLocationCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
