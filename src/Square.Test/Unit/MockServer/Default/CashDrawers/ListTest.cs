using NUnit.Framework;
using Square.Default;
using Square.Default.CashDrawers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.CashDrawers;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "cursor": "cursor",
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "cash_drawer_shifts": [
                {
                  "id": "DCC99978-09A6-4926-849F-300BE9C5793A",
                  "state": "CLOSED",
                  "opened_at": "2019-11-22T00:42:54.000Z",
                  "ended_at": "2019-11-22T00:44:49.000Z",
                  "closed_at": "2019-11-22T00:44:49.000Z",
                  "description": "Misplaced some change",
                  "opened_cash_money": {
                    "amount": 10000,
                    "currency": "USD"
                  },
                  "expected_cash_money": {
                    "amount": 10000,
                    "currency": "USD"
                  },
                  "closed_cash_money": {
                    "amount": 9970,
                    "currency": "USD"
                  },
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "location_id": "location_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cash-drawers/shifts")
                    .WithParam("location_id", "location_id")
                    .WithParam("sort_order", "DESC")
                    .WithParam("begin_time", "begin_time")
                    .WithParam("end_time", "end_time")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.CashDrawers.Shifts.ListAsync(
            new ListShiftsRequest
            {
                LocationId = "location_id",
                SortOrder = SortOrder.Desc,
                BeginTime = "begin_time",
                EndTime = "end_time",
                Limit = 1,
                Cursor = "cursor",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
