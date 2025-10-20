using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Checkout.PaymentLinks;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Checkout.PaymentLinks;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "cd9e25dc-d9f2-4430-aedb-61605070e95f",
              "quick_pay": {
                "name": "Auto Detailing",
                "price_money": {
                  "amount": 10000,
                  "currency": "USD"
                },
                "location_id": "A9Y43N9ABXZBP"
              }
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
              "payment_link": {
                "id": "PKVT6XGJZXYUP3NZ",
                "version": 1,
                "description": "description",
                "order_id": "o4b7saqp4HzhNttf5AJxC0Srjd4F",
                "checkout_options": {
                  "allow_tipping": true,
                  "custom_fields": [
                    {
                      "title": "title"
                    }
                  ],
                  "subscription_plan_id": "subscription_plan_id",
                  "redirect_url": "redirect_url",
                  "merchant_support_email": "merchant_support_email",
                  "ask_for_shipping_address": true,
                  "shipping_fee": {
                    "charge": {}
                  },
                  "enable_coupon": true,
                  "enable_loyalty": true
                },
                "pre_populated_data": {
                  "buyer_email": "buyer_email",
                  "buyer_phone_number": "buyer_phone_number"
                },
                "url": "https://square.link/u/EXAMPLE",
                "long_url": "https://checkout.square.site/EXAMPLE",
                "created_at": "2022-04-25T23:58:01.000Z",
                "updated_at": "updated_at",
                "payment_note": "payment_note"
              },
              "related_resources": {
                "orders": [
                  {
                    "id": "o4b7saqp4HzhNttf5AJxC0Srjd4F",
                    "location_id": "{LOCATION_ID}",
                    "source": {
                      "name": "Test Online Checkout Application"
                    },
                    "line_items": [
                      {
                        "uid": "8YX13D1U3jO7czP8JVrAR",
                        "name": "Auto Detailing",
                        "quantity": "1",
                        "item_type": "ITEM",
                        "base_price_money": {
                          "amount": 12500,
                          "currency": "USD"
                        },
                        "variation_total_price_money": {
                          "amount": 12500,
                          "currency": "USD"
                        },
                        "gross_sales_money": {
                          "amount": 12500,
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
                          "amount": 12500,
                          "currency": "USD"
                        }
                      }
                    ],
                    "fulfillments": [
                      {
                        "uid": "bBpNrxjdQxGQP16sTmdzi",
                        "type": "PICKUP",
                        "state": "PROPOSED"
                      }
                    ],
                    "net_amounts": {
                      "total_money": {
                        "amount": 12500,
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
                    "created_at": "2022-03-03T00:53:15.829Z",
                    "updated_at": "2022-03-03T00:53:15.829Z",
                    "state": "DRAFT",
                    "version": 1,
                    "total_money": {
                      "amount": 12500,
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
                      "amount": 0,
                      "currency": "USD"
                    },
                    "total_service_charge_money": {
                      "amount": 0,
                      "currency": "USD"
                    }
                  }
                ],
                "subscription_plans": [
                  {
                    "id": "id",
                    "type": "ITEM"
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/payment-links")
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

        var response = await Client.Checkout.PaymentLinks.CreateAsync(
            new CreatePaymentLinkRequest
            {
                IdempotencyKey = "cd9e25dc-d9f2-4430-aedb-61605070e95f",
                QuickPay = new QuickPay
                {
                    Name = "Auto Detailing",
                    PriceMoney = new Money { Amount = 10000, Currency = Currency.Usd },
                    LocationId = "A9Y43N9ABXZBP",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreatePaymentLinkResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
