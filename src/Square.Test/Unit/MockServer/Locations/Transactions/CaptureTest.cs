using NUnit.Framework;
using Square.Locations.Transactions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Locations.Transactions;

[TestFixture]
public class CaptureTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/locations/location_id/transactions/transaction_id/capture")
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Locations.Transactions.CaptureAsync(
                new CaptureTransactionsRequest
                {
                    LocationId = "location_id",
                    TransactionId = "transaction_id",
                }
            )
        );
    }
}
