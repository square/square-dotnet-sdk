using NUnit.Framework;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.OAuth;

[TestFixture]
public class AuthorizeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/oauth2/authorize").UsingGet()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () => await Client.OAuth.AuthorizeAsync());
    }
}
