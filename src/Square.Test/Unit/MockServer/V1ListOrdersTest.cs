using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.V1Transactions;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class V1ListOrdersTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "errors": [
                  {
                    "category": "API_ERROR",
                    "code": "INTERNAL_SERVER_ERROR"
                  }
                ],
                "id": "id",
                "buyer_email": "buyer_email",
                "recipient_name": "recipient_name",
                "recipient_phone_number": "recipient_phone_number",
                "state": "PENDING",
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
                "subtotal_money": {
                  "amount": 1,
                  "currency_code": "UNKNOWN_CURRENCY"
                },
                "total_shipping_money": {
                  "amount": 1,
                  "currency_code": "UNKNOWN_CURRENCY"
                },
                "total_tax_money": {
                  "amount": 1,
                  "currency_code": "UNKNOWN_CURRENCY"
                },
                "total_price_money": {
                  "amount": 1,
                  "currency_code": "UNKNOWN_CURRENCY"
                },
                "total_discount_money": {
                  "amount": 1,
                  "currency_code": "UNKNOWN_CURRENCY"
                },
                "created_at": "created_at",
                "updated_at": "updated_at",
                "expires_at": "expires_at",
                "payment_id": "payment_id",
                "buyer_note": "buyer_note",
                "completed_note": "completed_note",
                "refunded_note": "refunded_note",
                "canceled_note": "canceled_note",
                "tender": {
                  "id": "id",
                  "type": "CREDIT_CARD",
                  "name": "name",
                  "employee_id": "employee_id",
                  "receipt_url": "receipt_url",
                  "card_brand": "OTHER_BRAND",
                  "pan_suffix": "pan_suffix",
                  "entry_method": "MANUAL",
                  "payment_note": "payment_note",
                  "tendered_at": "tendered_at",
                  "settled_at": "settled_at",
                  "is_exchange": true
                },
                "order_history": [
                  {}
                ],
                "promo_code": "promo_code",
                "btc_receive_address": "btc_receive_address",
                "btc_price_satoshi": 1.1
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/location_id/orders")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.V1Transactions.V1ListOrdersAsync(
            new V1ListOrdersRequest { LocationId = "location_id" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<V1Order>>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
