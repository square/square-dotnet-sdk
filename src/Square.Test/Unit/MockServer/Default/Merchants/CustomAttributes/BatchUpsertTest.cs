using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Merchants.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributes;

[TestFixture]
public class BatchUpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "id1": {
                  "merchant_id": "DM7VKY8Q63GNP",
                  "custom_attribute": {
                    "key": "alternative_seller_name",
                    "value": "Ultimate Sneaker Store"
                  }
                },
                "id2": {
                  "merchant_id": "DM7VKY8Q63GNP",
                  "custom_attribute": {
                    "key": "has_seen_tutorial",
                    "value": true
                  }
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "merchant_id": "DM7VKY8Q63GNP",
                  "custom_attribute": {
                    "key": "alternative_seller_name",
                    "value": "Ultimate Sneaker Store",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_ONLY",
                    "updated_at": "2023-05-06T19:21:04.551Z",
                    "created_at": "2023-05-06T19:02:58.647Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
                  "merchant_id": "DM7VKY8Q63GNP",
                  "custom_attribute": {
                    "key": "has_seen_tutorial",
                    "value": true,
                    "version": 1,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2023-05-06T19:21:04.551Z",
                    "created_at": "2023-05-06T19:02:58.647Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                }
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
                    .WithPath("/v2/merchants/custom-attributes/bulk-upsert")
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

        var response = await Client.Default.Merchants.CustomAttributes.BatchUpsertAsync(
            new BulkUpsertMerchantCustomAttributesRequest
            {
                Values = new Dictionary<
                    string,
                    BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                >()
                {
                    {
                        "id1",
                        new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                        {
                            MerchantId = "DM7VKY8Q63GNP",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "alternative_seller_name",
                                Value = "Ultimate Sneaker Store",
                            },
                        }
                    },
                    {
                        "id2",
                        new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                        {
                            MerchantId = "DM7VKY8Q63GNP",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "has_seen_tutorial",
                                Value = true,
                            },
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkUpsertMerchantCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
