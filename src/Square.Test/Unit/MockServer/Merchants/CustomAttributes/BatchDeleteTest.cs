using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Merchants.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Merchants.CustomAttributes;

[TestFixture]
public class BatchDeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "id1": {
                  "key": "alternative_seller_name"
                },
                "id2": {
                  "key": "has_seen_tutorial"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
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
                    .WithPath("/v2/merchants/custom-attributes/bulk-delete")
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

        var response = await Client.Merchants.CustomAttributes.BatchDeleteAsync(
            new BulkDeleteMerchantCustomAttributesRequest
            {
                Values = new Dictionary<
                    string,
                    BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
                >()
                {
                    {
                        "id1",
                        new BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
                        {
                            Key = "alternative_seller_name",
                        }
                    },
                    {
                        "id2",
                        new BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
                        {
                            Key = "has_seen_tutorial",
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkDeleteMerchantCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
