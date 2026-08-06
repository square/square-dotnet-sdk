using NUnit.Framework;
using Square;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Locations.CustomAttributes;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attributes": [
                {
                  "key": "phone-number",
                  "value": "+12223334444",
                  "version": 1,
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "updated_at": "2022-12-12T18:13:03.745Z",
                  "created_at": "2022-12-12T18:13:03.745Z"
                },
                {
                  "key": "bestseller",
                  "value": "hot cocoa",
                  "version": 1,
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "updated_at": "2022-12-12T19:27:57.975Z",
                  "created_at": "2022-12-12T19:27:57.975Z"
                }
              ],
              "cursor": "cursor",
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
                    .WithPath("/v2/locations/location_id/custom-attributes")
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

        var items = await Client.Locations.CustomAttributes.ListAsync(
            new Square.Locations.CustomAttributes.ListCustomAttributesRequest
            {
                LocationId = "location_id",
                VisibilityFilter = VisibilityFilter.All,
                Limit = 1,
                Cursor = "cursor",
                WithDefinitions = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
