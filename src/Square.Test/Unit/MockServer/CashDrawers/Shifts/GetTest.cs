using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.CashDrawers.Shifts;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "cash_drawer_shift": {
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
                "cash_payment_money": {
                  "amount": 100,
                  "currency": "USD"
                },
                "cash_refunds_money": {
                  "amount": -100,
                  "currency": "USD"
                },
                "cash_paid_in_money": {
                  "amount": 10000,
                  "currency": "USD"
                },
                "cash_paid_out_money": {
                  "amount": -10000,
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
                "device": {
                  "id": "id",
                  "name": "My iPad"
                },
                "created_at": "created_at",
                "updated_at": "updated_at",
                "location_id": "location_id",
                "team_member_ids": [
                  "team_member_ids"
                ],
                "opening_team_member_id": "",
                "ending_team_member_id": "",
                "closing_team_member_id": ""
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
                    .WithPath("/v2/cash-drawers/shifts/shift_id")
                    .WithParam("location_id", "location_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CashDrawers.Shifts.GetAsync(
            new Square.CashDrawers.Shifts.GetShiftsRequest
            {
                ShiftId = "shift_id",
                LocationId = "location_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetCashDrawerShiftResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
