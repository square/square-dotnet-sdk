using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class BulkDeleteCustomersTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "customer_ids": [
                "8DDA5NZVBZFGAX0V3HPF81HHE0",
                "N18CPRVXR5214XPBBA6BZQWF3C",
                "2GYD7WNXF7BJZW1PMGNXZ3Y8M8"
              ]
            }
            """;

        const string mockResponse = """
            {
              "responses": {
                "2GYD7WNXF7BJZW1PMGNXZ3Y8M8": {
                  "errors": [
                    {
                      "category": "INVALID_REQUEST_ERROR",
                      "code": "NOT_FOUND",
                      "detail": "Customer with ID `2GYD7WNXF7BJZW1PMGNXZ3Y8M8` not found."
                    }
                  ]
                },
                "8DDA5NZVBZFGAX0V3HPF81HHE0": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "N18CPRVXR5214XPBBA6BZQWF3C": {
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
                    .WithPath("/v2/customers/bulk-delete")
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

        var response = await Client.Customers.BulkDeleteCustomersAsync(
            new BulkDeleteCustomersRequest
            {
                CustomerIds = new List<string>()
                {
                    "8DDA5NZVBZFGAX0V3HPF81HHE0",
                    "N18CPRVXR5214XPBBA6BZQWF3C",
                    "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
                },
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkDeleteCustomersResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
