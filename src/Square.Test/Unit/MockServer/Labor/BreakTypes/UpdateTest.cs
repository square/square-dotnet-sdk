using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor.BreakTypes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor.BreakTypes;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "break_type": {
                "location_id": "26M7H24AZ9N6R",
                "break_name": "Lunch",
                "expected_duration": "PT50M",
                "is_paid": true,
                "version": 1
              }
            }
            """;

        const string mockResponse = """
            {
              "break_type": {
                "id": "Q6JSJS6D4DBCH",
                "location_id": "26M7H24AZ9N6R",
                "break_name": "Lunch",
                "expected_duration": "PT50M",
                "is_paid": true,
                "version": 2,
                "created_at": "2018-06-12T20:19:12.000Z",
                "updated_at": "2019-02-26T23:12:59.000Z"
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
                    .WithPath("/v2/labor/break-types/id")
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

        var response = await Client.Labor.BreakTypes.UpdateAsync(
            new UpdateBreakTypeRequest
            {
                Id = "id",
                BreakType = new BreakType
                {
                    LocationId = "26M7H24AZ9N6R",
                    BreakName = "Lunch",
                    ExpectedDuration = "PT50M",
                    IsPaid = true,
                    Version = 1,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateBreakTypeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
