using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Accounts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Accounts;

[TestFixture]
public class AdjustTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "bc29a517-3dc9-450e-aa76-fae39ee849d1",
              "adjust_points": {
                "points": 10,
                "reason": "Complimentary points"
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
              "event": {
                "id": "613a6fca-8d67-39d0-bad2-3b4bc45c8637",
                "type": "ADJUST_POINTS",
                "created_at": "2020-05-08T21:42:32.000Z",
                "accumulate_points": {
                  "loyalty_program_id": "loyalty_program_id",
                  "points": 1,
                  "order_id": "order_id"
                },
                "create_reward": {
                  "loyalty_program_id": "loyalty_program_id",
                  "reward_id": "reward_id",
                  "points": 1
                },
                "redeem_reward": {
                  "loyalty_program_id": "loyalty_program_id",
                  "reward_id": "reward_id",
                  "order_id": "order_id"
                },
                "delete_reward": {
                  "loyalty_program_id": "loyalty_program_id",
                  "reward_id": "reward_id",
                  "points": 1
                },
                "adjust_points": {
                  "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                  "points": 10,
                  "reason": "Complimentary points"
                },
                "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                "location_id": "location_id",
                "source": "LOYALTY_API",
                "expire_points": {
                  "loyalty_program_id": "loyalty_program_id",
                  "points": 1
                },
                "other_event": {
                  "loyalty_program_id": "loyalty_program_id",
                  "points": 1
                },
                "accumulate_promotion_points": {
                  "loyalty_program_id": "loyalty_program_id",
                  "loyalty_promotion_id": "loyalty_promotion_id",
                  "points": 1,
                  "order_id": "order_id"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/accounts/account_id/adjust")
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

        var response = await Client.Default.Loyalty.Accounts.AdjustAsync(
            new AdjustLoyaltyPointsRequest
            {
                AccountId = "account_id",
                IdempotencyKey = "bc29a517-3dc9-450e-aa76-fae39ee849d1",
                AdjustPoints = new LoyaltyEventAdjustPoints
                {
                    Points = 10,
                    Reason = "Complimentary points",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AdjustLoyaltyPointsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
