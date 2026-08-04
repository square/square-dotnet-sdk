using NUnit.Framework;
using Square;
using Square.Core;
using Square.Terminal;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Terminal;

[TestFixture]
public class DismissTerminalRefundTest : BaseMockServerTest
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
              "refund": {
                "id": "vjkNb2HD-xq5kiWWiJ7RhwrQnkxIn2N0l1nPZY",
                "refund_id": "refund_id",
                "payment_id": "xq5kiWWiJ7RhwrQnkxIn2N0l1nPZY",
                "order_id": "s8OMhQcpEp1b61YywlccSHWqUaQZY",
                "amount_money": {
                  "amount": 111,
                  "currency": "CAD"
                },
                "reason": "Returning item",
                "device_id": "47776348fd8b32b9",
                "deadline_duration": "PT5M",
                "status": "IN_PROGRESS",
                "cancel_reason": "BUYER_CANCELED",
                "created_at": "2023-11-30T16:16:39.299Z",
                "updated_at": "2023-11-30T16:16:57.863Z",
                "app_id": "APP_ID",
                "location_id": "location_id"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/refunds/terminal_refund_id/dismiss")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Terminal.DismissTerminalRefundAsync(
            new DismissTerminalRefundRequest { TerminalRefundId = "terminal_refund_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DismissTerminalRefundResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
