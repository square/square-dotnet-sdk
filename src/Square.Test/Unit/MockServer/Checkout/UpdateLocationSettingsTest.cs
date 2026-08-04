using NUnit.Framework;
using Square;
using Square.Checkout;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Checkout;

[TestFixture]
public class UpdateLocationSettingsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location_settings": {}
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
              "location_settings": {
                "location_id": "LOCATION_ID_1",
                "customer_notes_enabled": false,
                "policies": [
                  {
                    "uid": "POLICY_ID_1",
                    "title": "Return Policy",
                    "description": "This is my Return Policy"
                  },
                  {
                    "uid": "POLICY_ID_2",
                    "title": "Return Policy",
                    "description": "Items may be returned within 30 days of purchase."
                  }
                ],
                "branding": {
                  "header_type": "FRAMED_LOGO",
                  "button_color": "#00b23b",
                  "button_shape": "ROUNDED"
                },
                "tipping": {
                  "percentages": [
                    15,
                    20,
                    25
                  ],
                  "smart_tipping_enabled": true,
                  "default_percent": 20,
                  "smart_tips": [
                    {}
                  ]
                },
                "coupons": {
                  "enabled": true
                },
                "updated_at": "2022-06-16T22:25:35.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/online-checkout/location-settings/location_id")
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

        var response = await Client.Checkout.UpdateLocationSettingsAsync(
            new UpdateLocationSettingsRequest
            {
                LocationId = "location_id",
                LocationSettings = new CheckoutLocationSettings(),
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateLocationSettingsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
