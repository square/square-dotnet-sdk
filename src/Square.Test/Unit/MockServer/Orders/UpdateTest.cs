using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Orders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Orders;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "order": {
                "location_id": "location_id",
                "line_items": [
                  {
                    "uid": "cookie_uid",
                    "name": "COOKIE",
                    "quantity": "2",
                    "base_price_money": {
                      "amount": 200,
                      "currency": "USD"
                    }
                  }
                ],
                "version": 1
              },
              "fields_to_clear": [
                "discounts"
              ],
              "idempotency_key": "UNIQUE_STRING"
            }
            """;

        const string mockResponse = """
            {
              "order": {
                "id": "DREk7wJcyXNHqULq8JJ2iPAsluJZY",
                "location_id": "MXVQSVNDGN3C8",
                "reference_id": "reference_id",
                "source": {
                  "name": "Cookies"
                },
                "customer_id": "customer_id",
                "line_items": [
                  {
                    "uid": "EuYkakhmu3ksHIds5Hiot",
                    "name": "Small Coffee",
                    "quantity": "1",
                    "base_price_money": {
                      "amount": 500,
                      "currency": "USD"
                    },
                    "variation_total_price_money": {
                      "amount": 500,
                      "currency": "USD"
                    },
                    "gross_sales_money": {
                      "amount": 500,
                      "currency": "USD"
                    },
                    "total_tax_money": {
                      "amount": 0,
                      "currency": "USD"
                    },
                    "total_discount_money": {
                      "amount": 0,
                      "currency": "USD"
                    },
                    "total_money": {
                      "amount": 500,
                      "currency": "USD"
                    },
                    "total_service_charge_money": {
                      "amount": 0,
                      "currency": "USD"
                    }
                  },
                  {
                    "uid": "cookie_uid",
                    "name": "COOKIE",
                    "quantity": "2",
                    "base_price_money": {
                      "amount": 200,
                      "currency": "USD"
                    },
                    "variation_total_price_money": {
                      "amount": 400,
                      "currency": "USD"
                    },
                    "gross_sales_money": {
                      "amount": 400,
                      "currency": "USD"
                    },
                    "total_tax_money": {
                      "amount": 0,
                      "currency": "USD"
                    },
                    "total_discount_money": {
                      "amount": 0,
                      "currency": "USD"
                    },
                    "total_money": {
                      "amount": 400,
                      "currency": "USD"
                    },
                    "total_service_charge_money": {
                      "amount": 0,
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
                "net_amounts": {
                  "total_money": {
                    "amount": 900,
                    "currency": "USD"
                  },
                  "tax_money": {
                    "amount": 0,
                    "currency": "USD"
                  },
                  "discount_money": {
                    "amount": 0,
                    "currency": "USD"
                  },
                  "service_charge_money": {
                    "amount": 0,
                    "currency": "USD"
                  }
                },
                "rounding_adjustment": {
                  "uid": "uid",
                  "name": "name"
                },
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
                "metadata": {
                  "key": "value"
                },
                "created_at": "2019-08-23T18:26:18.243Z",
                "updated_at": "2019-08-23T18:33:47.523Z",
                "closed_at": "closed_at",
                "state": "OPEN",
                "version": 2,
                "total_money": {
                  "amount": 900,
                  "currency": "USD"
                },
                "total_tax_money": {
                  "amount": 0,
                  "currency": "USD"
                },
                "total_discount_money": {
                  "amount": 0,
                  "currency": "USD"
                },
                "total_tip_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "total_service_charge_money": {
                  "amount": 0,
                  "currency": "USD"
                },
                "ticket_name": "ticket_name",
                "pricing_options": {
                  "auto_apply_discounts": true,
                  "auto_apply_taxes": true
                },
                "rewards": [
                  {
                    "id": "id",
                    "reward_tier_id": "reward_tier_id"
                  }
                ],
                "net_amount_due_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                }
              },
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
                    .WithPath("/v2/orders/order_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.UpdateAsync(
            new UpdateOrderRequest
            {
                OrderId = "order_id",
                Order = new Order
                {
                    LocationId = "location_id",
                    LineItems = new List<OrderLineItem>()
                    {
                        new OrderLineItem
                        {
                            Uid = "cookie_uid",
                            Name = "COOKIE",
                            Quantity = "2",
                            BasePriceMoney = new Money { Amount = 200, Currency = Currency.Usd },
                        },
                    },
                    Version = 1,
                },
                FieldsToClear = new List<string>() { "discounts" },
                IdempotencyKey = "UNIQUE_STRING",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateOrderResponse>(mockResponse)).UsingDefaults()
        );
    }
}
