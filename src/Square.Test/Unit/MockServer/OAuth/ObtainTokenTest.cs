using NUnit.Framework;
using Square;
using Square.Core;
using Square.OAuth;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.OAuth;

[TestFixture]
public class ObtainTokenTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "client_id": "sq0idp-uaPHILoPzWZk3tlJqlML0g",
              "client_secret": "sq0csp-30a-4C_tVOnTh14Piza2BfTPBXyLafLPWSzY1qAjeBfM",
              "code": "sq0cgb-l0SBqxs4uwxErTVyYOdemg",
              "grant_type": "authorization_code"
            }
            """;

        const string mockResponse = """
            {
              "access_token": "EAAl3ikZIe18J-2-cHlV2bL4-EaZHGoJUhtEBT7QA6-7AgwIHw8Xe1IoUvGsNxA",
              "token_type": "bearer",
              "expires_at": "2025-04-03T18:31:06.000Z",
              "merchant_id": "MLQW2MYBY81PZ",
              "subscription_id": "subscription_id",
              "plan_id": "plan_id",
              "id_token": "id_token",
              "refresh_token": "EQAAl0OcByu3IYJYScGGg-8E5YNf0r0b6jCTCMy5nOcRZ4ok0wbWAL8vY3tZWNcc",
              "short_lived": false,
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "refresh_token_expires_at": "refresh_token_expires_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/oauth2/token")
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

        var response = await Client.OAuth.ObtainTokenAsync(
            new ObtainTokenRequest
            {
                ClientId = "sq0idp-uaPHILoPzWZk3tlJqlML0g",
                ClientSecret = "sq0csp-30a-4C_tVOnTh14Piza2BfTPBXyLafLPWSzY1qAjeBfM",
                Code = "sq0cgb-l0SBqxs4uwxErTVyYOdemg",
                GrantType = "authorization_code",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ObtainTokenResponse>(mockResponse)).UsingDefaults()
        );
    }
}
