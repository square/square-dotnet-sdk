using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Refunds;

[TestFixture]
public class GetTest : BaseMockServerTest
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
                "id": "bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY_69MmgHubkLqx9wGhnmenRUHOaKitE6llfZuxcWYjGxd",
                "status": "COMPLETED",
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
                  "amount": 555,
                  "currency": "USD"
                },
                "app_fee_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "processing_fee": [
                  {
                    "effective_at": "2021-10-13T21:34:35.000Z",
                    "type": "INITIAL",
                    "amount_money": {
                      "amount": -34,
                      "currency": "USD"
                    }
                  }
                ],
                "payment_id": "bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY",
                "order_id": "9ltv0bx5PuvGXUYHYHxYSKEqC3IZY",
                "reason": "Example Refund",
                "created_at": "2021-10-13T19:59:05.073Z",
                "updated_at": "2021-10-13T20:00:02.442Z",
                "team_member_id": "team_member_id",
                "terminal_refund_id": "terminal_refund_id"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/refunds/refund_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Refunds.GetAsync(
            new Square.Refunds.GetRefundsRequest { RefundId = "refund_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetPaymentRefundResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
