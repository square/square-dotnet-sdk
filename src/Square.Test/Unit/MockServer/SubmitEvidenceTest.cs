using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Disputes;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class SubmitEvidenceTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
              "dispute": {
                "dispute_id": "dispute_id",
                "id": "EAZoK70gX3fyvibecLwIGB",
                "amount_money": {
                  "amount": 4350,
                  "currency": "USD"
                },
                "reason": "CUSTOMER_REQUESTS_CREDIT",
                "state": "PROCESSING",
                "due_at": "2022-06-01T00:00:00.000Z",
                "disputed_payment": {
                  "payment_id": "2yeBUWJzllJTpmnSqtMRAL19taB"
                },
                "evidence_ids": [
                  "evidence_ids"
                ],
                "card_brand": "VISA",
                "created_at": "2022-05-18T16:02:15.313Z",
                "updated_at": "2022-05-18T16:02:15.313Z",
                "brand_dispute_id": "100000399240",
                "reported_date": "reported_date",
                "reported_at": "2022-05-18T00:00:00.000Z",
                "version": 4,
                "location_id": "LSY8XKGSMMX94"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes/dispute_id/submit-evidence")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Disputes.SubmitEvidenceAsync(
            new SubmitEvidenceDisputesRequest { DisputeId = "dispute_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SubmitEvidenceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
