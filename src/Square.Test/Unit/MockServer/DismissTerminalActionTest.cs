using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class DismissTerminalActionTest : BaseMockServerTest
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
              "action": {
                "id": "termapia:abcdefg1234567",
                "device_id": "DEVICE_ID",
                "deadline_duration": "PT5M",
                "status": "COMPLETED",
                "cancel_reason": "BUYER_CANCELED",
                "created_at": "2021-07-28T23:22:07.476Z",
                "updated_at": "2021-07-28T23:22:29.511Z",
                "app_id": "APP_ID",
                "location_id": "location_id",
                "type": "CONFIRMATION",
                "qr_code_options": {
                  "title": "title",
                  "body": "body",
                  "barcode_contents": "barcode_contents"
                },
                "save_card_options": {
                  "customer_id": "customer_id",
                  "card_id": "card_id",
                  "reference_id": "reference_id"
                },
                "signature_options": {
                  "title": "title",
                  "body": "body",
                  "signature": [
                    {}
                  ]
                },
                "confirmation_options": {
                  "title": "Marketing communications",
                  "body": "I agree to receive promotional emails about future events and activities.",
                  "agree_button_text": "Agree",
                  "disagree_button_text": "Decline",
                  "decision": {
                    "has_agreed": true
                  }
                },
                "receipt_options": {
                  "payment_id": "payment_id",
                  "print_only": true,
                  "is_duplicate": true
                },
                "data_collection_options": {
                  "title": "title",
                  "body": "body",
                  "input_type": "EMAIL"
                },
                "select_options": {
                  "title": "title",
                  "body": "body",
                  "options": [
                    {
                      "reference_id": "reference_id",
                      "title": "title"
                    }
                  ],
                  "selected_option": {
                    "reference_id": "reference_id",
                    "title": "title"
                  }
                },
                "device_metadata": {
                  "battery_percentage": "battery_percentage",
                  "charging_state": "charging_state",
                  "location_id": "location_id",
                  "merchant_id": "merchant_id",
                  "network_connection_type": "network_connection_type",
                  "payment_region": "payment_region",
                  "serial_number": "serial_number",
                  "os_version": "os_version",
                  "app_version": "app_version",
                  "wifi_network_name": "wifi_network_name",
                  "wifi_network_strength": "wifi_network_strength",
                  "ip_address": "ip_address"
                },
                "await_next_action": true,
                "await_next_action_duration": "PT5M"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/actions/action_id/dismiss")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Terminal.DismissTerminalActionAsync(
            new DismissTerminalActionRequest { ActionId = "action_id" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DismissTerminalActionResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
