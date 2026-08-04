using NUnit.Framework;
using Square;
using Square.Core;
using Square.Invoices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Invoices;

[TestFixture]
public class PublishTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "version": 1,
              "idempotency_key": "32da42d0-1997-41b0-826b-f09464fc2c2e"
            }
            """;

        const string mockResponse = """
            {
              "invoice": {
                "id": "inv:0-ChCHu2mZEabLeeHahQnXDjZQECY",
                "version": 1,
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
                "public_url": "https://squareup.com/pay-invoice/invtmp:5e22a2c2-47c1-46d6-b061-808764dfe2b9",
                "next_payment_amount_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "status": "SCHEDULED",
                "timezone": "America/Los_Angeles",
                "created_at": "2020-06-18T17:45:13.000Z",
                "updated_at": "2020-06-18T18:23:11.000Z",
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
                    .WithPath("/v2/invoices/invoice_id/publish")
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

        var response = await Client.Invoices.PublishAsync(
            new PublishInvoiceRequest
            {
                InvoiceId = "invoice_id",
                Version = 1,
                IdempotencyKey = "32da42d0-1997-41b0-826b-f09464fc2c2e",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PublishInvoiceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
