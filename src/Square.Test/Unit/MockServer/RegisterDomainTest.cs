using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.ApplePay;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RegisterDomainTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "domain_name": "example.com"
            }
            """;

        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "status": "VERIFIED"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/apple-pay/domains")
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

        var response = await Client.ApplePay.RegisterDomainAsync(
            new RegisterDomainRequest { DomainName = "example.com" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RegisterDomainResponse>(mockResponse)).UsingDefaults()
        );
    }
}
