using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Rewards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Loyalty.Rewards;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "reward": {
                "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                "order_id": "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY"
              },
              "idempotency_key": "18c2e5ea-a620-4b1f-ad60-7b167285e451"
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
              "reward": {
                "id": "a8f43ebe-2ad6-3001-bdd5-7d7c2da08943",
                "status": "ISSUED",
                "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                "points": 10,
                "order_id": "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
                "created_at": "2020-05-01T21:49:54.000Z",
                "updated_at": "2020-05-01T21:49:54.000Z",
                "redeemed_at": "redeemed_at"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/rewards")
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

        var response = await Client.Loyalty.Rewards.CreateAsync(
            new CreateLoyaltyRewardRequest
            {
                Reward = new LoyaltyReward
                {
                    LoyaltyAccountId = "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                    RewardTierId = "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                    OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
                },
                IdempotencyKey = "18c2e5ea-a620-4b1f-ad60-7b167285e451",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateLoyaltyRewardResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
