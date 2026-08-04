using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Rewards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Loyalty.Rewards;

[TestFixture]
public class DeleteTest : BaseMockServerTest
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/rewards/reward_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loyalty.Rewards.DeleteAsync(
            new DeleteRewardsRequest { RewardId = "reward_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteLoyaltyRewardResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
