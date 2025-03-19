using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Orders;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class PayTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "c043a359-7ad9-4136-82a9-c3f1d66dcbff",
              "payment_ids": [
                "EnZdNAlWCmfh6Mt5FMNST1o7taB",
                "0LRiVlbXVwe8ozu4KbZxd12mvaB"
              ]
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
              "order": {
                "id": "lgwOlEityYPJtcuvKTVKT1pA986YY",
                "location_id": "P3CCK6HSNDAS7",
                "reference_id": "reference_id",
                "source": {
                  "name": "Source Name"
                },
                "customer_id": "customer_id",
                "line_items": [
                  {
                    "uid": "QW6kofLHJK7JEKMjlSVP5C",
                    "name": "Item 1",
                    "quantity": "1",
                    "base_price_money": {
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
                    "uid": "zhw8MNfRGdFQMI2WE1UBJD",
                    "name": "Item 2",
                    "quantity": "2",
                    "base_price_money": {
                      "amount": 750,
                      "currency": "USD"
                    },
                    "gross_sales_money": {
                      "amount": 1500,
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
                      "amount": 1500,
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
                    "amount": 2000,
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
                    "id": "EnZdNAlWCmfh6Mt5FMNST1o7taB",
                    "location_id": "P3CCK6HSNDAS7",
                    "transaction_id": "lgwOlEityYPJtcuvKTVKT1pA986YY",
                    "created_at": "2019-08-06T02:47:36.293Z",
                    "amount_money": {
                      "amount": 1000,
                      "currency": "USD"
                    },
                    "type": "CARD",
                    "card_details": {
                      "status": "CAPTURED",
                      "card": {
                        "card_brand": "VISA",
                        "last_4": "1111",
                        "exp_month": 2,
                        "exp_year": 2022,
                        "fingerprint": "sq-1-n_BL15KP87ClDa4-h2nXOI0fp5VnxNH6hfhzqhptTfAgxgLuGFcg6jIPngDz4IkkTQ"
                      },
                      "entry_method": "KEYED"
                    },
                    "payment_id": "EnZdNAlWCmfh6Mt5FMNST1o7taB"
                  },
                  {
                    "id": "0LRiVlbXVwe8ozu4KbZxd12mvaB",
                    "location_id": "P3CCK6HSNDAS7",
                    "transaction_id": "lgwOlEityYPJtcuvKTVKT1pA986YY",
                    "created_at": "2019-08-06T02:47:36.809Z",
                    "amount_money": {
                      "amount": 1000,
                      "currency": "USD"
                    },
                    "type": "CARD",
                    "card_details": {
                      "status": "CAPTURED",
                      "card": {
                        "card_brand": "VISA",
                        "last_4": "1111",
                        "exp_month": 2,
                        "exp_year": 2022,
                        "fingerprint": "sq-1-n_BL15KP87ClDa4-h2nXOI0fp5VnxNH6hfhzqhptTfAgxgLuGFcg6jIPngDz4IkkTQ"
                      },
                      "entry_method": "KEYED"
                    },
                    "payment_id": "0LRiVlbXVwe8ozu4KbZxd12mvaB"
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
                "created_at": "2019-08-06T02:47:35.693Z",
                "updated_at": "2019-08-06T02:47:37.140Z",
                "closed_at": "2019-08-06T02:47:37.140Z",
                "state": "COMPLETED",
                "version": 4,
                "total_money": {
                  "amount": 2000,
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
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/orders/order_id/pay")
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

        var response = await Client.Orders.PayAsync(
            new PayOrderRequest
            {
                OrderId = "order_id",
                IdempotencyKey = "c043a359-7ad9-4136-82a9-c3f1d66dcbff",
                PaymentIds = new List<string>()
                {
                    "EnZdNAlWCmfh6Mt5FMNST1o7taB",
                    "0LRiVlbXVwe8ozu4KbZxd12mvaB",
                },
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayOrderResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
