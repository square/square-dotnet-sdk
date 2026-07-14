using NUnit.Framework;
using Square;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class GetTransferTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/transfers/transfer_id")
                    .UsingGet()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Inventory.GetTransferAsync(
                new GetTransferInventoryRequest { TransferId = "transfer_id" }
            )
        );
    }
}
