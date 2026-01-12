using NUnit.Framework;
using Square.Default.Checkout.PaymentLinks;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Checkout.PaymentLinks;

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
              "payment_links": [
                {
                  "id": "TN4BWEDJ9AI5MBIV",
                  "version": 2,
                  "description": "description",
                  "order_id": "Qqc6yppGvxVwc46Cch4zHTaJqc4F",
                  "checkout_options": {
                    "ask_for_shipping_address": true
                  },
                  "url": "https://square.link/u/EXAMPLE",
                  "long_url": "long_url",
                  "created_at": "2022-04-26T00:15:15.000Z",
                  "updated_at": "2022-04-26T00:18:24.000Z",
                  "payment_note": "test"
                },
                {
                  "id": "RY5UNCUMPJN5XKCT",
                  "version": 1,
                  "description": "",
                  "order_id": "EmBmGt3zJD15QeO1dxzBTxMxtwfZY",
                  "url": "https://square.link/u/EXAMPLE",
                  "long_url": "long_url",
                  "created_at": "2022-04-11T23:14:59.000Z",
                  "updated_at": "updated_at",
                  "payment_note": "payment_note"
                }
              ],
              "cursor": "MTY1NQ=="
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/payment-links")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.Checkout.PaymentLinks.ListAsync(
            new ListPaymentLinksRequest { Cursor = "cursor", Limit = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
