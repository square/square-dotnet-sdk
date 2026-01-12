using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Labor.BreakTypes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor.BreakTypes;

[TestFixture]
public class DeleteTest : BaseMockServerTest
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
                    .WithPath("/v2/labor/break-types/id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Labor.BreakTypes.DeleteAsync(
            new DeleteBreakTypesRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteBreakTypeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
