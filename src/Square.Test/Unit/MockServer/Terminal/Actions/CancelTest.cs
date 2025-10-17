using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal.Actions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Terminal.Actions;

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
              "action": {
                "id": "termapia:jveJIAkkAjILHkdCE",
                "device_id": "DEVICE_ID",
                "deadline_duration": "PT5M",
                "status": "CANCELED",
                "cancel_reason": "SELLER_CANCELED",
                "created_at": "2021-07-28T23:22:07.476Z",
                "updated_at": "2021-07-28T23:22:29.511Z",
                "app_id": "APP_ID",
                "location_id": "LOCATION_ID",
                "type": "SAVE_CARD",
                "qr_code_options": {
                  "title": "title",
                  "body": "body",
                  "barcode_contents": "barcode_contents"
                },
                "save_card_options": {
                  "customer_id": "CUSTOMER_ID",
                  "card_id": "card_id",
                  "reference_id": "user-id-1"
                },
                "signature_options": {
                  "title": "title",
                  "body": "body",
                  "signature": [
                    {}
                  ]
                },
                "confirmation_options": {
                  "title": "title",
                  "body": "body",
                  "agree_button_text": "agree_button_text",
                  "disagree_button_text": "disagree_button_text"
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
                "await_next_action_duration": "await_next_action_duration"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/actions/action_id/cancel")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Terminal.Actions.CancelAsync(
            new CancelActionsRequest { ActionId = "action_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelTerminalActionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
