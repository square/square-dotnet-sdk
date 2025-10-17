using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Orders.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Orders.CustomAttributes;

[TestFixture]
public class BatchUpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "cover-count": {
                  "custom_attribute": {
                    "key": "cover-count",
                    "value": "6",
                    "version": 2
                  },
                  "order_id": "7BbXGEIWNldxAzrtGf9GPVZTwZ4F"
                },
                "table-number": {
                  "custom_attribute": {
                    "key": "table-number",
                    "value": "11",
                    "version": 4
                  },
                  "order_id": "7BbXGEIWNldxAzrtGf9GPVZTwZ4F"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "values": {
                "cover-count": {
                  "custom_attribute": {
                    "key": "cover-count",
                    "value": "6",
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2022-11-22T21:28:35.721Z",
                    "created_at": "2022-11-22T21:27:33.429Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "table-number": {
                  "custom_attribute": {
                    "key": "table-number",
                    "value": "11",
                    "visibility": "VISIBILITY_HIDDEN",
                    "updated_at": "2022-11-22T21:28:35.726Z",
                    "created_at": "2022-11-22T21:24:57.823Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/orders/custom-attributes/bulk-upsert")
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

        var response = await Client.Orders.CustomAttributes.BatchUpsertAsync(
            new BulkUpsertOrderCustomAttributesRequest
            {
                Values = new Dictionary<
                    string,
                    BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
                >()
                {
                    {
                        "cover-count",
                        new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
                        {
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "cover-count",
                                Value = "6",
                                Version = 2,
                            },
                            OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
                        }
                    },
                    {
                        "table-number",
                        new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
                        {
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "table-number",
                                Value = "11",
                                Version = 4,
                            },
                            OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkUpsertOrderCustomAttributesResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
