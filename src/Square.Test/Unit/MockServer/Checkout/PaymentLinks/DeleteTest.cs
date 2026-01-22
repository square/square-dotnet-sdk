using NUnit.Framework;
using Square;
using Square.Checkout.PaymentLinks;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Checkout.PaymentLinks;

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
              ],
              "id": "MQASNYL6QB6DFCJ3",
              "cancelled_order_id": "asx8LgZ6MRzD0fObfkJ6obBmSh4F"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/payment-links/id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Checkout.PaymentLinks.DeleteAsync(
            new DeletePaymentLinksRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeletePaymentLinkResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
