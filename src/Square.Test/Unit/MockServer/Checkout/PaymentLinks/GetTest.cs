using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Checkout.PaymentLinks;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Checkout.PaymentLinks;

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
              "payment_link": {
                "id": "LLO5Q3FRCFICDB4B",
                "version": 1,
                "description": "description",
                "order_id": "4uKASDATqSd1QQ9jV86sPhMdVEbSJc4F",
                "checkout_options": {
                  "allow_tipping": true,
                  "custom_fields": [
                    {
                      "title": "title"
                    }
                  ],
                  "subscription_plan_id": "subscription_plan_id",
                  "redirect_url": "redirect_url",
                  "merchant_support_email": "merchant_support_email",
                  "ask_for_shipping_address": true,
                  "shipping_fee": {
                    "charge": {}
                  },
                  "enable_coupon": true,
                  "enable_loyalty": true
                },
                "pre_populated_data": {
                  "buyer_email": "buyer_email",
                  "buyer_phone_number": "buyer_phone_number"
                },
                "url": "https://square.link/u/EXAMPLE",
                "long_url": "https://checkout.square.site/EXAMPLE",
                "created_at": "2022-04-26T00:10:29.000Z",
                "updated_at": "updated_at",
                "payment_note": "payment_note"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/payment-links/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Checkout.PaymentLinks.GetAsync(
            new GetPaymentLinksRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetPaymentLinkResponse>(mockResponse)).UsingDefaults()
        );
    }
}
