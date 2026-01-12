using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations.Transactions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations.Transactions;

[TestFixture]
public class CaptureTest : BaseMockServerTest
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
                    .WithPath("/v2/locations/location_id/transactions/transaction_id/capture")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Locations.Transactions.CaptureAsync(
            new CaptureTransactionsRequest
            {
                LocationId = "location_id",
                TransactionId = "transaction_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CaptureTransactionResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
