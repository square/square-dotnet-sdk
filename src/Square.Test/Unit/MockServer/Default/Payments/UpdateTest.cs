using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Payments;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Payments;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "payment": {
                "amount_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "tip_money": {
                  "amount": 100,
                  "currency": "USD"
                },
                "version_token": "ODhwVQ35xwlzRuoZEwKXucfu7583sPTzK48c5zoGd0g6o"
              },
              "idempotency_key": "956f8b13-e4ec-45d6-85e8-d1d95ef0c5de"
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
              "payment": {
                "id": "1QjqpBVyrI9S4H9sTGDWU9JeiWdZY",
                "created_at": "2021-10-13T20:26:44.191Z",
                "updated_at": "2021-10-13T20:26:44.364Z",
                "amount_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "tip_money": {
                  "amount": 100,
                  "currency": "USD"
                },
                "total_money": {
                  "amount": 1100,
                  "currency": "USD"
                },
                "app_fee_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "approved_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "processing_fee": [
                  {}
                ],
                "refunded_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "status": "APPROVED",
                "delay_duration": "PT168H",
                "delay_action": "CANCEL",
                "delayed_until": "2021-10-20T20:26:44.191Z",
                "source_type": "CARD",
                "card_details": {
                  "status": "AUTHORIZED",
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
                  "entry_method": "ON_FILE",
                  "cvv_status": "CVV_ACCEPTED",
                  "avs_status": "AVS_ACCEPTED",
                  "auth_result_code": "68aLBM",
                  "application_identifier": "application_identifier",
                  "application_name": "application_name",
                  "application_cryptogram": "application_cryptogram",
                  "verification_method": "verification_method",
                  "verification_results": "verification_results",
                  "statement_description": "SQ *EXAMPLE TEST GOSQ.C",
                  "card_payment_timeline": {
                    "authorized_at": "2021-10-13T20:26:44.364Z"
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
                "order_id": "nUSN9TdxpiK3SrQg3wzmf6r8LP9YY",
                "reference_id": "reference_id",
                "customer_id": "W92WH6P11H4Z77CTET0RNTGFW8",
                "employee_id": "employee_id",
                "team_member_id": "team_member_id",
                "refund_ids": [
                  "refund_ids"
                ],
                "risk_evaluation": {
                  "created_at": "2021-10-13T20:26:45.271Z",
                  "risk_level": "NORMAL"
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
                "note": "Example Note",
                "statement_description_identifier": "statement_description_identifier",
                "capabilities": [
                  "EDIT_AMOUNT_UP",
                  "EDIT_AMOUNT_DOWN",
                  "EDIT_TIP_AMOUNT_UP",
                  "EDIT_TIP_AMOUNT_DOWN"
                ],
                "receipt_number": "1Qjq",
                "receipt_url": "receipt_url",
                "device_details": {
                  "device_id": "device_id",
                  "device_installation_id": "device_installation_id",
                  "device_name": "device_name"
                },
                "application_details": {
                  "square_product": "ECOMMERCE_API",
                  "application_id": "sq0ids-TcgftTEtKxJTRF1lCFJ9TA"
                },
                "is_offline_payment": true,
                "offline_payment_details": {
                  "client_created_at": "client_created_at"
                },
                "version_token": "rDrXnqiS7fJgexccgdpzmwqTiXui1aIKCp9EchZ7trE6o"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payments/payment_id")
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

        var response = await Client.Default.Payments.UpdateAsync(
            new UpdatePaymentRequest
            {
                PaymentId = "payment_id",
                Payment = new Payment
                {
                    AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
                    TipMoney = new Money { Amount = 100, Currency = Currency.Usd },
                    VersionToken = "ODhwVQ35xwlzRuoZEwKXucfu7583sPTzK48c5zoGd0g6o",
                },
                IdempotencyKey = "956f8b13-e4ec-45d6-85e8-d1d95ef0c5de",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdatePaymentResponse>(mockResponse)).UsingDefaults()
        );
    }
}
