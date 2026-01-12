using NUnit.Framework;
using Square.Default.Disputes.Evidence;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Disputes.Evidence;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "evidence": [
                {
                  "evidence_id": "evidence_id",
                  "id": "CpfnkwGselCwS8QFvxN6",
                  "dispute_id": "bVTprrwk0gygTLZ96VX1oB",
                  "evidence_file": {
                    "filename": "customer-interaction",
                    "filetype": "JPG"
                  },
                  "evidence_text": "evidence_text",
                  "uploaded_at": "2022-05-10T15:57:13.802Z",
                  "evidence_type": "CARDHOLDER_COMMUNICATION"
                },
                {
                  "evidence_id": "evidence_id",
                  "id": "TOomLInj6iWmP3N8qfCXrB",
                  "dispute_id": "bVTprrwk0gygTLZ96VX1oB",
                  "evidence_file": {
                    "filename": "",
                    "filetype": ""
                  },
                  "evidence_text": "evidence_text",
                  "uploaded_at": "2022-05-18T16:01:10.000Z",
                  "evidence_type": "REBUTTAL_EXPLANATION"
                }
              ],
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes/dispute_id/evidence")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Disputes.Evidence.ListAsync(
            new ListEvidenceRequest { DisputeId = "dispute_id", Cursor = "cursor" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
