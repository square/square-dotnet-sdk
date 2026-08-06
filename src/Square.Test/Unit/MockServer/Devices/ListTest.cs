using NUnit.Framework;
using Square;
using Square.Devices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Devices;

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
              "devices": [
                {
                  "id": "device:995CS397A6475287",
                  "attributes": {
                    "type": "TERMINAL",
                    "manufacturer": "Square",
                    "model": "Square Terminal (1st Gen, v2)",
                    "name": "Square Terminal 5287",
                    "manufacturers_id": "995CS397A6475287",
                    "updated_at": "2025-08-19T13:04:56.335Z",
                    "version": "5.57.0067",
                    "merchant_token": "MLCHNZCBWFDZB"
                  },
                  "components": [
                    {
                      "type": "APPLICATION",
                      "application_details": {
                        "application_type": "TERMINAL_API",
                        "version": "6.77",
                        "session_location": "LMN2K7S3RTOU3"
                      }
                    },
                    {
                      "type": "CARD_READER",
                      "card_reader_details": {
                        "version": "4.1.51"
                      }
                    },
                    {
                      "type": "BATTERY",
                      "battery_details": {
                        "visible_percent": 77,
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
                },
                {
                  "id": "device:998WS21803L03559",
                  "attributes": {
                    "type": "HANDHELD",
                    "manufacturer": "Square",
                    "model": "Square Handheld (1st Gen, v1)",
                    "name": "Square Terminal 3559",
                    "manufacturers_id": "998WS21803L03559",
                    "updated_at": "2025-08-19T12:39:56.335Z",
                    "version": "7.21.0017",
                    "merchant_token": "MLCHXZCBWFGDW"
                  },
                  "components": [
                    {
                      "type": "APPLICATION",
                      "application_details": {
                        "application_type": "TERMINAL_API",
                        "version": "6.77",
                        "session_location": "LMN2K7S3RTOU3"
                      }
                    },
                    {
                      "type": "CARD_READER",
                      "card_reader_details": {
                        "version": "4.5.58"
                      }
                    },
                    {
                      "type": "BATTERY",
                      "battery_details": {
                        "visible_percent": 22,
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
                    "category": "NEEDS_ATTENTION"
                  }
                }
              ],
              "cursor": "GcXjlV2iaizH7R0fMT6wUDbw6l4otigjzx8XOOspUKHo9EPLRByM"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/devices")
                    .WithParam("cursor", "cursor")
                    .WithParam("sort_order", "DESC")
                    .WithParam("limit", "1")
                    .WithParam("location_id", "location_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Devices.ListAsync(
            new ListDevicesRequest
            {
                Cursor = "cursor",
                SortOrder = SortOrder.Desc,
                Limit = 1,
                LocationId = "location_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
