using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers;

[TestFixture]
public class BulkUpdateCustomersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customers": {
                "8DDA5NZVBZFGAX0V3HPF81HHE0": {
                  "email_address": "New.Amelia.Earhart@example.com",
                  "note": "updated customer note",
                  "version": 2
                },
                "N18CPRVXR5214XPBBA6BZQWF3C": {
                  "given_name": "Marie",
                  "family_name": "Curie",
                  "version": 0
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "responses": {
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
                    .WithPath("/v2/customers/bulk-update")
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

        var response = await Client.Default.Customers.BulkUpdateCustomersAsync(
            new BulkUpdateCustomersRequest
            {
                Customers = new Dictionary<string, BulkUpdateCustomerData>()
                {
                    {
                        "8DDA5NZVBZFGAX0V3HPF81HHE0",
                        new BulkUpdateCustomerData
                        {
                            EmailAddress = "New.Amelia.Earhart@example.com",
                            Note = "updated customer note",
                            Version = 2,
                        }
                    },
                    {
                        "N18CPRVXR5214XPBBA6BZQWF3C",
                        new BulkUpdateCustomerData
                        {
                            GivenName = "Marie",
                            FamilyName = "Curie",
                            Version = 0,
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkUpdateCustomersResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
