using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor.BreakTypes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor.BreakTypes;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "PAD3NG5KSN2GL",
              "break_type": {
                "location_id": "CGJN03P1D08GF",
                "break_name": "Lunch Break",
                "expected_duration": "PT30M",
                "is_paid": true
              }
            }
            """;

        const string mockResponse = """
            {
              "break_type": {
                "id": "49SSVDJG76WF3",
                "location_id": "CGJN03P1D08GF",
                "break_name": "Lunch Break",
                "expected_duration": "PT30M",
                "is_paid": true,
                "version": 1,
                "created_at": "2019-02-26T22:42:54.000Z",
                "updated_at": "2019-02-26T22:42:54.000Z"
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
                    .WithPath("/v2/labor/break-types")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.BreakTypes.CreateAsync(
            new CreateBreakTypeRequest
            {
                IdempotencyKey = "PAD3NG5KSN2GL",
                BreakType = new BreakType
                {
                    LocationId = "CGJN03P1D08GF",
                    BreakName = "Lunch Break",
                    ExpectedDuration = "PT30M",
                    IsPaid = true,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateBreakTypeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
