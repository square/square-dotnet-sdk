using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Orders;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class CloneTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "order_id": "ZAISEM52YcpmcWAzERDOyiWS123",
              "version": 3,
              "idempotency_key": "UNIQUE_STRING"
            }
            """;

        const string mockResponse = """
            {
              "order": {
                "id": "CAISENgvlJ6jLWAzERDzjyHVybY",
                "location_id": "057P5VYJ4A5X1",
                "reference_id": "my-order-001",
                "source": {
                  "name": "My App"
                },
                "customer_id": "customer_id",
                "line_items": [
                  {
                    "uid": "8uSwfzvUImn3IRrvciqlXC",
                    "name": "New York Strip Steak",
                    "quantity": "1",
                    "applied_taxes": [
                      {
                        "uid": "aKG87ArnDpvMLSZJHxWUl",
                        "tax_uid": "state-sales-tax",
                        "applied_money": {
                          "amount": 136,
                          "currency": "USD"
                        }
                      }
                    ],
                    "applied_discounts": [
                      {
                        "uid": "jWdgP1TpHPFBuVrz81mXVC",
                        "discount_uid": "membership-discount",
                        "applied_money": {
                          "amount": 8,
                          "currency": "USD"
                        }
                      },
                      {
                        "uid": "jnZOjjVY57eRcQAVgEwFuC",
                        "discount_uid": "labor-day-sale",
                        "applied_money": {
                          "amount": 79,
                          "currency": "USD"
                        }
                      }
                    ],
                    "base_price_money": {
                      "amount": 1599,
                      "currency": "USD"
                    },
                    "variation_total_price_money": {
                      "amount": 1599,
                      "currency": "USD"
                    },
                    "gross_sales_money": {
                      "amount": 1599,
                      "currency": "USD"
                    },
                    "total_tax_money": {
                      "amount": 136,
                      "currency": "USD"
                    },
                    "total_discount_money": {
                      "amount": 87,
                      "currency": "USD"
                    },
                    "total_money": {
                      "amount": 1648,
                      "currency": "USD"
                    },
                    "total_service_charge_money": {
                      "amount": 0,
                      "currency": "USD"
                    }
                  },
                  {
                    "uid": "v8ZuEXpOJpb0bazLuvrLDB",
                    "name": "New York Steak",
                    "quantity": "2",
                    "catalog_object_id": "BEMYCSMIJL46OCDV4KYIKXIB",
                    "variation_name": "Larger",
                    "modifiers": [
                      {
                        "uid": "Lo3qMMckDluu9Qsb58d4CC",
                        "catalog_object_id": "CHQX7Y4KY6N5KINJKZCFURPZ",
                        "name": "Well",
                        "base_price_money": {
                          "amount": 50,
                          "currency": "USD"
                        },
                        "total_price_money": {
                          "amount": 100,
                          "currency": "USD"
                        }
                      }
                    ],
                    "applied_taxes": [
                      {
                        "uid": "v1dAgrfUVUPTnVTf9sRPz",
                        "tax_uid": "state-sales-tax",
                        "applied_money": {
                          "amount": 374,
                          "currency": "USD"
                        }
                      }
                    ],
                    "applied_discounts": [
                      {
                        "uid": "nUXvdsIItfKko0dbYtY58C",
                        "discount_uid": "membership-discount",
                        "applied_money": {
                          "amount": 22,
                          "currency": "USD"
                        }
                      },
                      {
                        "uid": "qSdkOOOernlVQqsJ94SPjB",
                        "discount_uid": "labor-day-sale",
                        "applied_money": {
                          "amount": 224,
                          "currency": "USD"
                        }
                      },
                      {
                        "uid": "y7bVl4njrWAnfDwmz19izB",
                        "discount_uid": "one-dollar-off",
                        "applied_money": {
                          "amount": 100,
                          "currency": "USD"
                        }
                      }
                    ],
                    "base_price_money": {
                      "amount": 2200,
                      "currency": "USD"
                    },
                    "variation_total_price_money": {
                      "amount": 4400,
                      "currency": "USD"
                    },
                    "gross_sales_money": {
                      "amount": 4500,
                      "currency": "USD"
                    },
                    "total_tax_money": {
                      "amount": 374,
                      "currency": "USD"
                    },
                    "total_discount_money": {
                      "amount": 346,
                      "currency": "USD"
                    },
                    "total_money": {
                      "amount": 4528,
                      "currency": "USD"
                    },
                    "total_service_charge_money": {
                      "amount": 0,
                      "currency": "USD"
                    }
                  }
                ],
                "taxes": [
                  {
                    "uid": "state-sales-tax",
                    "name": "State Sales Tax",
                    "type": "ADDITIVE",
                    "percentage": "9",
                    "applied_money": {
                      "amount": 510,
                      "currency": "USD"
                    },
                    "scope": "ORDER"
                  }
                ],
                "discounts": [
                  {
                    "uid": "membership-discount",
                    "catalog_object_id": "DB7L55ZH2BGWI4H23ULIWOQ7",
                    "name": "Membership Discount",
                    "type": "FIXED_PERCENTAGE",
                    "percentage": "0.5",
                    "applied_money": {
                      "amount": 30,
                      "currency": "USD"
                    },
                    "scope": "ORDER"
                  },
                  {
                    "uid": "labor-day-sale",
                    "name": "Labor Day Sale",
                    "type": "FIXED_PERCENTAGE",
                    "percentage": "5",
                    "applied_money": {
                      "amount": 303,
                      "currency": "USD"
                    },
                    "scope": "ORDER"
                  },
                  {
                    "uid": "one-dollar-off",
                    "name": "Sale - $1.00 off",
                    "type": "FIXED_AMOUNT",
                    "amount_money": {
                      "amount": 100,
                      "currency": "USD"
                    },
                    "applied_money": {
                      "amount": 100,
                      "currency": "USD"
                    },
                    "scope": "LINE_ITEM"
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
                    "amount": 6176,
                    "currency": "USD"
                  },
                  "tax_money": {
                    "amount": 510,
                    "currency": "USD"
                  },
                  "discount_money": {
                    "amount": 433,
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
                    "tender_id": "tender_id",
                    "reason": "reason",
                    "amount_money": {},
                    "status": "PENDING"
                  }
                ],
                "metadata": {
                  "key": "value"
                },
                "created_at": "2020-01-17T20:47:53.293Z",
                "updated_at": "2020-01-17T20:47:53.293Z",
                "closed_at": "closed_at",
                "state": "DRAFT",
                "version": 1,
                "total_money": {
                  "amount": 6176,
                  "currency": "USD"
                },
                "total_tax_money": {
                  "amount": 510,
                  "currency": "USD"
                },
                "total_discount_money": {
                  "amount": 433,
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
                    .WithPath("/v2/orders/clone")
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

        var response = await Client.Orders.CloneAsync(
            new CloneOrderRequest
            {
                OrderId = "ZAISEM52YcpmcWAzERDOyiWS123",
                Version = 3,
                IdempotencyKey = "UNIQUE_STRING",
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CloneOrderResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
