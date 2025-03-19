using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Webhooks.Subscriptions;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class UpdateSignatureKeyTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "ed80ae6b-0654-473b-bbab-a39aee89a60d"
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
              "signature_key": "1k9bIJKCeTmSQwyagtNRLg"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions/subscription_id/signature-key")
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

        var response = await Client.Webhooks.Subscriptions.UpdateSignatureKeyAsync(
            new UpdateWebhookSubscriptionSignatureKeyRequest
            {
                SubscriptionId = "subscription_id",
                IdempotencyKey = "ed80ae6b-0654-473b-bbab-a39aee89a60d",
            },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<UpdateWebhookSubscriptionSignatureKeyResponse>(
                        mockResponse
                    )
                )
                .UsingPropertiesComparer()
        );
    }
}
