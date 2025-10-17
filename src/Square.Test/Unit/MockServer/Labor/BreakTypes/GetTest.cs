using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor.BreakTypes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor.BreakTypes;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "break_type": {
                "id": "lA0mj_RSOprNPwMUXdYp",
                "location_id": "059SB0E0WCNWS",
                "break_name": "Lunch Break",
                "expected_duration": "PT30M",
                "is_paid": true,
                "version": 1,
                "created_at": "2019-02-21T17:50:00.000Z",
                "updated_at": "2019-02-21T17:50:00.000Z"
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.BreakTypes.GetAsync(
            new GetBreakTypesRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetBreakTypeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
