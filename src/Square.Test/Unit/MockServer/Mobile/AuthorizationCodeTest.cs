using NUnit.Framework;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Mobile;

[TestFixture]
public class AuthorizationCodeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/mobile/authorization-code")
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () => await Client.Mobile.AuthorizationCodeAsync());
    }
}
