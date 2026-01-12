using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations.CustomAttributes;

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
                    .WithPath("/v2/locations/location_id/custom-attributes/key")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Locations.CustomAttributes.DeleteAsync(
            new Square.Default.Locations.CustomAttributes.DeleteCustomAttributesRequest
            {
                LocationId = "location_id",
                Key = "key",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteLocationCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
