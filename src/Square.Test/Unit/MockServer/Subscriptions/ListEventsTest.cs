using System.Threading.Tasks;
using NUnit.Framework;
using Square.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Subscriptions;

[TestFixture]
public class ListEventsTest : BaseMockServerTest
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
              "subscription_events": [
                {
                  "id": "06809161-3867-4598-8269-8aea5be4f9de",
                  "subscription_event_type": "START_SUBSCRIPTION",
                  "effective_date": "2020-04-24",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H"
                },
                {
                  "id": "f2736603-cd2e-47ec-8675-f815fff54f88",
                  "subscription_event_type": "DEACTIVATE_SUBSCRIPTION",
                  "effective_date": "2020-05-01",
                  "monthly_billing_anchor_date": 1,
                  "info": {
                    "detail": "The customer with ID `V74BMG0GPS2KNCWJE1BTYJ37Y0` does not have a name on record.",
                    "code": "CUSTOMER_NO_NAME"
                  },
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H"
                },
                {
                  "id": "b426fc85-6859-450b-b0d0-fe3a5d1b565f",
                  "subscription_event_type": "RESUME_SUBSCRIPTION",
                  "effective_date": "2022-05-01",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H"
                },
                {
                  "id": "09f14de1-2f53-4dae-9091-49aa53f83d01",
                  "subscription_event_type": "PAUSE_SUBSCRIPTION",
                  "effective_date": "2022-09-01",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H"
                },
                {
                  "id": "f28a73ac-1a1b-4b0f-8eeb-709a72945776",
                  "subscription_event_type": "RESUME_SUBSCRIPTION",
                  "effective_date": "2022-12-01",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H"
                },
                {
                  "id": "1eee8790-472d-4efe-8c69-8ad84e9cefe0",
                  "subscription_event_type": "PLAN_CHANGE",
                  "effective_date": "2023-04-01",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "02CD53CFA4d1498AFAD42"
                },
                {
                  "id": "a0c08083-5db0-4800-85c7-d398de4fbb6e",
                  "subscription_event_type": "STOP_SUBSCRIPTION",
                  "effective_date": "2023-06-21",
                  "monthly_billing_anchor_date": 1,
                  "phases": [
                    {}
                  ],
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/subscription_id/events")
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

        var items = await Client.Subscriptions.ListEventsAsync(
            new ListEventsSubscriptionsRequest
            {
                SubscriptionId = "subscription_id",
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
