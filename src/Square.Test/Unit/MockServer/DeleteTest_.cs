using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class DeleteTest_ : BaseMockServerTest
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

        var response = await Client.TransferOrders.DeleteAsync(
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
