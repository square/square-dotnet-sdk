using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal.Actions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Terminal.Actions;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "created_at": {
                    "start_at": "2022-04-01T00:00:00.000Z"
                  }
                },
                "sort": {
                  "sort_order": "DESC"
                }
              },
              "limit": 2
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
              "action": [
                {
                  "id": "termapia:oBGWlAats8xWCiCE",
                  "device_id": "DEVICE_ID",
                  "deadline_duration": "PT5M",
                  "status": "IN_PROGRESS",
                  "cancel_reason": "BUYER_CANCELED",
                  "created_at": "2022-04-08T15:14:04.895Z",
                  "updated_at": "2022-04-08T15:14:05.446Z",
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
                    "reference_id": "user-id-1"
                  },
                  "signature_options": {
                    "title": "title",
                    "body": "body"
                  },
                  "confirmation_options": {
                    "title": "title",
                    "body": "body",
                    "agree_button_text": "agree_button_text"
                  },
                  "receipt_options": {
                    "payment_id": "payment_id"
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
                    ]
                  },
                  "await_next_action": true,
                  "await_next_action_duration": "await_next_action_duration"
                },
                {
                  "id": "termapia:K2NY2YSSml3lTiCE",
                  "device_id": "DEVICE_ID",
                  "deadline_duration": "PT5M",
                  "status": "COMPLETED",
                  "cancel_reason": "BUYER_CANCELED",
                  "created_at": "2022-04-08T15:14:01.210Z",
                  "updated_at": "2022-04-08T15:14:09.861Z",
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
                    "card_id": "ccof:CARD_ID",
                    "reference_id": "user-id-1"
                  },
                  "signature_options": {
                    "title": "title",
                    "body": "body"
                  },
                  "confirmation_options": {
                    "title": "title",
                    "body": "body",
                    "agree_button_text": "agree_button_text"
                  },
                  "receipt_options": {
                    "payment_id": "payment_id"
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
                    ]
                  },
                  "await_next_action": true,
                  "await_next_action_duration": "await_next_action_duration"
                }
              ],
              "cursor": "CURSOR"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/actions/search")
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

        var response = await Client.Terminal.Actions.SearchAsync(
            new SearchTerminalActionsRequest
            {
                Query = new TerminalActionQuery
                {
                    Filter = new TerminalActionQueryFilter
                    {
                        CreatedAt = new TimeRange { StartAt = "2022-04-01T00:00:00.000Z" },
                    },
                    Sort = new TerminalActionQuerySort { SortOrder = SortOrder.Desc },
                },
                Limit = 2,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchTerminalActionsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
