using NUnit.Framework;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class AuthorizeTest : BaseMockServerTest
{
    [Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/oauth2/authorize").UsingGet()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () => await Client.OAuth.AuthorizeAsync(RequestOptions));
    }
}
