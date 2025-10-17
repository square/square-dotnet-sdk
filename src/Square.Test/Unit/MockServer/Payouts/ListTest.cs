using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Payouts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Payouts;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "payouts": [
                {
                  "id": "po_b345d2c7-90b3-4f0b-a2aa-df1def7f8afc",
                  "status": "PAID",
                  "location_id": "L88917AVBK2S5",
                  "created_at": "2022-03-29T16:12:31.000Z",
                  "updated_at": "2022-03-30T01:07:22.875Z",
                  "amount_money": {
                    "amount": 6259
                  },
                  "destination": {
                    "type": "CARD",
                    "id": "ccof:ZPp3oedR3AeEUNd3z7"
                  },
                  "version": 2,
                  "type": "BATCH",
                  "payout_fee": [
                    {
                      "amount_money": {
                        "amount": 95
                      },
                      "effective_at": "2022-03-29T16:12:31.000Z",
                      "type": "TRANSFER_FEE"
                    }
                  ],
                  "arrival_date": "2022-03-29",
                  "end_to_end_id": "L2100000005"
                },
                {
                  "id": "po_f3c0fb38-a5ce-427d-b858-52b925b72e45",
                  "status": "PAID",
                  "location_id": "L88917AVBK2S5",
                  "created_at": "2022-03-24T03:07:09.000Z",
                  "updated_at": "2022-03-24T03:07:09.000Z",
                  "amount_money": {
                    "amount": -103
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
                  "end_to_end_id": "L2100000006"
                }
              ],
              "cursor": "EMPCyStibo64hS8wLayZPp3oedR3AeEUNd3z7u6zphi72LQZFIEMbkKVvot9eefpU",
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
                    .WithPath("/v2/payouts")
                    .WithParam("location_id", "location_id")
                    .WithParam("status", "SENT")
                    .WithParam("begin_time", "begin_time")
                    .WithParam("end_time", "end_time")
                    .WithParam("sort_order", "DESC")
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

        var items = await Client.Payouts.ListAsync(
            new ListPayoutsRequest
            {
                LocationId = "location_id",
                Status = PayoutStatus.Sent,
                BeginTime = "begin_time",
                EndTime = "end_time",
                SortOrder = SortOrder.Desc,
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
