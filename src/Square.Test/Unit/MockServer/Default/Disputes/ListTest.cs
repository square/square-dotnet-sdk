using NUnit.Framework;
using Square.Default;
using Square.Default.Disputes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Disputes;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "disputes": [
                {
                  "dispute_id": "dispute_id",
                  "id": "XDgyFu7yo1E2S5lQGGpYn",
                  "amount_money": {
                    "amount": 2500,
                    "currency": "USD"
                  },
                  "reason": "NO_KNOWLEDGE",
                  "state": "ACCEPTED",
                  "due_at": "2022-07-13T00:00:00.000Z",
                  "disputed_payment": {
                    "payment_id": "zhyh1ch64kRBrrlfVhwjCEjZWzNZY"
                  },
                  "evidence_ids": [
                    "evidence_ids"
                  ],
                  "card_brand": "VISA",
                  "created_at": "2022-06-29T18:45:22.265Z",
                  "updated_at": "2022-07-07T19:14:42.650Z",
                  "brand_dispute_id": "100000809947",
                  "reported_date": "reported_date",
                  "reported_at": "2022-06-29T00:00:00.000Z",
                  "version": 2,
                  "location_id": "L1HN3ZMQK64X9"
                },
                {
                  "dispute_id": "dispute_id",
                  "id": "jLGg7aXC7lvKPr9PISt0T",
                  "amount_money": {
                    "amount": 2209,
                    "currency": "USD"
                  },
                  "reason": "NOT_AS_DESCRIBED",
                  "state": "EVIDENCE_REQUIRED",
                  "due_at": "2022-05-13T00:00:00.000Z",
                  "disputed_payment": {
                    "payment_id": "zhyh1ch64kRBrrlfVhwjCEjZWzNZY"
                  },
                  "evidence_ids": [
                    "evidence_ids"
                  ],
                  "card_brand": "VISA",
                  "created_at": "2022-04-29T18:45:22.265Z",
                  "updated_at": "2022-04-29T18:45:22.265Z",
                  "brand_dispute_id": "r5Of6YaGT7AdeRaVoAGCJw",
                  "reported_date": "reported_date",
                  "reported_at": "2022-04-29T00:00:00.000Z",
                  "version": 1,
                  "location_id": "18YC4JDH91E1H"
                }
              ],
              "cursor": "G1aSTRm48CLjJsg6Sg3hQN1b1OMaoVuG"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes")
                    .WithParam("cursor", "cursor")
                    .WithParam("states", "INQUIRY_EVIDENCE_REQUIRED")
                    .WithParam("location_id", "location_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Disputes.ListAsync(
            new ListDisputesRequest
            {
                Cursor = "cursor",
                States = DisputeState.InquiryEvidenceRequired,
                LocationId = "location_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
