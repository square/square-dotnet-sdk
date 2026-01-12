using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Rewards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Rewards;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd"
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
              "rewards": [
                {
                  "id": "d03f79f4-815f-3500-b851-cc1e68a457f9",
                  "status": "REDEEMED",
                  "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                  "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                  "points": 10,
                  "order_id": "PyATxhYLfsMqpVkcKJITPydgEYfZY",
                  "created_at": "2020-05-08T22:00:44.000Z",
                  "updated_at": "2020-05-08T22:01:17.000Z",
                  "redeemed_at": "2020-05-08T22:01:17.000Z"
                },
                {
                  "id": "9f18ac21-233a-31c3-be77-b45840f5a810",
                  "status": "REDEEMED",
                  "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                  "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                  "points": 10,
                  "order_id": "order_id",
                  "created_at": "2020-05-08T21:55:42.000Z",
                  "updated_at": "2020-05-08T21:56:00.000Z",
                  "redeemed_at": "2020-05-08T21:56:00.000Z"
                },
                {
                  "id": "a8f43ebe-2ad6-3001-bdd5-7d7c2da08943",
                  "status": "DELETED",
                  "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                  "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                  "points": 10,
                  "order_id": "5NB69ZNh3FbsOs1ox43bh1xrli6YY",
                  "created_at": "2020-05-01T21:49:54.000Z",
                  "updated_at": "2020-05-08T21:55:10.000Z",
                  "redeemed_at": "redeemed_at"
                },
                {
                  "id": "a051254c-f840-3b45-8cf1-50bcd38ff92a",
                  "status": "ISSUED",
                  "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                  "reward_tier_id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                  "points": 10,
                  "order_id": "LQQ16znvi2VIUKPVhUfJefzr1eEZY",
                  "created_at": "2020-05-01T20:20:37.000Z",
                  "updated_at": "2020-05-01T20:20:40.000Z",
                  "redeemed_at": "redeemed_at"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/rewards/search")
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

        var response = await Client.Default.Loyalty.Rewards.SearchAsync(
            new SearchLoyaltyRewardsRequest
            {
                Query = new SearchLoyaltyRewardsRequestLoyaltyRewardQuery
                {
                    LoyaltyAccountId = "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                },
                Limit = 10,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchLoyaltyRewardsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
