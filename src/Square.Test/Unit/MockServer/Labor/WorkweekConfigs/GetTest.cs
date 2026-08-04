using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor.WorkweekConfigs;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor.WorkweekConfigs;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "workweek_config": {
                "start_of_week": "MON",
                "start_of_day_local_time": "10:00",
                "version": 10
              }
            }
            """;

        const string mockResponse = """
            {
              "workweek_config": {
                "id": "FY4VCAQN700GM",
                "start_of_week": "MON",
                "start_of_day_local_time": "10:00",
                "version": 11,
                "created_at": "2016-02-04T00:58:24.000Z",
                "updated_at": "2019-02-28T01:04:35.000Z"
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
                    .WithPath("/v2/labor/workweek-configs/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.WorkweekConfigs.GetAsync(
            new UpdateWorkweekConfigRequest
            {
                Id = "id",
                WorkweekConfig = new WorkweekConfig
                {
                    StartOfWeek = Weekday.Mon,
                    StartOfDayLocalTime = "10:00",
                    Version = 10,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateWorkweekConfigResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
