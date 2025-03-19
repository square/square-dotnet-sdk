using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class DismissTerminalCheckoutTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
                "id": "LmZEKbo3SBfqO",
                "amount_money": {
                  "amount": 2610,
                  "currency": "USD"
                },
                "reference_id": "reference_id",
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
                  "skip_receipt_screen": false,
                  "collect_signature": true,
                  "tip_settings": {
                    "allow_tipping": true,
                    "separate_tip_screen": true,
                    "custom_tip_field": false
                  },
                  "show_itemized_cart": true
                },
                "deadline_duration": "PT5M",
                "status": "COMPLETED",
                "cancel_reason": "BUYER_CANCELED",
                "payment_ids": [
                  "D7vLJqMkvSoAlX4yyFzUitOy4EPZY"
                ],
                "created_at": "2023-11-29T14:59:50.682Z",
                "updated_at": "2023-11-29T15:00:18.936Z",
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
                    .WithPath("/v2/terminals/checkouts/checkout_id/dismiss")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Terminal.DismissTerminalCheckoutAsync(
            new DismissTerminalCheckoutRequest { CheckoutId = "checkout_id" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DismissTerminalCheckoutResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
