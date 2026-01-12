using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.TransferOrders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.TransferOrders;

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
                    .WithPath("/v2/transfer-orders/transfer_order_id")
                    .WithParam("version", "1000000")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.TransferOrders.DeleteAsync(
            new DeleteTransferOrdersRequest
            {
                TransferOrderId = "transfer_order_id",
                Version = 1000000,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteTransferOrderResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
