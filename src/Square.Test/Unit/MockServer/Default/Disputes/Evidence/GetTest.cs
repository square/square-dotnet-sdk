using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Disputes.Evidence;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Disputes.Evidence;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                  "filename": "customer-interaction.jpg",
                  "filetype": "image/jpeg"
                },
                "evidence_text": "evidence_text",
                "uploaded_at": "2022-05-18T16:01:10.000Z",
                "evidence_type": "CARDHOLDER_COMMUNICATION"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes/dispute_id/evidence/evidence_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Disputes.Evidence.GetAsync(
            new GetEvidenceRequest { DisputeId = "dispute_id", EvidenceId = "evidence_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetDisputeEvidenceResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
