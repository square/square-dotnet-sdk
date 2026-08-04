using NUnit.Framework;
using Square;
using Square.Core;
using Square.Locations;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Locations;

[TestFixture]
public class CheckoutsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "86ae1696-b1e3-4328-af6d-f1e04d947ad6",
              "order": {
                "order": {
                  "location_id": "location_id",
                  "reference_id": "reference_id",
                  "customer_id": "customer_id",
                  "line_items": [
                    {
                      "name": "Printed T Shirt",
                      "quantity": "2",
                      "applied_taxes": [
                        {
                          "tax_uid": "38ze1696-z1e3-5628-af6d-f1e04d947fg3"
                        }
                      ],
                      "applied_discounts": [
                        {
                          "discount_uid": "56ae1696-z1e3-9328-af6d-f1e04d947gd4"
                        }
                      ],
                      "base_price_money": {
                        "amount": 1500,
                        "currency": "USD"
                      }
                    },
                    {
                      "name": "Slim Jeans",
                      "quantity": "1",
                      "base_price_money": {
                        "amount": 2500,
                        "currency": "USD"
                      }
                    },
                    {
                      "name": "Woven Sweater",
                      "quantity": "3",
                      "base_price_money": {
                        "amount": 3500,
                        "currency": "USD"
                      }
                    }
                  ],
                  "taxes": [
                    {
                      "uid": "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                      "type": "INCLUSIVE",
                      "percentage": "7.75",
                      "scope": "LINE_ITEM"
                    }
                  ],
                  "discounts": [
                    {
                      "uid": "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
                      "type": "FIXED_AMOUNT",
                      "amount_money": {
                        "amount": 100,
                        "currency": "USD"
                      },
                      "scope": "LINE_ITEM"
                    }
                  ]
                },
                "idempotency_key": "12ae1696-z1e3-4328-af6d-f1e04d947gd4"
              },
              "ask_for_shipping_address": true,
              "merchant_support_email": "merchant+support@website.com",
              "pre_populate_buyer_email": "example@email.com",
              "pre_populate_shipping_address": {
                "address_line_1": "1455 Market St.",
                "address_line_2": "Suite 600",
                "locality": "San Francisco",
                "administrative_district_level_1": "CA",
                "postal_code": "94103",
                "country": "US",
                "first_name": "Jane",
                "last_name": "Doe"
              },
              "redirect_url": "https://merchant.website.com/order-confirm",
              "additional_recipients": [
                {
                  "location_id": "057P5VYJ4A5X1",
                  "description": "Application fees",
                  "amount_money": {
                    "amount": 60,
                    "currency": "USD"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "checkout": {
                "id": "CAISEHGimXh-C3RIT4og1a6u1qw",
                "checkout_page_url": "https://connect.squareup.com/v2/checkout?c=CAISEHGimXh-C3RIT4og1a6u1qw&l=CYTKRM7R7JMV8",
                "ask_for_shipping_address": true,
                "merchant_support_email": "merchant+support@website.com",
                "pre_populate_buyer_email": "example@email.com",
                "pre_populate_shipping_address": {
                  "address_line_1": "1455 Market St.",
                  "address_line_2": "Suite 600",
                  "address_line_3": "address_line_3",
                  "locality": "San Francisco",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "CA",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "94103",
                  "country": "US",
                  "first_name": "Jane",
                  "last_name": "Doe"
                },
                "redirect_url": "https://merchant.website.com/order-confirm",
                "order": {
                  "id": "id",
                  "location_id": "location_id",
                  "reference_id": "reference_id",
                  "customer_id": "customer_id",
                  "line_items": [
                    {
                      "name": "Printed T Shirt",
                      "quantity": "2",
                      "applied_taxes": [
                        {
                          "tax_uid": "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                          "applied_money": {
                            "amount": 103,
                            "currency": "USD"
                          }
                        }
                      ],
                      "applied_discounts": [
                        {
                          "discount_uid": "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
                          "applied_money": {
                            "amount": 100,
                            "currency": "USD"
                          }
                        }
                      ],
                      "base_price_money": {
                        "amount": 1500,
                        "currency": "USD"
                      },
                      "total_tax_money": {
                        "amount": 103,
                        "currency": "USD"
                      },
                      "total_discount_money": {
                        "amount": 100,
                        "currency": "USD"
                      },
                      "total_money": {
                        "amount": 1503,
                        "currency": "USD"
                      }
                    },
                    {
                      "name": "Slim Jeans",
                      "quantity": "1",
                      "base_price_money": {
                        "amount": 2500,
                        "currency": "USD"
                      },
                      "total_money": {
                        "amount": 2500,
                        "currency": "USD"
                      }
                    },
                    {
                      "name": "Woven Sweater",
                      "quantity": "3",
                      "base_price_money": {
                        "amount": 3500,
                        "currency": "USD"
                      },
                      "total_money": {
                        "amount": 10500,
                        "currency": "USD"
                      }
                    }
                  ],
                  "taxes": [
                    {
                      "uid": "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                      "type": "INCLUSIVE",
                      "percentage": "7.75",
                      "scope": "LINE_ITEM"
                    }
                  ],
                  "discounts": [
                    {
                      "uid": "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
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
                    "amount": 14503,
                    "currency": "USD"
                  },
                  "total_tax_money": {
                    "amount": 103,
                    "currency": "USD"
                  },
                  "total_discount_money": {
                    "amount": 100,
                    "currency": "USD"
                  },
                  "ticket_name": "ticket_name",
                  "rewards": [
                    {
                      "id": "id",
                      "reward_tier_id": "reward_tier_id"
                    }
                  ]
                },
                "created_at": "2017-06-16T22:25:35.000Z",
                "additional_recipients": [
                  {
                    "location_id": "057P5VYJ4A5X1",
                    "description": "Application fees",
                    "amount_money": {
                      "amount": 60,
                      "currency": "USD"
                    }
                  }
                ]
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
                    .WithPath("/v2/locations/location_id/checkouts")
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

        var response = await Client.Locations.CheckoutsAsync(
            new CreateCheckoutRequest
            {
                LocationId = "location_id",
                IdempotencyKey = "86ae1696-b1e3-4328-af6d-f1e04d947ad6",
                Order = new CreateOrderRequest
                {
                    Order = new Order
                    {
                        LocationId = "location_id",
                        ReferenceId = "reference_id",
                        CustomerId = "customer_id",
                        LineItems = new List<OrderLineItem>()
                        {
                            new OrderLineItem
                            {
                                Name = "Printed T Shirt",
                                Quantity = "2",
                                AppliedTaxes = new List<OrderLineItemAppliedTax>()
                                {
                                    new OrderLineItemAppliedTax
                                    {
                                        TaxUid = "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                                    },
                                },
                                AppliedDiscounts = new List<OrderLineItemAppliedDiscount>()
                                {
                                    new OrderLineItemAppliedDiscount
                                    {
                                        DiscountUid = "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
                                    },
                                },
                                BasePriceMoney = new Money
                                {
                                    Amount = 1500,
                                    Currency = Currency.Usd,
                                },
                            },
                            new OrderLineItem
                            {
                                Name = "Slim Jeans",
                                Quantity = "1",
                                BasePriceMoney = new Money
                                {
                                    Amount = 2500,
                                    Currency = Currency.Usd,
                                },
                            },
                            new OrderLineItem
                            {
                                Name = "Woven Sweater",
                                Quantity = "3",
                                BasePriceMoney = new Money
                                {
                                    Amount = 3500,
                                    Currency = Currency.Usd,
                                },
                            },
                        },
                        Taxes = new List<OrderLineItemTax>()
                        {
                            new OrderLineItemTax
                            {
                                Uid = "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                                Type = OrderLineItemTaxType.Inclusive,
                                Percentage = "7.75",
                                Scope = OrderLineItemTaxScope.LineItem,
                            },
                        },
                        Discounts = new List<OrderLineItemDiscount>()
                        {
                            new OrderLineItemDiscount
                            {
                                Uid = "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
                                Type = OrderLineItemDiscountType.FixedAmount,
                                AmountMoney = new Money { Amount = 100, Currency = Currency.Usd },
                                Scope = OrderLineItemDiscountScope.LineItem,
                            },
                        },
                    },
                    IdempotencyKey = "12ae1696-z1e3-4328-af6d-f1e04d947gd4",
                },
                AskForShippingAddress = true,
                MerchantSupportEmail = "merchant+support@website.com",
                PrePopulateBuyerEmail = "example@email.com",
                PrePopulateShippingAddress = new Address
                {
                    AddressLine1 = "1455 Market St.",
                    AddressLine2 = "Suite 600",
                    Locality = "San Francisco",
                    AdministrativeDistrictLevel1 = "CA",
                    PostalCode = "94103",
                    Country = Country.Us,
                    FirstName = "Jane",
                    LastName = "Doe",
                },
                RedirectUrl = "https://merchant.website.com/order-confirm",
                AdditionalRecipients = new List<ChargeRequestAdditionalRecipient>()
                {
                    new ChargeRequestAdditionalRecipient
                    {
                        LocationId = "057P5VYJ4A5X1",
                        Description = "Application fees",
                        AmountMoney = new Money { Amount = 60, Currency = Currency.Usd },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateCheckoutResponse>(mockResponse)).UsingDefaults()
        );
    }
}
