using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class RetrieveMerchantSettingsTest : BaseMockServerTest
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
              "merchant_settings": {
                "payment_methods": {
                  "apple_pay": {
                    "enabled": true
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Checkout.RetrieveMerchantSettingsAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveMerchantSettingsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
