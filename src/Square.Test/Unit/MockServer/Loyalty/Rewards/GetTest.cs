using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Rewards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Loyalty.Rewards;

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
              "reward": {
                "id": "9f18ac21-233a-31c3-be77-b45840f5a810",
                "status": "REDEEMED",
                "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                "points": 10,
                "order_id": "order_id",
                "created_at": "2020-05-08T21:55:42.000Z",
                "updated_at": "2020-05-08T21:56:00.000Z",
                "redeemed_at": "2020-05-08T21:56:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/rewards/reward_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loyalty.Rewards.GetAsync(
            new GetRewardsRequest { RewardId = "reward_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetLoyaltyRewardResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
