using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal.Refunds;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class CancelTest : BaseMockServerTest
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
              "refund": {
                "id": "g6ycb6HD-5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                "refund_id": "refund_id",
                "payment_id": "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                "order_id": "kcuKDKreRaI4gF4TjmEgZjHk8Z7YY",
                "amount_money": {
                  "amount": 100,
                  "currency": "CAD"
                },
                "reason": "reason",
                "device_id": "42690809-faa2-4701-a24b-19d3d34c9aaa",
                "deadline_duration": "PT5M",
                "status": "CANCELED",
                "cancel_reason": "SELLER_CANCELED",
                "created_at": "2020-10-21T22:47:23.241Z",
                "updated_at": "2020-10-21T22:47:30.096Z",
                "app_id": "sandbox-sq0idb-c2OuYt13YaCAeJq_2cd8OQ",
                "location_id": "76C9W6K8CNNQ5"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/refunds/terminal_refund_id/cancel")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Terminal.Refunds.CancelAsync(
            new CancelRefundsRequest { TerminalRefundId = "terminal_refund_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelTerminalRefundResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
