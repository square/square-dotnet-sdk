using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.GiftCards.Activities;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.GiftCards.Activities;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "U16kfr-kA70er-q4Rsym-7U7NnY",
              "gift_card_activity": {
                "type": "ACTIVATE",
                "location_id": "81FN9BNFZTKS4",
                "gift_card_id": "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
                "activate_activity_details": {
                  "order_id": "jJNGHm4gLI6XkFbwtiSLqK72KkAZY",
                  "line_item_uid": "eIWl7X0nMuO9Ewbh0ChIx"
                }
              }
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
              "gift_card_activity": {
                "id": "gcact_c8f8cbf1f24b448d8ecf39ed03f97864",
                "type": "ACTIVATE",
                "location_id": "81FN9BNFZTKS4",
                "created_at": "2021-05-20T22:26:54.000Z",
                "gift_card_id": "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
                "gift_card_gan": "7783320002929081",
                "gift_card_balance_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "load_activity_details": {
                  "order_id": "order_id",
                  "line_item_uid": "line_item_uid",
                  "reference_id": "reference_id",
                  "buyer_payment_instrument_ids": [
                    "buyer_payment_instrument_ids"
                  ]
                },
                "activate_activity_details": {
                  "amount_money": {
                    "amount": 1000,
                    "currency": "USD"
                  },
                  "order_id": "jJNGHm4gLI6XkFbwtiSLqK72KkAZY",
                  "line_item_uid": "eIWl7X0nMuO9Ewbh0ChIx",
                  "reference_id": "reference_id",
                  "buyer_payment_instrument_ids": [
                    "buyer_payment_instrument_ids"
                  ]
                },
                "redeem_activity_details": {
                  "amount_money": {},
                  "payment_id": "payment_id",
                  "reference_id": "reference_id",
                  "status": "PENDING"
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
                "refund_activity_details": {
                  "redeem_activity_id": "redeem_activity_id",
                  "reference_id": "reference_id",
                  "payment_id": "payment_id"
                },
                "unlinked_activity_refund_activity_details": {
                  "amount_money": {},
                  "reference_id": "reference_id",
                  "payment_id": "payment_id"
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
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/gift-cards/activities")
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

        var response = await Client.GiftCards.Activities.CreateAsync(
            new CreateGiftCardActivityRequest
            {
                IdempotencyKey = "U16kfr-kA70er-q4Rsym-7U7NnY",
                GiftCardActivity = new GiftCardActivity
                {
                    Type = GiftCardActivityType.Activate,
                    LocationId = "81FN9BNFZTKS4",
                    GiftCardId = "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
                    ActivateActivityDetails = new GiftCardActivityActivate
                    {
                        OrderId = "jJNGHm4gLI6XkFbwtiSLqK72KkAZY",
                        LineItemUid = "eIWl7X0nMuO9Ewbh0ChIx",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateGiftCardActivityResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
