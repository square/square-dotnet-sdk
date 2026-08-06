using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor;

[TestFixture]
public class DeleteTimecardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
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
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.DeleteTimecardAsync(
            new DeleteTimecardRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteTimecardResponse>(mockResponse)).UsingDefaults()
        );
    }
}
