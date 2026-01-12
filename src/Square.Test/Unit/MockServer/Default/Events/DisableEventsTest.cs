using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Events;

[TestFixture]
public class DisableEventsTest : BaseMockServerTest
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
                WireMock.RequestBuilders.Request.Create().WithPath("/v2/events/disable").UsingPut()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Events.DisableEventsAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DisableEventsResponse>(mockResponse)).UsingDefaults()
        );
    }
}
