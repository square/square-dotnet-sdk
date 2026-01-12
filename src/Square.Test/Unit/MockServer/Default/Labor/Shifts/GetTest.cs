using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor.Shifts;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "shift": {
                "id": "T35HMQSN89SV4",
                "employee_id": "D71KRMQof6cXGUW0aAv7",
                "location_id": "PAA1RJZZKXBFG",
                "timezone": "America/New_York",
                "start_at": "2019-02-23T23:00:00.000Z",
                "end_at": "2019-02-24T02:00:00.000Z",
                "wage": {
                  "title": "Cashier",
                  "hourly_rate": {
                    "amount": 1457,
                    "currency": "USD"
                  },
                  "job_id": "N4YKVLzFj3oGtNocqoYHYpW3",
                  "tip_eligible": true
                },
                "breaks": [
                  {
                    "id": "M9BBKEPQAQD2T",
                    "start_at": "2019-02-24T00:00:00.000Z",
                    "end_at": "2019-02-24T01:00:00.000Z",
                    "break_type_id": "92EPDRQKJ5088",
                    "name": "Lunch Break",
                    "expected_duration": "PT1H",
                    "is_paid": true
                  }
                ],
                "status": "CLOSED",
                "version": 1,
                "created_at": "2019-02-27T00:12:12.000Z",
                "updated_at": "2019-02-27T00:12:12.000Z",
                "team_member_id": "D71KRMQof6cXGUW0aAv7",
                "declared_cash_tip_money": {
                  "amount": 500,
                  "currency": "USD"
                }
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
                WireMock.RequestBuilders.Request.Create().WithPath("/v2/labor/shifts/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Labor.Shifts.GetAsync(
            new Square.Default.Labor.Shifts.GetShiftsRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetShiftResponse>(mockResponse)).UsingDefaults()
        );
    }
}
