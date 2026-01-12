using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Accounts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Accounts;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "loyalty_account": {
                "program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                "mapping": {
                  "phone_number": "+14155551234"
                }
              },
              "idempotency_key": "ec78c477-b1c3-4899-a209-a4e71337c996"
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
              "loyalty_account": {
                "id": "79b807d2-d786-46a9-933b-918028d7a8c5",
                "program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                "balance": 0,
                "lifetime_points": 0,
                "customer_id": "QPTXM8PQNX3Q726ZYHPMNP46XC",
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
                    .WithPath("/v2/loyalty/accounts")
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

        var response = await Client.Default.Loyalty.Accounts.CreateAsync(
            new CreateLoyaltyAccountRequest
            {
                LoyaltyAccount = new LoyaltyAccount
                {
                    ProgramId = "d619f755-2d17-41f3-990d-c04ecedd64dd",
                    Mapping = new LoyaltyAccountMapping { PhoneNumber = "+14155551234" },
                },
                IdempotencyKey = "ec78c477-b1c3-4899-a209-a4e71337c996",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateLoyaltyAccountResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
