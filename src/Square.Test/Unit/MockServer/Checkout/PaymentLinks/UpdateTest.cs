using NUnit.Framework;
using Square;
using Square.Checkout.PaymentLinks;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Checkout.PaymentLinks;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "payment_link": {
                "version": 1,
                "checkout_options": {
                  "ask_for_shipping_address": true
                }
              }
            }
            """;

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
                "id": "TY4BWEDJ6AI5MBIV",
                "version": 2,
                "description": "description",
                "order_id": "Qqc8ypQGvxVwc46Cch4zHTaJqc4F",
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
                "created_at": "2022-04-26T00:15:15.000Z",
                "updated_at": "2022-04-26T00:18:24.000Z",
                "payment_note": "test"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/payment-links/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Checkout.PaymentLinks.UpdateAsync(
            new UpdatePaymentLinkRequest
            {
                Id = "id",
                PaymentLink = new PaymentLink
                {
                    Version = 1,
                    CheckoutOptions = new CheckoutOptions { AskForShippingAddress = true },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdatePaymentLinkResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
