using NUnit.Framework;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributes;

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
                  "key": "has_seen_tutorial",
                  "value": true,
                  "version": 1,
                  "visibility": "VISIBILITY_READ_WRITE_VALUES",
                  "updated_at": "2023-05-05T18:13:03.745Z",
                  "created_at": "2023-05-05T18:13:03.745Z"
                },
                {
                  "key": "alternative_seller_name",
                  "value": "Ultimate Sneaker Store",
                  "version": 1,
                  "visibility": "VISIBILITY_READ_ONLY",
                  "updated_at": "2023-05-05T19:27:57.975Z",
                  "created_at": "2023-05-05T19:27:57.975Z"
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
                    .WithPath("/v2/merchants/merchant_id/custom-attributes")
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

        var items = await Client.Default.Merchants.CustomAttributes.ListAsync(
            new Square.Default.Merchants.CustomAttributes.ListCustomAttributesRequest
            {
                MerchantId = "merchant_id",
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
