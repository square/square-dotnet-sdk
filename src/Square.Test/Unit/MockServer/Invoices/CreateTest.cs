using NUnit.Framework;
using Square;
using Square.Core;
using Square.Invoices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Invoices;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "invoice": {
                "location_id": "ES0RJRZYEC39A",
                "order_id": "CAISENgvlJ6jLWAzERDzjyHVybY",
                "primary_recipient": {
                  "customer_id": "JDKYHBWT1D4F8MFH63DBMEN8Y4"
                },
                "payment_requests": [
                  {
                    "request_type": "BALANCE",
                    "due_date": "2030-01-24",
                    "tipping_enabled": true,
                    "automatic_payment_source": "NONE",
                    "reminders": [
                      {
                        "relative_scheduled_days": -1,
                        "message": "Your invoice is due tomorrow"
                      }
                    ]
                  }
                ],
                "delivery_method": "EMAIL",
                "invoice_number": "inv-100",
                "title": "Event Planning Services",
                "description": "We appreciate your business!",
                "scheduled_at": "2030-01-13T10:00:00.000Z",
                "accepted_payment_methods": {
                  "card": true,
                  "square_gift_card": false,
                  "bank_account": false,
                  "buy_now_pay_later": false,
                  "cash_app_pay": false
                },
                "custom_fields": [
                  {
                    "label": "Event Reference Number",
                    "value": "Ref. #1234",
                    "placement": "ABOVE_LINE_ITEMS"
                  },
                  {
                    "label": "Terms of Service",
                    "value": "The terms of service are...",
                    "placement": "BELOW_LINE_ITEMS"
                  }
                ],
                "sale_or_service_date": "2030-01-24",
                "store_payment_method_enabled": false
              },
              "idempotency_key": "ce3748f9-5fc1-4762-aa12-aae5e843f1f4"
            }
            """;

        const string mockResponse = """
            {
              "invoice": {
                "id": "inv:0-ChCHu2mZEabLeeHahQnXDjZQECY",
                "version": 0,
                "location_id": "ES0RJRZYEC39A",
                "order_id": "CAISENgvlJ6jLWAzERDzjyHVybY",
                "primary_recipient": {
                  "customer_id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                  "given_name": "Amelia",
                  "family_name": "Earhart",
                  "email_address": "Amelia.Earhart@example.com",
                  "phone_number": "1-212-555-4240",
                  "company_name": "company_name"
                },
                "payment_requests": [
                  {
                    "uid": "2da7964f-f3d2-4f43-81e8-5aa220bf3355",
                    "request_type": "BALANCE",
                    "due_date": "2030-01-24",
                    "tipping_enabled": true,
                    "automatic_payment_source": "NONE",
                    "reminders": [
                      {
                        "uid": "beebd363-e47f-4075-8785-c235aaa7df11",
                        "relative_scheduled_days": -1,
                        "message": "Your invoice is due tomorrow",
                        "status": "PENDING"
                      }
                    ],
                    "computed_amount_money": {
                      "amount": 10000,
                      "currency": "USD"
                    },
                    "total_completed_amount_money": {
                      "amount": 0,
                      "currency": "USD"
                    }
                  }
                ],
                "delivery_method": "EMAIL",
                "invoice_number": "inv-100",
                "title": "Event Planning Services",
                "description": "We appreciate your business!",
                "scheduled_at": "2030-01-13T10:00:00.000Z",
                "public_url": "public_url",
                "next_payment_amount_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "status": "DRAFT",
                "timezone": "America/Los_Angeles",
                "created_at": "2020-06-18T17:45:13.000Z",
                "updated_at": "2020-06-18T17:45:13.000Z",
                "accepted_payment_methods": {
                  "card": true,
                  "square_gift_card": false,
                  "bank_account": false,
                  "buy_now_pay_later": false,
                  "cash_app_pay": false
                },
                "custom_fields": [
                  {
                    "label": "Event Reference Number",
                    "value": "Ref. #1234",
                    "placement": "ABOVE_LINE_ITEMS"
                  },
                  {
                    "label": "Terms of Service",
                    "value": "The terms of service are...",
                    "placement": "BELOW_LINE_ITEMS"
                  }
                ],
                "subscription_id": "subscription_id",
                "sale_or_service_date": "2030-01-24",
                "payment_conditions": "payment_conditions",
                "store_payment_method_enabled": false,
                "attachments": [
                  {}
                ],
                "creator_team_member_id": "creator_team_member_id"
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
                    .WithPath("/v2/invoices")
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

        var response = await Client.Invoices.CreateAsync(
            new CreateInvoiceRequest
            {
                Invoice = new Invoice
                {
                    LocationId = "ES0RJRZYEC39A",
                    OrderId = "CAISENgvlJ6jLWAzERDzjyHVybY",
                    PrimaryRecipient = new InvoiceRecipient
                    {
                        CustomerId = "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                    },
                    PaymentRequests = new List<InvoicePaymentRequest>()
                    {
                        new InvoicePaymentRequest
                        {
                            RequestType = InvoiceRequestType.Balance,
                            DueDate = "2030-01-24",
                            TippingEnabled = true,
                            AutomaticPaymentSource = InvoiceAutomaticPaymentSource.None,
                            Reminders = new List<InvoicePaymentReminder>()
                            {
                                new InvoicePaymentReminder
                                {
                                    RelativeScheduledDays = -1,
                                    Message = "Your invoice is due tomorrow",
                                },
                            },
                        },
                    },
                    DeliveryMethod = InvoiceDeliveryMethod.Email,
                    InvoiceNumber = "inv-100",
                    Title = "Event Planning Services",
                    Description = "We appreciate your business!",
                    ScheduledAt = "2030-01-13T10:00:00Z",
                    AcceptedPaymentMethods = new InvoiceAcceptedPaymentMethods
                    {
                        Card = true,
                        SquareGiftCard = false,
                        BankAccount = false,
                        BuyNowPayLater = false,
                        CashAppPay = false,
                    },
                    CustomFields = new List<InvoiceCustomField>()
                    {
                        new InvoiceCustomField
                        {
                            Label = "Event Reference Number",
                            Value = "Ref. #1234",
                            Placement = InvoiceCustomFieldPlacement.AboveLineItems,
                        },
                        new InvoiceCustomField
                        {
                            Label = "Terms of Service",
                            Value = "The terms of service are...",
                            Placement = InvoiceCustomFieldPlacement.BelowLineItems,
                        },
                    },
                    SaleOrServiceDate = "2030-01-24",
                    StorePaymentMethodEnabled = false,
                },
                IdempotencyKey = "ce3748f9-5fc1-4762-aa12-aae5e843f1f4",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateInvoiceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
