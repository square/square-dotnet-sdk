using NUnit.Framework;
using Square.GiftCards.Activities;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.GiftCards.Activities;

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
              "gift_card_activities": [
                {
                  "id": "gcact_897698f894b44b3db46c6147e26a0e19",
                  "type": "REDEEM",
                  "location_id": "81FN9BNFZTKS4",
                  "created_at": "2021-06-02T22:26:38.000Z",
                  "gift_card_id": "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
                  "gift_card_gan": "7783320002929081",
                  "gift_card_balance_money": {
                    "amount": 700,
                    "currency": "USD"
                  },
                  "redeem_activity_details": {
                    "amount_money": {
                      "amount": 300,
                      "currency": "USD"
                    }
                  },
                  "clear_balance_activity_details": {
                    "reason": "SUSPICIOUS_ACTIVITY"
                  },
                  "deactivate_activity_details": {
                    "reason": "SUSPICIOUS_ACTIVITY"
                  },
                  "adjust_increment_activity_details": {
                    "amount_money": {},
                    "reason": "COMPLIMENTARY"
                  },
                  "adjust_decrement_activity_details": {
                    "amount_money": {},
                    "reason": "SUSPICIOUS_ACTIVITY"
                  },
                  "unlinked_activity_refund_activity_details": {
                    "amount_money": {}
                  },
                  "import_activity_details": {
                    "amount_money": {}
                  },
                  "block_activity_details": {
                    "reason": "CHARGEBACK_BLOCK"
                  },
                  "unblock_activity_details": {
                    "reason": "CHARGEBACK_UNBLOCK"
                  },
                  "import_reversal_activity_details": {
                    "amount_money": {}
                  },
                  "transfer_balance_to_activity_details": {
                    "transfer_from_gift_card_id": "transfer_from_gift_card_id",
                    "amount_money": {}
                  },
                  "transfer_balance_from_activity_details": {
                    "transfer_to_gift_card_id": "transfer_to_gift_card_id",
                    "amount_money": {}
                  }
                },
                {
                  "id": "gcact_b968ebfc7d46437b945be7b9e09123b4",
                  "type": "ACTIVATE",
                  "location_id": "81FN9BNFZTKS4",
                  "created_at": "2021-05-20T22:26:54.000Z",
                  "gift_card_id": "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
                  "gift_card_gan": "7783320002929081",
                  "gift_card_balance_money": {
                    "amount": 1000,
                    "currency": "USD"
                  },
                  "activate_activity_details": {
                    "amount_money": {
                      "amount": 1000,
                      "currency": "USD"
                    },
                    "order_id": "jJNGHm4gLI6XkFbwtiSLqK72KkAZY",
                    "line_item_uid": "eIWl7X0nMuO9Ewbh0ChIx"
                  },
                  "redeem_activity_details": {
                    "amount_money": {}
                  },
                  "clear_balance_activity_details": {
                    "reason": "SUSPICIOUS_ACTIVITY"
                  },
                  "deactivate_activity_details": {
                    "reason": "SUSPICIOUS_ACTIVITY"
                  },
                  "adjust_increment_activity_details": {
                    "amount_money": {},
                    "reason": "COMPLIMENTARY"
                  },
                  "adjust_decrement_activity_details": {
                    "amount_money": {},
                    "reason": "SUSPICIOUS_ACTIVITY"
                  },
                  "unlinked_activity_refund_activity_details": {
                    "amount_money": {}
                  },
                  "import_activity_details": {
                    "amount_money": {}
                  },
                  "block_activity_details": {
                    "reason": "CHARGEBACK_BLOCK"
                  },
                  "unblock_activity_details": {
                    "reason": "CHARGEBACK_UNBLOCK"
                  },
                  "import_reversal_activity_details": {
                    "amount_money": {}
                  },
                  "transfer_balance_to_activity_details": {
                    "transfer_from_gift_card_id": "transfer_from_gift_card_id",
                    "amount_money": {}
                  },
                  "transfer_balance_from_activity_details": {
                    "transfer_to_gift_card_id": "transfer_to_gift_card_id",
                    "amount_money": {}
                  }
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/gift-cards/activities")
                    .WithParam("gift_card_id", "gift_card_id")
                    .WithParam("type", "type")
                    .WithParam("location_id", "location_id")
                    .WithParam("begin_time", "begin_time")
                    .WithParam("end_time", "end_time")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .WithParam("sort_order", "sort_order")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.GiftCards.Activities.ListAsync(
            new ListActivitiesRequest
            {
                GiftCardId = "gift_card_id",
                Type = "type",
                LocationId = "location_id",
                BeginTime = "begin_time",
                EndTime = "end_time",
                Limit = 1,
                Cursor = "cursor",
                SortOrder = "sort_order",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
