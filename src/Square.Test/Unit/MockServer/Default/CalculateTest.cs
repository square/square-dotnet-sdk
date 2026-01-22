using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class CalculateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "order": {
                "location_id": "D7AVYMEAPJ3A3",
                "line_items": [
                  {
                    "name": "Item 1",
                    "quantity": "1",
                    "base_price_money": {
                      "amount": 500,
                      "currency": "USD"
                    }
                  },
                  {
                    "name": "Item 2",
                    "quantity": "2",
                    "base_price_money": {
                      "amount": 300,
                      "currency": "USD"
                    }
                  }
                ],
                "discounts": [
                  {
                    "name": "50% Off",
                    "percentage": "50",
                    "scope": "ORDER"
                  }
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "order": {
                "id": "id",
                "location_id": "D7AVYMEAPJ3A3",
                "reference_id": "reference_id",
                "source": {
                  "name": "name"
                },
                "customer_id": "customer_id",
                "line_items": [
                  {
                    "uid": "ULkg0tQTRK2bkU9fNv3IJD",
                    "name": "Item 1",
                    "quantity": "1",
                    "applied_discounts": [
                      {
                        "uid": "9zr9S4dxvPAixvn0lpa1VC",
                        "discount_uid": "zGsRZP69aqSSR9lq9euSPB",
                        "applied_money": {
                          "amount": 250,
                          "currency": "USD"
                        }
                      }
                    ],
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
                      "amount": 250,
                      "currency": "USD"
                    },
                    "total_money": {
                      "amount": 250,
                      "currency": "USD"
                    },
                    "total_service_charge_money": {
                      "amount": 0,
                      "currency": "USD"
                    }
                  },
                  {
                    "uid": "mumY8Nun4BC5aKe2yyx5a",
                    "name": "Item 2",
                    "quantity": "2",
                    "applied_discounts": [
                      {
                        "uid": "qa8LwwZK82FgSEkQc2HYVC",
                        "discount_uid": "zGsRZP69aqSSR9lq9euSPB",
                        "applied_money": {
                          "amount": 300,
                          "currency": "USD"
                        }
                      }
                    ],
                    "base_price_money": {
                      "amount": 300,
                      "currency": "USD"
                    },
                    "variation_total_price_money": {
                      "amount": 600,
                      "currency": "USD"
                    },
                    "gross_sales_money": {
                      "amount": 600,
                      "currency": "USD"
                    },
                    "total_tax_money": {
                      "amount": 0,
                      "currency": "USD"
                    },
                    "total_discount_money": {
                      "amount": 300,
                      "currency": "USD"
                    },
                    "total_money": {
                      "amount": 300,
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
                  {
                    "uid": "zGsRZP69aqSSR9lq9euSPB",
                    "name": "50% Off",
                    "type": "FIXED_PERCENTAGE",
                    "percentage": "50",
                    "applied_money": {
                      "amount": 550,
                      "currency": "USD"
                    },
                    "scope": "ORDER"
                  }
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
                    "amount": 550,
                    "currency": "USD"
                  },
                  "tax_money": {
                    "amount": 0,
                    "currency": "USD"
                  },
                  "discount_money": {
                    "amount": 550,
                    "currency": "USD"
                  },
                  "tip_money": {
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
                "created_at": "2020-05-18T16:30:49.614Z",
                "updated_at": "2020-05-18T16:30:49.614Z",
                "closed_at": "closed_at",
                "state": "OPEN",
                "version": 1,
                "total_money": {
                  "amount": 550,
                  "currency": "USD"
                },
                "total_tax_money": {
                  "amount": 0,
                  "currency": "USD"
                },
                "total_discount_money": {
                  "amount": 550,
                  "currency": "USD"
                },
                "total_tip_money": {
                  "amount": 0,
                  "currency": "USD"
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
                    .WithPath("/v2/orders/calculate")
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

        var response = await Client.Default.Orders.CalculateAsync(
            new CalculateOrderRequest
            {
                Order = new Order
                {
                    LocationId = "D7AVYMEAPJ3A3",
                    LineItems = new List<OrderLineItem>()
                    {
                        new OrderLineItem
                        {
                            Name = "Item 1",
                            Quantity = "1",
                            BasePriceMoney = new Money { Amount = 500, Currency = Currency.Usd },
                        },
                        new OrderLineItem
                        {
                            Name = "Item 2",
                            Quantity = "2",
                            BasePriceMoney = new Money { Amount = 300, Currency = Currency.Usd },
                        },
                    },
                    Discounts = new List<OrderLineItemDiscount>()
                    {
                        new OrderLineItemDiscount
                        {
                            Name = "50% Off",
                            Percentage = "50",
                            Scope = OrderLineItemDiscountScope.Order,
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CalculateOrderResponse>(mockResponse)).UsingDefaults()
        );
    }
}
