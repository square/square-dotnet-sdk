using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Loyalty.Programs.Promotions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Loyalty.Programs.Promotions;

[TestFixture]
public class GetTest : BaseMockServerTest
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
                  "CJ3RYL56ITAKMD4VRCM7XERS",
                  "AT3RYLR3TUA9C34VRCB7X5RR"
                ],
                "qualifying_category_ids": [
                  "qualifying_category_ids"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/programs/program_id/promotions/promotion_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loyalty.Programs.Promotions.GetAsync(
            new GetPromotionsRequest { ProgramId = "program_id", PromotionId = "promotion_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetLoyaltyPromotionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
