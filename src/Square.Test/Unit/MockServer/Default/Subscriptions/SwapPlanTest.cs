using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Subscriptions;

[TestFixture]
public class SwapPlanTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "new_plan_variation_id": "FQ7CDXXWSLUJRPM3GFJSJGZ7",
              "phases": [
                {
                  "ordinal": 0,
                  "order_template_id": "uhhnjH9osVv3shUADwaC0b3hNxQZY"
                }
              ]
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
                "monthly_billing_anchor_date": 1,
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
                  "type": "SWAP_PLAN",
                  "effective_date": "2023-11-17",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {
                      "ordinal": 0,
                      "order_template_id": "uhhnjH9osVv3shUADwaC0b3hNxQZY"
                    }
                  ],
                  "new_plan_variation_id": "FQ7CDXXWSLUJRPM3GFJSJGZ7"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/subscription_id/swap-plan")
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

        var response = await Client.Default.Subscriptions.SwapPlanAsync(
            new SwapPlanRequest
            {
                SubscriptionId = "subscription_id",
                NewPlanVariationId = "FQ7CDXXWSLUJRPM3GFJSJGZ7",
                Phases = new List<PhaseInput>()
                {
                    new PhaseInput
                    {
                        Ordinal = 0,
                        OrderTemplateId = "uhhnjH9osVv3shUADwaC0b3hNxQZY",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SwapPlanResponse>(mockResponse)).UsingDefaults()
        );
    }
}
