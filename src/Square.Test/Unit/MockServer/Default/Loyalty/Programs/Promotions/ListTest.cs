using NUnit.Framework;
using Square.Default;
using Square.Default.Loyalty.Programs.Promotions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Programs.Promotions;

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
              "loyalty_promotions": [
                {
                  "id": "loypromo_f0f9b849-725e-378d-b810-511237e07b67",
                  "name": "Tuesday Happy Hour Promo",
                  "incentive": {
                    "type": "POINTS_MULTIPLIER",
                    "points_multiplier_data": {
                      "points_multiplier": 3,
                      "multiplier": "3.000"
                    }
                  },
                  "available_time": {
                    "start_date": "2022-08-16",
                    "time_periods": [
                      "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT"
                    ]
                  },
                  "trigger_limit": {
                    "times": 1,
                    "interval": "DAY"
                  },
                  "status": "ACTIVE",
                  "created_at": "2022-08-16T08:38:54.000Z",
                  "canceled_at": "canceled_at",
                  "updated_at": "2022-08-16T08:38:54.000Z",
                  "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                  "qualifying_item_variation_ids": [
                    "CJ3RYL56ITAKMD4VRCM7XERS",
                    "AT3RYLR3TUA9C34VRCB7X5RR"
                  ],
                  "qualifying_category_ids": [
                    "qualifying_category_ids"
                  ]
                },
                {
                  "id": "loypromo_e696f057-2286-35ff-8108-132241328106",
                  "name": "July Special",
                  "incentive": {
                    "type": "POINTS_MULTIPLIER",
                    "points_multiplier_data": {
                      "points_multiplier": 2,
                      "multiplier": "2.000"
                    }
                  },
                  "available_time": {
                    "start_date": "2022-07-01",
                    "end_date": "2022-08-01",
                    "time_periods": [
                      "BEGIN:VEVENT\nDTSTART:20220704T090000\nDURATION:PT8H\nRRULE:FREQ=WEEKLY;UNTIL=20220801T000000;BYDAY=MO\nEND:VEVENT",
                      "BEGIN:VEVENT\nDTSTART:20220705T090000\nDURATION:PT8H\nRRULE:FREQ=WEEKLY;UNTIL=20220801T000000;BYDAY=TU\nEND:VEVENT",
                      "BEGIN:VEVENT\nDTSTART:20220706T090000\nDURATION:PT8H\nRRULE:FREQ=WEEKLY;UNTIL=20220801T000000;BYDAY=WE\nEND:VEVENT",
                      "BEGIN:VEVENT\nDTSTART:20220707T090000\nDURATION:PT8H\nRRULE:FREQ=WEEKLY;UNTIL=20220801T000000;BYDAY=TH\nEND:VEVENT",
                      "BEGIN:VEVENT\nDTSTART:20220701T090000\nDURATION:PT8H\nRRULE:FREQ=WEEKLY;UNTIL=20220801T000000;BYDAY=FR\nEND:VEVENT"
                    ]
                  },
                  "trigger_limit": {
                    "times": 5,
                    "interval": "ALL_TIME"
                  },
                  "status": "ENDED",
                  "created_at": "2022-06-27T15:37:38.000Z",
                  "canceled_at": "canceled_at",
                  "updated_at": "2022-06-27T15:37:38.000Z",
                  "loyalty_program_id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                  "minimum_spend_amount_money": {
                    "amount": 2000,
                    "currency": "USD"
                  },
                  "qualifying_item_variation_ids": [
                    "qualifying_item_variation_ids"
                  ],
                  "qualifying_category_ids": [
                    "XTQPYLR3IIU9C44VRCB3XD12"
                  ]
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/programs/program_id/promotions")
                    .WithParam("status", "ACTIVE")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Loyalty.Programs.Promotions.ListAsync(
            new ListPromotionsRequest
            {
                ProgramId = "program_id",
                Status = LoyaltyPromotionStatus.Active,
                Cursor = "cursor",
                Limit = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
