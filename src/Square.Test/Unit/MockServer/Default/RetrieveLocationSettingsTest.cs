using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class RetrieveLocationSettingsTest : BaseMockServerTest
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
              "location_settings": {
                "location_id": "LOCATION_ID_1",
                "customer_notes_enabled": true,
                "policies": [
                  {
                    "uid": "POLICY_ID_1",
                    "title": "Return Policy",
                    "description": "This is my Return Policy"
                  }
                ],
                "branding": {
                  "header_type": "FRAMED_LOGO",
                  "button_color": "#ffffff",
                  "button_shape": "ROUNDED"
                },
                "tipping": {
                  "percentages": [
                    10,
                    15,
                    20
                  ],
                  "smart_tipping_enabled": true,
                  "default_percent": 15,
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Checkout.RetrieveLocationSettingsAsync(
            new RetrieveLocationSettingsRequest { LocationId = "location_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveLocationSettingsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
