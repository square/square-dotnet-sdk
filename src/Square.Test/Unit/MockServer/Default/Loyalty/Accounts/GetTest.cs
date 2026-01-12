using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Accounts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Accounts;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
              "loyalty_account": {
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
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/accounts/account_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Loyalty.Accounts.GetAsync(
            new GetAccountsRequest { AccountId = "account_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetLoyaltyAccountResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
