using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Mobile;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Mobile;

[TestFixture]
public class AuthorizationCodeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location_id": "YOUR_LOCATION_ID"
            }
            """;

        const string mockResponse = """
            {
              "authorization_code": "YOUR_MOBILE_AUTHORIZATION_CODE",
              "expires_at": "2019-01-10T19:42:08.000Z",
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
                    .WithPath("/mobile/authorization-code")
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

        var response = await Client.Default.Mobile.AuthorizationCodeAsync(
            new CreateMobileAuthorizationCodeRequest { LocationId = "YOUR_LOCATION_ID" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateMobileAuthorizationCodeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
