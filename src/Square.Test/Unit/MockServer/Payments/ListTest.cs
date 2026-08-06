using NUnit.Framework;
using Square;
using Square.Payments;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Payments;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "payments": [
                {
                  "id": "bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY",
                  "created_at": "2021-10-13T19:34:33.524Z",
                  "updated_at": "2021-10-13T19:34:37.261Z",
                  "amount_money": {
                    "amount": 555,
                    "currency": "USD"
                  },
                  "total_money": {
                    "amount": 555,
                    "currency": "USD"
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
                    "statement_description": "SQ *EXAMPLE TEST GOSQ.C",
                    "card_payment_timeline": {
                      "authorized_at": "2021-10-13T19:34:33.680Z",
                      "captured_at": "2021-10-13T19:34:34.340Z"
                    }
                  },
                  "cash_details": {
                    "buyer_supplied_money": {}
                  },
                  "external_details": {
                    "type": "type",
                    "source": "source"
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
                  "terminal_checkout_id": "terminal_checkout_id",
                  "buyer_email_address": "buyer_email_address",
                  "note": "Test Note",
                  "statement_description_identifier": "statement_description_identifier",
                  "capabilities": [
                    "capabilities"
                  ],
                  "receipt_number": "bP9m",
                  "receipt_url": "https://squareup.com/receipt/preview/bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY",
                  "application_details": {
                    "square_product": "VIRTUAL_TERMINAL",
                    "application_id": "sq0ids-Pw67AZAlLVB7hsRmwlJPuA"
                  },
                  "is_offline_payment": true,
                  "version_token": "vguW2km0KpVCdAXZcNTZ438qg5LlVPTP4HO5OpiHNfa6o"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payments")
                    .WithParam("begin_time", "begin_time")
                    .WithParam("end_time", "end_time")
                    .WithParam("sort_order", "sort_order")
                    .WithParam("cursor", "cursor")
                    .WithParam("location_id", "location_id")
                    .WithParam("total", "1000000")
                    .WithParam("last_4", "last_4")
                    .WithParam("card_brand", "card_brand")
                    .WithParam("limit", "1")
                    .WithParam("offline_begin_time", "offline_begin_time")
                    .WithParam("offline_end_time", "offline_end_time")
                    .WithParam("updated_at_begin_time", "updated_at_begin_time")
                    .WithParam("updated_at_end_time", "updated_at_end_time")
                    .WithParam("sort_field", "CREATED_AT")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Payments.ListAsync(
            new ListPaymentsRequest
            {
                BeginTime = "begin_time",
                EndTime = "end_time",
                SortOrder = "sort_order",
                Cursor = "cursor",
                LocationId = "location_id",
                Total = 1000000,
                Last4 = "last_4",
                CardBrand = "card_brand",
                Limit = 1,
                IsOfflinePayment = true,
                OfflineBeginTime = "offline_begin_time",
                OfflineEndTime = "offline_end_time",
                UpdatedAtBeginTime = "updated_at_begin_time",
                UpdatedAtEndTime = "updated_at_end_time",
                SortField = ListPaymentsRequestSortField.CreatedAt,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
