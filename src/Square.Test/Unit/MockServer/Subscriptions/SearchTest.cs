using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Subscriptions;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "customer_ids": [
                    "CHFGVKYY8RSV93M5KCYTG4PN0G"
                  ],
                  "location_ids": [
                    "S8GWD5R9QB376"
                  ],
                  "source_names": [
                    "My App"
                  ]
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
              "subscriptions": [
                {
                  "id": "de86fc96-8664-474b-af1a-abbe59cacf0e",
                  "location_id": "S8GWD5R9QB376",
                  "plan_variation_id": "L3TJVDHVBEQEGQDEZL2JJM7R",
                  "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
                  "start_date": "2021-10-20",
                  "canceled_date": "2021-10-30",
                  "charged_through_date": "2021-11-20",
                  "status": "CANCELED",
                  "tax_percentage": "tax_percentage",
                  "invoice_ids": [
                    "invoice_ids"
                  ],
                  "version": 1000000,
                  "created_at": "2021-10-20T21:53:10.000Z",
                  "card_id": "ccof:mueUsvgajChmjEbp4GB",
                  "timezone": "UTC",
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
                {
                  "id": "56214fb2-cc85-47a1-93bc-44f3766bb56f",
                  "location_id": "S8GWD5R9QB376",
                  "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H",
                  "customer_id": "CHFGVKYY8RSV93M5KCYTG4PN0G",
                  "start_date": "2022-01-19",
                  "canceled_date": "canceled_date",
                  "charged_through_date": "2022-08-19",
                  "status": "PAUSED",
                  "tax_percentage": "5",
                  "invoice_ids": [
                    "grebK0Q_l8H4fqoMMVvt-Q",
                    "rcX_i3sNmHTGKhI4W2mceA"
                  ],
                  "price_override_money": {
                    "amount": 1000,
                    "currency": "USD"
                  },
                  "version": 2,
                  "created_at": "2022-01-19T21:53:10.000Z",
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
                    {}
                  ],
                  "completed_date": "completed_date"
                },
                {
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
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/search")
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

        var response = await Client.Subscriptions.SearchAsync(
            new SearchSubscriptionsRequest
            {
                Query = new SearchSubscriptionsQuery
                {
                    Filter = new SearchSubscriptionsFilter
                    {
                        CustomerIds = new List<string>() { "CHFGVKYY8RSV93M5KCYTG4PN0G" },
                        LocationIds = new List<string>() { "S8GWD5R9QB376" },
                        SourceNames = new List<string>() { "My App" },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchSubscriptionsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
