using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Programs.Promotions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Programs.Promotions;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "loyalty_promotion": {
                "name": "Tuesday Happy Hour Promo",
                "incentive": {
                  "type": "POINTS_MULTIPLIER",
                  "points_multiplier_data": {
                    "multiplier": "3.0"
                  }
                },
                "available_time": {
                  "time_periods": [
                    "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT"
                  ]
                },
                "trigger_limit": {
                  "times": 1,
                  "interval": "DAY"
                },
                "minimum_spend_amount_money": {
                  "amount": 2000,
                  "currency": "USD"
                },
                "qualifying_category_ids": [
                  "XTQPYLR3IIU9C44VRCB3XD12"
                ]
              },
              "idempotency_key": "ec78c477-b1c3-4899-a209-a4e71337c996"
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
              "loyalty_promotion": {
                "id": "loypromo_f0f9b849-725e-378d-b810-511237e07b67",
                "name": "Tuesday Happy Hour Promo",
                "incentive": {
                  "type": "POINTS_MULTIPLIER",
                  "points_multiplier_data": {
                    "points_multiplier": 3,
                    "multiplier": "3.000"
                  },
                  "points_addition_data": {
                    "points_addition": 1
                  }
                },
                "available_time": {
                  "start_date": "2022-08-16",
                  "end_date": "end_date",
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
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/programs/program_id/promotions")
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

        var response = await Client.Default.Loyalty.Programs.Promotions.CreateAsync(
            new CreateLoyaltyPromotionRequest
            {
                ProgramId = "program_id",
                LoyaltyPromotion = new LoyaltyPromotion
                {
                    Name = "Tuesday Happy Hour Promo",
                    Incentive = new LoyaltyPromotionIncentive
                    {
                        Type = LoyaltyPromotionIncentiveType.PointsMultiplier,
                        PointsMultiplierData = new LoyaltyPromotionIncentivePointsMultiplierData
                        {
                            Multiplier = "3.0",
                        },
                    },
                    AvailableTime = new LoyaltyPromotionAvailableTimeData
                    {
                        TimePeriods = new List<string>()
                        {
                            "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT",
                        },
                    },
                    TriggerLimit = new LoyaltyPromotionTriggerLimit
                    {
                        Times = 1,
                        Interval = LoyaltyPromotionTriggerLimitInterval.Day,
                    },
                    MinimumSpendAmountMoney = new Money { Amount = 2000, Currency = Currency.Usd },
                    QualifyingCategoryIds = new List<string>() { "XTQPYLR3IIU9C44VRCB3XD12" },
                },
                IdempotencyKey = "ec78c477-b1c3-4899-a209-a4e71337c996",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateLoyaltyPromotionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
