using NUnit.Framework;
using Square.Default.Invoices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Invoices;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "invoices": [
                {
                  "id": "inv:0-ChCHu2mZEabLeeHahQnXDjZQECY",
                  "version": 1,
                  "location_id": "ES0RJRZYEC39A",
                  "order_id": "CAISENgvlJ6jLWAzERDzjyHVybY",
                  "primary_recipient": {
                    "customer_id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                    "given_name": "Amelia",
                    "family_name": "Earhart",
                    "email_address": "Amelia.Earhart@example.com",
                    "phone_number": "1-212-555-4240"
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
                  "status": "DRAFT",
                  "timezone": "America/Los_Angeles",
                  "created_at": "2030-01-13T17:45:13.000Z",
                  "updated_at": "2030-01-13T21:24:10.000Z",
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
                    {
                      "id": "inva:0-3bB9ZuDHiziThQhuC4fwWt",
                      "filename": "file.jpg",
                      "description": "Service contract",
                      "filesize": 102705,
                      "hash": "273ee02cb6f5f8a3a8ca23604930dd53",
                      "mime_type": "image/jpeg",
                      "uploaded_at": "2030-01-13T21:24:10.000Z"
                    }
                  ],
                  "creator_team_member_id": "creator_team_member_id"
                },
                {
                  "id": "inv:0-ChC366qAfskpGrBI_1bozs9mEA3",
                  "version": 3,
                  "location_id": "ES0RJRZYEC39A",
                  "order_id": "a65jnS8NXbfprvGJzY9F4fQTuaB",
                  "primary_recipient": {
                    "customer_id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                    "given_name": "Amelia",
                    "family_name": "Earhart",
                    "email_address": "Amelia.Earhart@example.com",
                    "phone_number": "1-212-555-4240"
                  },
                  "payment_requests": [
                    {
                      "uid": "66c3bdfd-5090-4ff9-a8a0-c1e1a2ffa176",
                      "request_type": "DEPOSIT",
                      "due_date": "2021-01-23",
                      "percentage_requested": "25",
                      "tipping_enabled": false,
                      "automatic_payment_source": "CARD_ON_FILE",
                      "card_id": "ccof:IkWfpLj4tNHMyFii3GB",
                      "computed_amount_money": {
                        "amount": 1000,
                        "currency": "USD"
                      },
                      "total_completed_amount_money": {
                        "amount": 1000,
                        "currency": "USD"
                      }
                    },
                    {
                      "uid": "120c5e18-4f80-4f6b-b159-774cb9bf8f99",
                      "request_type": "BALANCE",
                      "due_date": "2021-06-15",
                      "tipping_enabled": false,
                      "automatic_payment_source": "CARD_ON_FILE",
                      "card_id": "ccof:IkWfpLj4tNHMyFii3GB",
                      "computed_amount_money": {
                        "amount": 3000,
                        "currency": "USD"
                      },
                      "total_completed_amount_money": {
                        "amount": 0,
                        "currency": "USD"
                      }
                    }
                  ],
                  "delivery_method": "EMAIL",
                  "invoice_number": "inv-455",
                  "title": "title",
                  "description": "description",
                  "scheduled_at": "scheduled_at",
                  "public_url": "https://squareup.com/pay-invoice/invtmp:5e22a2c2-47c1-46d6-b061-808764dfe2b9",
                  "next_payment_amount_money": {
                    "amount": 3000,
                    "currency": "USD"
                  },
                  "status": "PARTIALLY_PAID",
                  "timezone": "America/Los_Angeles",
                  "created_at": "2021-01-23T15:29:12.000Z",
                  "updated_at": "2021-01-23T15:29:56.000Z",
                  "accepted_payment_methods": {
                    "card": true,
                    "square_gift_card": true,
                    "bank_account": false,
                    "buy_now_pay_later": false,
                    "cash_app_pay": false
                  },
                  "custom_fields": [
                    {}
                  ],
                  "subscription_id": "subscription_id",
                  "sale_or_service_date": "2030-01-24",
                  "payment_conditions": "payment_conditions",
                  "store_payment_method_enabled": false,
                  "attachments": [
                    {}
                  ],
                  "creator_team_member_id": "creator_team_member_id"
                }
              ],
              "cursor": "ChoIDhIWVm54ZVRhLXhySFBOejBBM2xJb2daUQoFCI4IGAE",
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
                    .WithParam("location_id", "location_id")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Invoices.ListAsync(
            new ListInvoicesRequest
            {
                LocationId = "location_id",
                Cursor = "cursor",
                Limit = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
