using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Disputes.Evidence;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Disputes.Evidence;

[TestFixture]
public class DeleteTest : BaseMockServerTest
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes/dispute_id/evidence/evidence_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Disputes.Evidence.DeleteAsync(
            new DeleteEvidenceRequest { DisputeId = "dispute_id", EvidenceId = "evidence_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteDisputeEvidenceResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
