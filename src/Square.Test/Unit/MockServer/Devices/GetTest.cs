using NUnit.Framework;
using Square;
using Square.Core;
using Square.Devices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Devices;

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
              "device": {
                "id": "device:995CS397A6475287",
                "attributes": {
                  "type": "TERMINAL",
                  "manufacturer": "Square",
                  "model": "T2",
                  "name": "Square Terminal 995",
                  "manufacturers_id": "995CS397A6475287",
                  "updated_at": "2023-09-29T13:12:22.365Z",
                  "version": "5.41.0085",
                  "merchant_token": "MLCHXZCBWFGDW"
                },
                "components": [
                  {
                    "type": "APPLICATION",
                    "application_details": {
                      "application_type": "TERMINAL_API",
                      "version": "6.25",
                      "session_location": "LMN2K7S3RTOU3"
                    }
                  },
                  {
                    "type": "CARD_READER",
                    "card_reader_details": {
                      "version": "3.53.70"
                    }
                  },
                  {
                    "type": "BATTERY",
                    "battery_details": {
                      "visible_percent": 5,
                      "external_power": "AVAILABLE_CHARGING"
                    }
                  },
                  {
                    "type": "WIFI",
                    "wifi_details": {
                      "active": true,
                      "ssid": "Staff Network",
                      "ip_address_v4": "10.0.0.7",
                      "secure_connection": "WPA/WPA2 PSK",
                      "signal_strength": {
                        "value": 2
                      }
                    }
                  },
                  {
                    "type": "ETHERNET",
                    "ethernet_details": {
                      "active": false
                    }
                  }
                ],
                "status": {
                  "category": "AVAILABLE"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/devices/device_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Devices.GetAsync(
            new GetDevicesRequest { DeviceId = "device_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetDeviceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
