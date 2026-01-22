using NUnit.Framework;
using Square;
using Square.Core;
using Square.Payments;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Payments;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "source_id": "ccof:GaJGNaZa8x4OgDJn4GB",
              "idempotency_key": "7b0f3ec5-086a-4871-8f13-3c81b3875218",
              "amount_money": {
                "amount": 1000,
                "currency": "USD"
              },
              "app_fee_money": {
                "amount": 10,
                "currency": "USD"
              },
              "autocomplete": true,
              "customer_id": "W92WH6P11H4Z77CTET0RNTGFW8",
              "location_id": "L88917AVBK2S5",
              "reference_id": "123456",
              "note": "Brief description"
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
                "id": "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY",
                "created_at": "2021-10-13T21:14:29.577Z",
                "updated_at": "2021-10-13T21:14:30.504Z",
                "amount_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "tip_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "total_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "app_fee_money": {
                  "amount": 10,
                  "currency": "USD"
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
                "status": "COMPLETED",
                "delay_duration": "PT168H",
                "delay_action": "CANCEL",
                "delayed_until": "2021-10-20T21:14:29.577Z",
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
                  "entry_method": "ON_FILE",
                  "cvv_status": "CVV_ACCEPTED",
                  "avs_status": "AVS_ACCEPTED",
                  "auth_result_code": "vNEn2f",
                  "application_identifier": "application_identifier",
                  "application_name": "application_name",
                  "application_cryptogram": "application_cryptogram",
                  "verification_method": "verification_method",
                  "verification_results": "verification_results",
                  "statement_description": "SQ *EXAMPLE TEST GOSQ.C",
                  "card_payment_timeline": {
                    "authorized_at": "2021-10-13T21:14:29.732Z",
                    "captured_at": "2021-10-13T21:14:30.504Z"
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
                  "brand": "brand",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "buy_now_pay_later_details": {
                  "brand": "brand",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
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
                "order_id": "pRsjRTgFWATl7so6DxdKBJa7ssbZY",
                "reference_id": "123456",
                "customer_id": "W92WH6P11H4Z77CTET0RNTGFW8",
                "employee_id": "employee_id",
                "team_member_id": "team_member_id",
                "refund_ids": [
                  "refund_ids"
                ],
                "risk_evaluation": {
                  "created_at": "2021-10-13T21:14:30.423Z",
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
                "note": "Brief Description",
                "statement_description_identifier": "statement_description_identifier",
                "capabilities": [
                  "capabilities"
                ],
                "receipt_number": "R2B3",
                "receipt_url": "https://squareup.com/receipt/preview/EXAMPLE_RECEIPT_ID",
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
                "version_token": "TPtNEOBOa6Qq6E3C3IjckSVOM6b3hMbfhjvTxHBQUsB6o"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payments")
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

        var response = await Client.Payments.CreateAsync(
            new CreatePaymentRequest
            {
                SourceId = "ccof:GaJGNaZa8x4OgDJn4GB",
                IdempotencyKey = "7b0f3ec5-086a-4871-8f13-3c81b3875218",
                AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
                AppFeeMoney = new Money { Amount = 10, Currency = Currency.Usd },
                Autocomplete = true,
                CustomerId = "W92WH6P11H4Z77CTET0RNTGFW8",
                LocationId = "L88917AVBK2S5",
                ReferenceId = "123456",
                Note = "Brief description",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreatePaymentResponse>(mockResponse)).UsingDefaults()
        );
    }
}
