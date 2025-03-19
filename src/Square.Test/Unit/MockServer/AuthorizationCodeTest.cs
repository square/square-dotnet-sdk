using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Mobile;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class AuthorizationCodeTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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

        var response = await Client.Mobile.AuthorizationCodeAsync(
            new CreateMobileAuthorizationCodeRequest { LocationId = "YOUR_LOCATION_ID" },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateMobileAuthorizationCodeResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
