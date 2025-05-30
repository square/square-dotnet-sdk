using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.OAuth;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RevokeTokenTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "client_id": "CLIENT_ID",
              "access_token": "ACCESS_TOKEN"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
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
                    .WithPath("/oauth2/revoke")
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

        var response = await Client.OAuth.RevokeTokenAsync(
            new RevokeTokenRequest { ClientId = "CLIENT_ID", AccessToken = "ACCESS_TOKEN" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RevokeTokenResponse>(mockResponse)).UsingDefaults()
        );
    }
}
