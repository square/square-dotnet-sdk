using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Payments;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class CancelByIdempotencyKeyTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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

        var response = await Client.Payments.CancelByIdempotencyKeyAsync(
            new CancelPaymentByIdempotencyKeyRequest
            {
                IdempotencyKey = "a7e36d40-d24b-11e8-b568-0800200c9a66",
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelPaymentByIdempotencyKeyResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
