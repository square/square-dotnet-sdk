using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.OAuth;

[TestFixture]
public class RetrieveTokenStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "scopes": [
                "PAYMENTS_READ",
                "PAYMENTS_WRITE"
              ],
              "expires_at": "2022-10-14T14:44:00.000Z",
              "client_id": "CLIENT_ID",
              "merchant_id": "MERCHANT_ID",
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
                    .WithPath("/oauth2/token/status")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OAuth.RetrieveTokenStatusAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveTokenStatusResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
