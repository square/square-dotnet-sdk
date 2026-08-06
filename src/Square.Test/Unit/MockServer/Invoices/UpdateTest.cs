using NUnit.Framework;
using Square;
using Square.Core;
using Square.Invoices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Invoices;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "invoice": {
                "version": 1,
                "payment_requests": [
                  {
                    "uid": "2da7964f-f3d2-4f43-81e8-5aa220bf3355",
                    "tipping_enabled": false
                  }
                ]
              },
              "idempotency_key": "4ee82288-0910-499e-ab4c-5d0071dad1be"
            }
            """;

        const string mockResponse = """
            {
              "invoice": {
                "id": "inv:0-ChCHu2mZEabLeeHahQnXDjZQECY",
                "version": 2,
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
                    "tipping_enabled": false,
                    "automatic_payment_source": "NONE",
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
                  "amount": 10000,
                  "currency": "USD"
                },
                "status": "UNPAID",
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
                    .WithPath("/v2/invoices/invoice_id")
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

        var response = await Client.Invoices.UpdateAsync(
            new UpdateInvoiceRequest
            {
                InvoiceId = "invoice_id",
                Invoice = new Invoice
                {
                    Version = 1,
                    PaymentRequests = new List<InvoicePaymentRequest>()
                    {
                        new InvoicePaymentRequest
                        {
                            Uid = "2da7964f-f3d2-4f43-81e8-5aa220bf3355",
                            TippingEnabled = false,
                        },
                    },
                },
                IdempotencyKey = "4ee82288-0910-499e-ab4c-5d0071dad1be",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateInvoiceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
