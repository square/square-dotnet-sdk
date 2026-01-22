using NUnit.Framework;
using Square;
using Square.Core;
using Square.Merchants.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Merchants.CustomAttributes;

[TestFixture]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute": {
                "value": "Ultimate Sneaker Store"
              }
            }
            """;

        const string mockResponse = """
            {
              "custom_attribute": {
                "key": "alternative_seller_name",
                "value": "Ultimate Sneaker Store",
                "version": 2,
                "visibility": "VISIBILITY_READ_ONLY",
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
                "updated_at": "2023-05-06T19:21:04.551Z",
                "created_at": "2023-05-06T19:02:58.647Z"
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
                    .WithPath("/v2/merchants/merchant_id/custom-attributes/key")
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

        var response = await Client.Merchants.CustomAttributes.UpsertAsync(
            new UpsertMerchantCustomAttributeRequest
            {
                MerchantId = "merchant_id",
                Key = "key",
                CustomAttribute = new CustomAttribute { Value = "Ultimate Sneaker Store" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpsertMerchantCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
