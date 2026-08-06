using NUnit.Framework;
using Square;
using Square.Core;
using Square.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Subscriptions;

[TestFixture]
public class ChangeBillingAnchorDateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "monthly_billing_anchor_date": 1
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
              "subscription": {
                "id": "9ba40961-995a-4a3d-8c53-048c40cafc13",
                "location_id": "S8GWD5R9QB376",
                "plan_variation_id": "FQ7CDXXWSLUJRPM3GFJSJGZ7",
                "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
                "start_date": "start_date",
                "canceled_date": "canceled_date",
                "charged_through_date": "charged_through_date",
                "status": "ACTIVE",
                "tax_percentage": "tax_percentage",
                "invoice_ids": [
                  "invoice_ids"
                ],
                "price_override_money": {
                  "amount": 2000,
                  "currency": "USD"
                },
                "version": 3,
                "created_at": "2023-06-20T21:53:10.000Z",
                "card_id": "card_id",
                "timezone": "America/Los_Angeles",
                "source": {
                  "name": "My Application"
                },
                "actions": [
                  {}
                ],
                "monthly_billing_anchor_date": 20,
                "phases": [
                  {
                    "uid": "98d6f53b-40e1-4714-8827-032fd923be25",
                    "ordinal": 0,
                    "order_template_id": "E6oBY5WfQ2eN4pkYZwq4ka6n7KeZY",
                    "plan_phase_uid": "C66BKH3ASTDYGJJCEZXQQSS7"
                  }
                ],
                "completed_date": "completed_date"
              },
              "actions": [
                {
                  "id": "f0a1dfdc-675b-3a14-a640-99f7ac1cee83",
                  "type": "CHANGE_BILLING_ANCHOR_DATE",
                  "effective_date": "2023-11-01",
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
                    .WithPath("/v2/subscriptions/subscription_id/billing-anchor")
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

        var response = await Client.Subscriptions.ChangeBillingAnchorDateAsync(
            new ChangeBillingAnchorDateRequest
            {
                SubscriptionId = "subscription_id",
                MonthlyBillingAnchorDate = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ChangeBillingAnchorDateResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
