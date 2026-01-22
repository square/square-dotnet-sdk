using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class CancelByIdempotencyKeyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "a7e36d40-d24b-11e8-b568-0800200c9a66"
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payments/cancel")
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

        var response = await Client.Default.Payments.CancelByIdempotencyKeyAsync(
            new CancelPaymentByIdempotencyKeyRequest
            {
                IdempotencyKey = "a7e36d40-d24b-11e8-b568-0800200c9a66",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelPaymentByIdempotencyKeyResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
