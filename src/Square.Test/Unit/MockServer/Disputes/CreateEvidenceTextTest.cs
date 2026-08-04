using NUnit.Framework;
using Square;
using Square.Core;
using Square.Disputes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Disputes;

[TestFixture]
public class CreateEvidenceTextTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "ed3ee3933d946f1514d505d173c82648",
              "evidence_type": "TRACKING_NUMBER",
              "evidence_text": "1Z8888888888888888"
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
              "evidence": {
                "evidence_id": "evidence_id",
                "id": "TOomLInj6iWmP3N8qfCXrB",
                "dispute_id": "bVTprrwk0gygTLZ96VX1oB",
                "evidence_file": {
                  "filename": "filename",
                  "filetype": "filetype"
                },
                "evidence_text": "The customer purchased the item twice, on April 11 and April 28.",
                "uploaded_at": "2022-05-18T16:01:10.000Z",
                "evidence_type": "REBUTTAL_EXPLANATION"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes/dispute_id/evidence-text")
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

        var response = await Client.Disputes.CreateEvidenceTextAsync(
            new CreateDisputeEvidenceTextRequest
            {
                DisputeId = "dispute_id",
                IdempotencyKey = "ed3ee3933d946f1514d505d173c82648",
                EvidenceType = DisputeEvidenceType.TrackingNumber,
                EvidenceText = "1Z8888888888888888",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateDisputeEvidenceTextResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
