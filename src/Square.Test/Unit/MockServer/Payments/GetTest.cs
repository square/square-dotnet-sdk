using NUnit.Framework;
using Square;
using Square.Core;
using Square.Payments;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Payments;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
              "payment": {
                "id": "bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY",
                "created_at": "2021-10-13T19:34:33.524Z",
                "updated_at": "2021-10-13T19:34:34.339Z",
                "amount_money": {
                  "amount": 555,
                  "currency": "USD"
                },
                "tip_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "total_money": {
                  "amount": 555,
                  "currency": "USD"
                },
                "app_fee_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "approved_money": {
                  "amount": 555,
                  "currency": "USD"
                },
                "processing_fee": [
                  {
                    "effective_at": "2021-10-13T21:34:35.000Z",
                    "type": "INITIAL",
                    "amount_money": {
                      "amount": 34,
                      "currency": "USD"
                    }
                  }
                ],
                "refunded_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "status": "COMPLETED",
                "delay_duration": "PT168H",
                "delay_action": "CANCEL",
                "delayed_until": "2021-10-20T19:34:33.524Z",
                "source_type": "CARD",
                "card_details": {
                  "status": "CAPTURED",
                  "card": {
                    "card_brand": "VISA",
                    "last_4": "1111",
                    "exp_month": 11,
                    "exp_year": 2022,
                    "fingerprint": "sq-1-Hxim77tbdcbGejOejnoAklBVJed2YFLTmirfl8Q5XZzObTc8qY_U8RkwzoNL8dCEcQ",
                    "card_type": "DEBIT",
                    "prepaid_type": "NOT_PREPAID",
                    "bin": "411111"
                  },
                  "entry_method": "KEYED",
                  "cvv_status": "CVV_ACCEPTED",
                  "avs_status": "AVS_ACCEPTED",
                  "auth_result_code": "2Nkw7q",
                  "application_identifier": "application_identifier",
                  "application_name": "application_name",
                  "application_cryptogram": "application_cryptogram",
                  "verification_method": "verification_method",
                  "verification_results": "verification_results",
                  "statement_description": "SQ *EXAMPLE TEST GOSQ.C",
                  "card_payment_timeline": {
                    "authorized_at": "2021-10-13T19:34:33.680Z",
                    "captured_at": "2021-10-13T19:34:34.340Z"
                  },
                  "refund_requires_card_presence": true,
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "cash_details": {
                  "buyer_supplied_money": {}
                },
                "bank_account_details": {
                  "bank_name": "bank_name",
                  "transfer_type": "transfer_type",
                  "account_ownership_type": "account_ownership_type",
                  "fingerprint": "fingerprint",
                  "country": "country",
                  "statement_description": "statement_description",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "external_details": {
                  "type": "type",
                  "source": "source",
                  "source_id": "source_id"
                },
                "wallet_details": {
                  "status": "status",
                  "brand": "brand"
                },
                "buy_now_pay_later_details": {
                  "brand": "brand"
                },
                "square_account_details": {
                  "payment_source_token": "payment_source_token",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "location_id": "L88917AVBK2S5",
                "order_id": "d7eKah653Z579f3gVtjlxpSlmUcZY",
                "reference_id": "reference_id",
                "customer_id": "customer_id",
                "employee_id": "TMoK_ogh6rH1o4dV",
                "team_member_id": "TMoK_ogh6rH1o4dV",
                "refund_ids": [
                  "refund_ids"
                ],
                "risk_evaluation": {
                  "created_at": "created_at",
                  "risk_level": "PENDING"
                },
                "terminal_checkout_id": "terminal_checkout_id",
                "buyer_email_address": "buyer_email_address",
                "billing_address": {
                  "address_line_1": "address_line_1",
                  "address_line_2": "address_line_2",
                  "address_line_3": "address_line_3",
                  "locality": "locality",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "administrative_district_level_1",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "postal_code",
                  "country": "ZZ",
                  "first_name": "first_name",
                  "last_name": "last_name"
                },
                "shipping_address": {
                  "address_line_1": "address_line_1",
                  "address_line_2": "address_line_2",
                  "address_line_3": "address_line_3",
                  "locality": "locality",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "administrative_district_level_1",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "postal_code",
                  "country": "ZZ",
                  "first_name": "first_name",
                  "last_name": "last_name"
                },
                "note": "Test Note",
                "statement_description_identifier": "statement_description_identifier",
                "capabilities": [
                  "capabilities"
                ],
                "receipt_number": "bP9m",
                "receipt_url": "https://squareup.com/receipt/preview/bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY",
                "device_details": {
                  "device_id": "device_id",
                  "device_installation_id": "device_installation_id",
                  "device_name": "device_name"
                },
                "application_details": {
                  "square_product": "VIRTUAL_TERMINAL",
                  "application_id": "sq0ids-Pw67AZAlLVB7hsRmwlJPuA"
                },
                "is_offline_payment": true,
                "offline_payment_details": {
                  "client_created_at": "client_created_at"
                },
                "version_token": "56pRkL3slrzet2iQrTp9n0bdJVYTB9YEWdTNjQfZOPV6o"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payments/payment_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Payments.GetAsync(
            new GetPaymentsRequest { PaymentId = "payment_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetPaymentResponse>(mockResponse)).UsingDefaults()
        );
    }
}
