using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Subscriptions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Subscriptions;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "subscription": {
                "card_id": "{NEW CARD ID}"
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
              "subscription": {
                "id": "7217d8ca-1fee-4446-a9e5-8540b5d8c9bb",
                "location_id": "LPJKHYR7WFDKN",
                "plan_variation_id": "XOUNEKCE6NSXQW5NTSQ73MMX",
                "customer_id": "AM69AB81FT4479YH9HGWS1HZY8",
                "start_date": "2023-01-30",
                "canceled_date": "canceled_date",
                "charged_through_date": "2023-03-13",
                "status": "ACTIVE",
                "tax_percentage": "tax_percentage",
                "invoice_ids": [
                  "inv:0-ChAPSfVYvNewckgf3x4iigN_ENMM",
                  "inv:0-ChBQaCCLfjcm9WEUBGxvuydJENMM"
                ],
                "price_override_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "version": 3,
                "created_at": "2023-01-30T19:27:32.000Z",
                "card_id": "{NEW CARD ID}",
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
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/subscription_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Subscriptions.UpdateAsync(
            new UpdateSubscriptionRequest
            {
                SubscriptionId = "subscription_id",
                Subscription = new Subscription { CardId = "{NEW CARD ID}" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateSubscriptionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
