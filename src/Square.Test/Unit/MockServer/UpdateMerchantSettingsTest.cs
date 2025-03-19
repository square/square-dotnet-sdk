using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Checkout;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class UpdateMerchantSettingsTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "merchant_settings": {}
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
              "merchant_settings": {
                "payment_methods": {
                  "apple_pay": {
                    "enabled": false
                  },
                  "google_pay": {
                    "enabled": true
                  },
                  "afterpay_clearpay": {
                    "order_eligibility_range": {
                      "min": {
                        "amount": 100,
                        "currency": "USD"
                      },
                      "max": {
                        "amount": 10000,
                        "currency": "USD"
                      }
                    },
                    "item_eligibility_range": {
                      "min": {
                        "amount": 100,
                        "currency": "USD"
                      },
                      "max": {
                        "amount": 10000,
                        "currency": "USD"
                      }
                    },
                    "enabled": true
                  }
                },
                "updated_at": "2022-06-16T22:25:35.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/merchant-settings")
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

        var response = await Client.Checkout.UpdateMerchantSettingsAsync(
            new UpdateMerchantSettingsRequest { MerchantSettings = new CheckoutMerchantSettings() },
            RequestOptions
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateMerchantSettingsResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
