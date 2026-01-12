using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Orders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders;

[TestFixture]
public class BatchGetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location_id": "057P5VYJ4A5X1",
              "order_ids": [
                "CAISEM82RcpmcFBM0TfOyiHV3es",
                "CAISENgvlJ6jLWAzERDzjyHVybY"
              ]
            }
            """;

        const string mockResponse = """
            {
              "orders": [
                {
                  "id": "CAISEM82RcpmcFBM0TfOyiHV3es",
                  "location_id": "057P5VYJ4A5X1",
                  "reference_id": "my-order-001",
                  "customer_id": "customer_id",
                  "line_items": [
                    {
                      "uid": "945986d1-9586-11e6-ad5a-28cfe92138cf",
                      "name": "Awesome product",
                      "quantity": "1",
                      "base_price_money": {
                        "amount": 1599,
                        "currency": "USD"
                      },
                      "total_money": {
                        "amount": 1599,
                        "currency": "USD"
                      }
                    },
                    {
                      "uid": "a8f4168c-9586-11e6-bdf0-28cfe92138cf",
                      "name": "Another awesome product",
                      "quantity": "3",
                      "base_price_money": {
                        "amount": 2000,
                        "currency": "USD"
                      },
                      "total_money": {
                        "amount": 6000,
                        "currency": "USD"
                      }
                    }
                  ],
                  "taxes": [
                    {}
                  ],
                  "discounts": [
                    {}
                  ],
                  "service_charges": [
                    {}
                  ],
                  "fulfillments": [
                    {}
                  ],
                  "returns": [
                    {}
                  ],
                  "tenders": [
                    {
                      "type": "CARD"
                    }
                  ],
                  "refunds": [
                    {
                      "id": "id",
                      "location_id": "location_id",
                      "reason": "reason",
                      "amount_money": {},
                      "status": "PENDING"
                    }
                  ],
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "closed_at": "closed_at",
                  "state": "OPEN",
                  "version": 1,
                  "total_money": {
                    "amount": 7599,
                    "currency": "USD"
                  },
                  "ticket_name": "ticket_name",
                  "rewards": [
                    {
                      "id": "id",
                      "reward_tier_id": "reward_tier_id"
                    }
                  ]
                }
              ],
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
                    .WithPath("/v2/orders/batch-retrieve")
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

        var response = await Client.Default.Orders.BatchGetAsync(
            new BatchGetOrdersRequest
            {
                LocationId = "057P5VYJ4A5X1",
                OrderIds = new List<string>()
                {
                    "CAISEM82RcpmcFBM0TfOyiHV3es",
                    "CAISENgvlJ6jLWAzERDzjyHVybY",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchGetOrdersResponse>(mockResponse)).UsingDefaults()
        );
    }
}
