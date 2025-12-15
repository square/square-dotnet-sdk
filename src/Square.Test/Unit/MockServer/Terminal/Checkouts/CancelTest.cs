using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal.Checkouts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Terminal.Checkouts;

[TestFixture]
public class CancelTest : BaseMockServerTest
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
              "checkout": {
                "id": "S1yDlPQx7slqO",
                "amount_money": {
                  "amount": 123,
                  "currency": "USD"
                },
                "reference_id": "id36815",
                "note": "note",
                "order_id": "order_id",
                "payment_options": {
                  "autocomplete": true,
                  "delay_duration": "delay_duration",
                  "accept_partial_authorization": true,
                  "delay_action": "CANCEL"
                },
                "device_options": {
                  "device_id": "dbb5d83a-7838-11ea-bc55-0242ac130003",
                  "skip_receipt_screen": true,
                  "collect_signature": true,
                  "tip_settings": {
                    "allow_tipping": true
                  },
                  "show_itemized_cart": true
                },
                "deadline_duration": "PT5M",
                "status": "CANCELED",
                "cancel_reason": "SELLER_CANCELED",
                "payment_ids": [
                  "payment_ids"
                ],
                "created_at": "2020-03-16T15:31:19.934Z",
                "updated_at": "2020-03-16T15:31:45.787Z",
                "app_id": "APP_ID",
                "location_id": "LOCATION_ID",
                "payment_type": "CARD_PRESENT",
                "team_member_id": "team_member_id",
                "customer_id": "customer_id",
                "app_fee_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "statement_description_identifier": "statement_description_identifier",
                "tip_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/checkouts/checkout_id/cancel")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Terminal.Checkouts.CancelAsync(
            new CancelCheckoutsRequest { CheckoutId = "checkout_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelTerminalCheckoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
