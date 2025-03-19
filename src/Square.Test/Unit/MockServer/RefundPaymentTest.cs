using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Refunds;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RefundPaymentTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "9b7f2dcf-49da-4411-b23e-a2d6af21333a",
              "amount_money": {
                "amount": 1000,
                "currency": "USD"
              },
              "app_fee_money": {
                "amount": 10,
                "currency": "USD"
              },
              "payment_id": "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY",
              "reason": "Example"
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
              "refund": {
                "id": "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY_KlWP8IC1557ddwc9QWTKrCVU6m0JXDz15R2Qym5eQfR",
                "status": "PENDING",
                "location_id": "L88917AVBK2S5",
                "unlinked": true,
                "destination_type": "destination_type",
                "destination_details": {
                  "cash_details": {
                    "seller_supplied_money": {}
                  },
                  "external_details": {
                    "type": "type",
                    "source": "source"
                  }
                },
                "amount_money": {
                  "amount": 1000,
                  "currency": "USD"
                },
                "app_fee_money": {
                  "amount": 10,
                  "currency": "USD"
                },
                "processing_fee": [
                  {}
                ],
                "payment_id": "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY",
                "order_id": "1JLEUZeEooAIX8HMqm9kvWd69aQZY",
                "reason": "Example",
                "created_at": "2021-10-13T21:23:19.116Z",
                "updated_at": "2021-10-13T21:23:19.508Z",
                "team_member_id": "team_member_id",
                "terminal_refund_id": "terminal_refund_id"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/refunds")
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

        var response = await Client.Refunds.RefundPaymentAsync(
            new RefundPaymentRequest
            {
                IdempotencyKey = "9b7f2dcf-49da-4411-b23e-a2d6af21333a",
                AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
                AppFeeMoney = new Money { Amount = 10, Currency = Currency.Usd },
                PaymentId = "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY",
                Reason = "Example",
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RefundPaymentResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
