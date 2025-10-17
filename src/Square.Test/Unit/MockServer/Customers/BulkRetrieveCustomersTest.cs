using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers;

[TestFixture]
public class BulkRetrieveCustomersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
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
                  ],
                  "customer": {
                    "id": "8DDA5NZVBZFGAX0V3HPF81HHE0",
                    "created_at": "2024-01-19T00:27:54.590Z",
                    "updated_at": "2024-01-19T00:38:06.000Z",
                    "given_name": "Amelia",
                    "family_name": "Earhart",
                    "email_address": "New.Amelia.Earhart@example.com",
                    "birthday": "1897-07-24",
                    "note": "updated customer note",
                    "preferences": {
                      "email_unsubscribed": false
                    },
                    "creation_source": "THIRD_PARTY",
                    "version": 3
                  }
                },
                "N18CPRVXR5214XPBBA6BZQWF3C": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "customer": {
                    "id": "N18CPRVXR5214XPBBA6BZQWF3C",
                    "created_at": "2024-01-19T00:27:54.590Z",
                    "updated_at": "2024-01-19T00:38:06.000Z",
                    "given_name": "Marie",
                    "family_name": "Curie",
                    "preferences": {
                      "email_unsubscribed": false
                    },
                    "creation_source": "THIRD_PARTY",
                    "version": 1
                  }
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
                    .WithPath("/v2/customers/bulk-retrieve")
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

        var response = await Client.Customers.BulkRetrieveCustomersAsync(
            new BulkRetrieveCustomersRequest
            {
                CustomerIds = new List<string>()
                {
                    "8DDA5NZVBZFGAX0V3HPF81HHE0",
                    "N18CPRVXR5214XPBBA6BZQWF3C",
                    "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkRetrieveCustomersResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
