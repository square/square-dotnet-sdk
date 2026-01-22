using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Orders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders;

[TestFixture]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute": {
                "key": "table-number",
                "value": "42",
                "version": 1
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute": {
                "key": "table-number",
                "value": "42",
                "version": 1,
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
                "updated_at": "2022-10-06T20:41:22.673Z",
                "created_at": "2022-10-06T20:41:22.673Z"
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
                    .WithPath("/v2/orders/order_id/custom-attributes/custom_attribute_key")
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

        var response = await Client.Default.Orders.CustomAttributes.UpsertAsync(
            new UpsertOrderCustomAttributeRequest
            {
                OrderId = "order_id",
                CustomAttributeKey = "custom_attribute_key",
                CustomAttribute = new CustomAttribute
                {
                    Key = "table-number",
                    Value = "42",
                    Version = 1,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpsertOrderCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
