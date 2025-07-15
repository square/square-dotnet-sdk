using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Accounts;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class AccumulatePointsTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "accumulate_points": {
                "order_id": "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY"
              },
              "idempotency_key": "58b90739-c3e8-4b11-85f7-e636d48d72cb",
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
                "id": "id",
                "type": "ACCUMULATE_POINTS",
                "created_at": "created_at",
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
                  "loyalty_program_id": "loyalty_program_id",
                  "points": 1,
                  "reason": "reason"
                },
                "loyalty_account_id": "loyalty_account_id",
                "location_id": "location_id",
                "source": "SQUARE",
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
              },
              "events": [
                {
                  "id": "ee46aafd-1af6-3695-a385-276e2ef0be26",
                  "type": "ACCUMULATE_POINTS",
                  "created_at": "2020-05-08T21:41:12.000Z",
                  "accumulate_points": {
                    "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                    "points": 6,
                    "order_id": "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY"
                  },
                  "adjust_points": {
                    "points": 1
                  },
                  "loyalty_account_id": "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
                  "location_id": "P034NEENMD09F",
                  "source": "LOYALTY_API",
                  "expire_points": {
                    "points": 1
                  },
                  "other_event": {
                    "points": 1
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/accounts/account_id/accumulate")
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

        var response = await Client.Loyalty.Accounts.AccumulatePointsAsync(
            new AccumulateLoyaltyPointsRequest
            {
                AccountId = "account_id",
                AccumulatePoints = new LoyaltyEventAccumulatePoints
                {
                    OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
                },
                IdempotencyKey = "58b90739-c3e8-4b11-85f7-e636d48d72cb",
                LocationId = "P034NEENMD09F",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AccumulateLoyaltyPointsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
