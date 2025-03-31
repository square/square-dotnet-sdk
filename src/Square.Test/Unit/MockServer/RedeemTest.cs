using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Rewards;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RedeemTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "98adc7f7-6963-473b-b29c-f3c9cdd7d994",
              "location_id": "P034NEENMD09F"
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
                "id": "67377a6e-dbdc-369d-aa16-2e7ed422e71f",
                "type": "REDEEM_REWARD",
                "created_at": "2020-05-08T21:56:00.000Z",
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
                  "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                  "reward_id": "9f18ac21-233a-31c3-be77-b45840f5a810",
                  "order_id": "order_id"
                },
                "delete_reward": {
                  "loyalty_program_id": "loyalty_program_id",
                  "reward_id": "reward_id",
                  "points": 1
                },
                "adjust_points": {
                  "loyalty_program_id": "loyalty_program_id",
                  "points": 1,
                  "reason": "reason"
                },
                "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                "location_id": "P034NEENMD09F",
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
                    .WithPath("/v2/loyalty/rewards/reward_id/redeem")
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

        var response = await Client.Loyalty.Rewards.RedeemAsync(
            new RedeemLoyaltyRewardRequest
            {
                RewardId = "reward_id",
                IdempotencyKey = "98adc7f7-6963-473b-b29c-f3c9cdd7d994",
                LocationId = "P034NEENMD09F",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RedeemLoyaltyRewardResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
