using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Payouts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Payouts;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "payout": {
                "id": "po_f3c0fb38-a5ce-427d-b858-52b925b72e45",
                "status": "PAID",
                "location_id": "L88917AVBK2S5",
                "created_at": "2022-03-24T03:07:09.000Z",
                "updated_at": "2022-03-24T03:07:09.000Z",
                "amount_money": {
                  "amount": -103,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "destination": {
                  "type": "BANK_ACCOUNT",
                  "id": "bact:ZPp3oedR3AeEUNd3z7"
                },
                "version": 1,
                "type": "BATCH",
                "payout_fee": [
                  {}
                ],
                "arrival_date": "2022-03-24",
                "end_to_end_id": "end_to_end_id"
              },
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payouts/payout_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Payouts.GetAsync(
            new GetPayoutsRequest { PayoutId = "payout_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetPayoutResponse>(mockResponse)).UsingDefaults()
        );
    }
}
