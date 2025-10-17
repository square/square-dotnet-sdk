using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Subscriptions;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "8193148c-9586-11e6-99f9-28cfe92138cf",
              "location_id": "S8GWD5R9QB376",
              "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H",
              "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
              "start_date": "2023-06-20",
              "card_id": "ccof:qy5x8hHGYsgLrp4Q4GB",
              "timezone": "America/Los_Angeles",
              "source": {
                "name": "My Application"
              },
              "phases": [
                {
                  "ordinal": 0,
                  "order_template_id": "U2NaowWxzXwpsZU697x7ZHOAnCNZY"
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
                "id": "56214fb2-cc85-47a1-93bc-44f3766bb56f",
                "location_id": "S8GWD5R9QB376",
                "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H",
                "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
                "start_date": "2023-06-20",
                "canceled_date": "canceled_date",
                "charged_through_date": "charged_through_date",
                "status": "ACTIVE",
                "tax_percentage": "tax_percentage",
                "invoice_ids": [
                  "invoice_ids"
                ],
                "price_override_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "version": 1,
                "created_at": "2023-06-20T21:53:10.000Z",
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
                  {
                    "uid": "873451e0-745b-4e87-ab0b-c574933fe616",
                    "ordinal": 0,
                    "order_template_id": "U2NaowWxzXwpsZU697x7ZHOAnCNZY",
                    "plan_phase_uid": "X2Q2AONPB3RB64Y27S25QCZP"
                  }
                ],
                "completed_date": "completed_date"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions")
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

        var response = await Client.Subscriptions.CreateAsync(
            new CreateSubscriptionRequest
            {
                IdempotencyKey = "8193148c-9586-11e6-99f9-28cfe92138cf",
                LocationId = "S8GWD5R9QB376",
                PlanVariationId = "6JHXF3B2CW3YKHDV4XEM674H",
                CustomerId = "CHFGVKYY8RSV93M5KCYTG4PN0G",
                StartDate = "2023-06-20",
                CardId = "ccof:qy5x8hHGYsgLrp4Q4GB",
                Timezone = "America/Los_Angeles",
                Source = new SubscriptionSource { Name = "My Application" },
                Phases = new List<Phase>()
                {
                    new Phase { Ordinal = 0, OrderTemplateId = "U2NaowWxzXwpsZU697x7ZHOAnCNZY" },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
