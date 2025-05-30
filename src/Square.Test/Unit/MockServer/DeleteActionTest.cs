using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Subscriptions;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class DeleteActionTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
                "id": "8151fc89-da15-4eb9-a685-1a70883cebfc",
                "location_id": "S8GWD5R9QB376",
                "plan_variation_id": "6JHXF3B2CW3YKHDV4XEM674H",
                "customer_id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                "start_date": "2022-07-27",
                "canceled_date": "canceled_date",
                "charged_through_date": "2023-11-20",
                "status": "ACTIVE",
                "tax_percentage": "tax_percentage",
                "invoice_ids": [
                  "inv:0-ChCHu2mZEabLeeHahQnXDjZQECY",
                  "inv:0-ChrcX_i3sNmfsHTGKhI4Wg2mceA"
                ],
                "price_override_money": {
                  "amount": 25000,
                  "currency": "USD"
                },
                "version": 1000000,
                "created_at": "2022-07-27T21:53:10.000Z",
                "card_id": "ccof:IkWfpLj4tNHMyFii3GB",
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
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/subscriptions/subscription_id/actions/action_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Subscriptions.DeleteActionAsync(
            new DeleteActionSubscriptionsRequest
            {
                SubscriptionId = "subscription_id",
                ActionId = "action_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteSubscriptionActionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
