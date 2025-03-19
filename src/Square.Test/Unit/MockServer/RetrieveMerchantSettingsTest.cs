using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class RetrieveMerchantSettingsTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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

        var response = await Client.Checkout.RetrieveMerchantSettingsAsync(RequestOptions);
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveMerchantSettingsResponse>(mockResponse))
                .UsingPropertiesComparer()
        );
    }
}
