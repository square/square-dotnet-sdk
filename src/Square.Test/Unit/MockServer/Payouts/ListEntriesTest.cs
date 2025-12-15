using NUnit.Framework;
using Square;
using Square.Payouts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Payouts;

[TestFixture]
public class ListEntriesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "payout_entries": [
                {
                  "id": "poe_ZQWcw41d0SGJS6IWd4cSi8mKHk",
                  "payout_id": "po_4d28e6c4-7dd5-4de4-8ec9-a059277646a6",
                  "effective_at": "2021-12-14T23:31:49.000Z",
                  "type": "REFUND",
                  "gross_amount_money": {
                    "amount": -50
                  },
                  "fee_amount_money": {
                    "amount": -2
                  },
                  "net_amount_money": {
                    "amount": -48
                  },
                  "type_refund_details": {
                    "payment_id": "HVdG62HeMlti8YYf94oxrN",
                    "refund_id": "HVdG62HeMlti8YYf94oxrN_dR8Nztxg7umf94oxrN12Ji5r2KW14FAY"
                  }
                },
                {
                  "id": "poe_EibbY9Ob1d0SGJS6IWd4cSiSi6wkaPk",
                  "payout_id": "po_4d28e6c4-7dd5-4de4-8ec9-a059277646a6",
                  "effective_at": "2021-12-14T23:31:49.000Z",
                  "type": "CHARGE",
                  "gross_amount_money": {
                    "amount": 100
                  },
                  "fee_amount_money": {
                    "amount": 19
                  },
                  "net_amount_money": {
                    "amount": 81
                  },
                  "type_charge_details": {
                    "payment_id": "HVdG62H5K3291d0SGJS6IWd4cSi8YY"
                  }
                }
              ],
              "cursor": "TbfI80z98Xc2LdApCyZ2NvCYLpkPurYLR16GRIttpMJ55mrSIMzHgtkcRQdT0mOnTtfHO",
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
                    .WithPath("/v2/payouts/payout_id/payout-entries")
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

        var items = await Client.Payouts.ListEntriesAsync(
            new ListEntriesPayoutsRequest
            {
                PayoutId = "payout_id",
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
