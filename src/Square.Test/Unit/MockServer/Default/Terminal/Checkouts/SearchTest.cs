using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Terminal.Checkouts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Terminal.Checkouts;

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
                  "status": "COMPLETED"
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
              "checkouts": [
                {
                  "id": "tsQPvzwBpMqqO",
                  "amount_money": {
                    "amount": 2610,
                    "currency": "USD"
                  },
                  "reference_id": "id14467",
                  "note": "A brief note",
                  "order_id": "order_id",
                  "device_options": {
                    "device_id": "dbb5d83a-7838-11ea-bc55-0242ac130003",
                    "skip_receipt_screen": false,
                    "tip_settings": {
                      "allow_tipping": false
                    }
                  },
                  "deadline_duration": "PT5M",
                  "status": "COMPLETED",
                  "cancel_reason": "BUYER_CANCELED",
                  "payment_ids": [
                    "rXnhZzywrEk4vR6pw76fPZfgvaB"
                  ],
                  "created_at": "2020-03-31T18:13:15.921Z",
                  "updated_at": "2020-03-31T18:13:52.725Z",
                  "app_id": "APP_ID",
                  "location_id": "location_id",
                  "payment_type": "CARD_PRESENT",
                  "team_member_id": "team_member_id",
                  "customer_id": "customer_id",
                  "statement_description_identifier": "statement_description_identifier"
                },
                {
                  "id": "XlOPTgcEhrbqO",
                  "amount_money": {
                    "amount": 2610,
                    "currency": "USD"
                  },
                  "reference_id": "id41623",
                  "note": "A brief note",
                  "order_id": "order_id",
                  "device_options": {
                    "device_id": "dbb5d83a-7838-11ea-bc55-0242ac130003",
                    "skip_receipt_screen": true,
                    "tip_settings": {
                      "allow_tipping": false
                    }
                  },
                  "deadline_duration": "PT5M",
                  "status": "COMPLETED",
                  "cancel_reason": "BUYER_CANCELED",
                  "payment_ids": [
                    "VYBF861PaoKPP7Pih0TlbZiNvaB"
                  ],
                  "created_at": "2020-03-31T18:08:31.882Z",
                  "updated_at": "2020-03-31T18:08:41.635Z",
                  "app_id": "APP_ID",
                  "location_id": "location_id",
                  "payment_type": "CARD_PRESENT",
                  "team_member_id": "team_member_id",
                  "customer_id": "customer_id",
                  "statement_description_identifier": "statement_description_identifier"
                }
              ],
              "cursor": "RiTJqBoTuXlbLmmrPvEkX9iG7XnQ4W4RjGnH"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/checkouts/search")
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

        var response = await Client.Default.Terminal.Checkouts.SearchAsync(
            new SearchTerminalCheckoutsRequest
            {
                Query = new TerminalCheckoutQuery
                {
                    Filter = new TerminalCheckoutQueryFilter { Status = "COMPLETED" },
                },
                Limit = 2,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchTerminalCheckoutsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
