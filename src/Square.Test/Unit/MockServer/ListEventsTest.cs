using global::System.Threading.Tasks;
using NUnit.Framework;
using Square.CashDrawers.Shifts;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class ListEventsTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
              "cash_drawer_shift_events": [
                {
                  "id": "9F07DB01-D85A-4B77-88C3-D5C64CEB5155",
                  "event_type": "CASH_TENDER_PAYMENT",
                  "event_money": {
                    "amount": 100,
                    "currency": "USD"
                  },
                  "created_at": "2019-11-22T00:43:02.000Z",
                  "description": "",
                  "team_member_id": ""
                },
                {
                  "id": "B2854CEA-A781-49B3-8F31-C64558231F48",
                  "event_type": "CASH_TENDER_PAYMENT",
                  "event_money": {
                    "amount": 250,
                    "currency": "USD"
                  },
                  "created_at": "2019-11-22T00:43:12.000Z",
                  "description": "",
                  "team_member_id": ""
                },
                {
                  "id": "B5FB7F72-95CD-44A3-974D-26C41064D042",
                  "event_type": "CASH_TENDER_CANCELLED_PAYMENT",
                  "event_money": {
                    "amount": 250,
                    "currency": "USD"
                  },
                  "created_at": "2019-11-22T00:43:23.000Z",
                  "description": "",
                  "team_member_id": ""
                },
                {
                  "id": "0B425480-8504-40B4-A867-37B23543931B",
                  "event_type": "CASH_TENDER_REFUND",
                  "event_money": {
                    "amount": 100,
                    "currency": "USD"
                  },
                  "created_at": "2019-11-22T00:43:46.000Z",
                  "description": "",
                  "team_member_id": ""
                },
                {
                  "id": "8C66E60E-FDCF-4EEF-A98D-3B14B7ED5CBE",
                  "event_type": "PAID_IN",
                  "event_money": {
                    "amount": 10000,
                    "currency": "USD"
                  },
                  "created_at": "2019-11-22T00:44:18.000Z",
                  "description": "Transfer from another drawer",
                  "team_member_id": ""
                },
                {
                  "id": "D5ACA7FE-C64D-4ADA-8BC8-82118A2DAE4F",
                  "event_type": "PAID_OUT",
                  "event_money": {
                    "amount": 10000,
                    "currency": "USD"
                  },
                  "created_at": "2019-11-22T00:44:29.000Z",
                  "description": "Transfer out to another drawer",
                  "team_member_id": ""
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cash-drawers/shifts/shift_id/events")
                    .WithParam("location_id", "location_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var pager = await Client.CashDrawers.Shifts.ListEventsAsync(
            new ListEventsShiftsRequest { ShiftId = "shift_id", LocationId = "location_id" },
            RequestOptions
        );
        await foreach (var item in pager)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
