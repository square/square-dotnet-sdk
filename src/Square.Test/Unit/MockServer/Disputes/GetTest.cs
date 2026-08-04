using NUnit.Framework;
using Square;
using Square.Core;
using Square.Disputes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Disputes;

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
              "dispute": {
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
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/disputes/dispute_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Disputes.GetAsync(
            new GetDisputesRequest { DisputeId = "dispute_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetDisputeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
