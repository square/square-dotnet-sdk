using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor;

[TestFixture]
public class RetrieveTimecardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "timecard": {
                "id": "T35HMQSN89SV4",
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
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/labor/timecards/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.RetrieveTimecardAsync(
            new RetrieveTimecardRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveTimecardResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
