using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Orders.CustomAttributes;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class BatchDeleteTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "cover-count": {
                  "order_id": "7BbXGEIWNldxAzrtGf9GPVZTwZ4F"
                },
                "table-number": {
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
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "table-number": {
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
                    .WithPath("/v2/orders/custom-attributes/bulk-delete")
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

        try
        {
            var response = await Client.Orders.CustomAttributes.BatchDeleteAsync(
                new BulkDeleteOrderCustomAttributesRequest
                {
                    Values = new Dictionary<
                        string,
                        BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                    >()
                    {
                        {
                            "cover-count",
                            new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                            {
                                Key = "cover-count",
                                OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
                            }
                        },
                        {
                            "table-number",
                            new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                            {
                                Key = "table-number",
                                OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
                            }
                        },
                    },
                },
                RequestOptions
            );
            Assert.That(
                response,
                Is.EqualTo(
                        JsonUtils.Deserialize<BulkDeleteOrderCustomAttributesResponse>(mockResponse)
                    )
                    .UsingPropertiesComparer()
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
