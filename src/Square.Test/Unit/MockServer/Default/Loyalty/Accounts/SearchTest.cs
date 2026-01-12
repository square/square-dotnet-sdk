using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Accounts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Accounts;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "mappings": [
                  {
                    "phone_number": "+14155551234"
                  }
                ]
              },
              "limit": 10
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
              "loyalty_accounts": [
                {
                  "id": "79b807d2-d786-46a9-933b-918028d7a8c5",
                  "program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                  "balance": 10,
                  "lifetime_points": 20,
                  "customer_id": "Q8002FAM9V1EZ0ADB2T5609X6NET1H0",
                  "enrolled_at": "enrolled_at",
                  "created_at": "2020-05-08T21:44:32.000Z",
                  "updated_at": "2020-05-08T21:44:32.000Z",
                  "mapping": {
                    "id": "66aaab3f-da99-49ed-8b19-b87f851c844f",
                    "created_at": "2020-05-08T21:44:32.000Z",
                    "phone_number": "+14155551234"
                  },
                  "expiring_point_deadlines": [
                    {
                      "points": 1,
                      "expires_at": "expires_at"
                    }
                  ]
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/accounts/search")
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

        var response = await Client.Default.Loyalty.Accounts.SearchAsync(
            new SearchLoyaltyAccountsRequest
            {
                Query = new SearchLoyaltyAccountsRequestLoyaltyAccountQuery
                {
                    Mappings = new List<LoyaltyAccountMapping>()
                    {
                        new LoyaltyAccountMapping { PhoneNumber = "+14155551234" },
                    },
                },
                Limit = 10,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchLoyaltyAccountsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
