using NUnit.Framework;
using Square;
using Square.Core;
using Square.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Subscriptions;

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
              "subscription": {
                "id": "910afd30-464a-4e00-a8d8-2296e",
                "location_id": "S8GWD5R9QB376",
                "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H",
                "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
                "start_date": "2022-01-19",
                "canceled_date": "2023-06-05",
                "charged_through_date": "charged_through_date",
                "status": "ACTIVE",
                "tax_percentage": "tax_percentage",
                "invoice_ids": [
                  "inv:0-ChCHu2mZEabLeeHahQnXDjZQECY",
                  "inv:0-ChrcX_i3sNmfsHTGKhI4Wg2mceA"
                ],
                "price_override_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "version": 3,
                "created_at": "2022-01-19T21:53:10.000Z",
                "card_id": "ccof:qy5x8hHGYsgLrp4Q4GB",
                "timezone": "America/Los_Angeles",
                "source": {
                  "name": "My Application"
                },
                "actions": [
                  {}
                ],
                "monthly_billing_anchor_date": 1,
                "phases": [
                  {}
                ],
                "completed_date": "completed_date"
              },
              "actions": [
                {
                  "id": "id",
                  "type": "CANCEL",
                  "effective_date": "effective_date",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "new_plan_variation_id": "new_plan_variation_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/subscription_id/cancel")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Subscriptions.CancelAsync(
            new CancelSubscriptionsRequest { SubscriptionId = "subscription_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
