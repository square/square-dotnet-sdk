using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class SearchEventsTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "order_filter": {
                    "order_id": "PyATxhYLfsMqpVkcKJITPydgEYfZY"
                  }
                }
              },
              "limit": 30
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
              "events": [
                {
                  "id": "c27c8465-806e-36f2-b4b3-71f5887b5ba8",
                  "type": "ACCUMULATE_POINTS",
                  "created_at": "2020-05-08T22:01:30.000Z",
                  "accumulate_points": {
                    "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                    "points": 5,
                    "order_id": "PyATxhYLfsMqpVkcKJITPydgEYfZY"
                  },
                  "create_reward": {
                    "loyalty_program_id": "loyalty_program_id",
                    "points": 1
                  },
                  "redeem_reward": {
                    "loyalty_program_id": "loyalty_program_id"
                  },
                  "delete_reward": {
                    "loyalty_program_id": "loyalty_program_id",
                    "points": 1
                  },
                  "adjust_points": {
                    "points": 1
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
                    "points": 1,
                    "order_id": "order_id"
                  }
                },
                {
                  "id": "e4a5cbc3-a4d0-3779-98e9-e578885d9430",
                  "type": "REDEEM_REWARD",
                  "created_at": "2020-05-08T22:01:15.000Z",
                  "create_reward": {
                    "loyalty_program_id": "loyalty_program_id",
                    "points": 1
                  },
                  "redeem_reward": {
                    "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                    "reward_id": "d03f79f4-815f-3500-b851-cc1e68a457f9",
                    "order_id": "PyATxhYLfsMqpVkcKJITPydgEYfZY"
                  },
                  "delete_reward": {
                    "loyalty_program_id": "loyalty_program_id",
                    "points": 1
                  },
                  "adjust_points": {
                    "points": 1
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
                    "points": 1,
                    "order_id": "order_id"
                  }
                },
                {
                  "id": "5e127479-0b03-3671-ab1e-15faea8b7188",
                  "type": "CREATE_REWARD",
                  "created_at": "2020-05-08T22:00:44.000Z",
                  "create_reward": {
                    "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                    "reward_id": "d03f79f4-815f-3500-b851-cc1e68a457f9",
                    "points": -10
                  },
                  "redeem_reward": {
                    "loyalty_program_id": "loyalty_program_id"
                  },
                  "delete_reward": {
                    "loyalty_program_id": "loyalty_program_id",
                    "points": 1
                  },
                  "adjust_points": {
                    "points": 1
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
                    "points": 1,
                    "order_id": "order_id"
                  }
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/events/search")
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

        var response = await Client.Loyalty.SearchEventsAsync(
            new SearchLoyaltyEventsRequest
            {
                Query = new LoyaltyEventQuery
                {
                    Filter = new LoyaltyEventFilter
                    {
                        OrderFilter = new LoyaltyEventOrderFilter
                        {
                            OrderId = "PyATxhYLfsMqpVkcKJITPydgEYfZY",
                        },
                    },
                },
                Limit = 30,
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchLoyaltyEventsResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
