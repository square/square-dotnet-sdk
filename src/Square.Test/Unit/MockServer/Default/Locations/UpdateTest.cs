using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location": {
                "business_hours": {
                  "periods": [
                    {
                      "day_of_week": "FRI",
                      "start_local_time": "07:00",
                      "end_local_time": "18:00"
                    },
                    {
                      "day_of_week": "SAT",
                      "start_local_time": "07:00",
                      "end_local_time": "18:00"
                    },
                    {
                      "day_of_week": "SUN",
                      "start_local_time": "09:00",
                      "end_local_time": "15:00"
                    }
                  ]
                },
                "description": "Midtown Atlanta store - Open weekends"
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
              "location": {
                "id": "3Z4V4WHQK64X9",
                "name": "Midtown",
                "address": {
                  "address_line_1": "1234 Peachtree St. NE",
                  "address_line_2": "address_line_2",
                  "address_line_3": "address_line_3",
                  "locality": "Atlanta",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "GA",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "30309",
                  "country": "ZZ",
                  "first_name": "first_name",
                  "last_name": "last_name"
                },
                "timezone": "America/New_York",
                "capabilities": [
                  "CREDIT_CARD_PROCESSING"
                ],
                "status": "ACTIVE",
                "created_at": "2022-02-19T17:58:25.000Z",
                "merchant_id": "3MYCJG5GVYQ8Q",
                "country": "US",
                "language_code": "en-US",
                "currency": "USD",
                "phone_number": "phone_number",
                "business_name": "Jet Fuel Coffee",
                "type": "PHYSICAL",
                "website_url": "website_url",
                "business_hours": {
                  "periods": [
                    {
                      "day_of_week": "FRI",
                      "start_local_time": "07:00",
                      "end_local_time": "18:00"
                    },
                    {
                      "day_of_week": "SAT",
                      "start_local_time": "07:00",
                      "end_local_time": "18:00"
                    },
                    {
                      "day_of_week": "SUN",
                      "start_local_time": "09:00",
                      "end_local_time": "15:00"
                    }
                  ]
                },
                "business_email": "business_email",
                "description": "Midtown Atlanta store - Open weekends",
                "twitter_username": "twitter_username",
                "instagram_username": "instagram_username",
                "facebook_url": "facebook_url",
                "coordinates": {
                  "latitude": 33.7889,
                  "longitude": -84.3841
                },
                "logo_url": "logo_url",
                "pos_background_url": "pos_background_url",
                "mcc": "7299",
                "full_format_logo_url": "full_format_logo_url",
                "tax_ids": {
                  "eu_vat": "eu_vat",
                  "fr_siret": "fr_siret",
                  "fr_naf": "fr_naf",
                  "es_nif": "es_nif",
                  "jp_qii": "jp_qii"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/locations/location_id")
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

        var response = await Client.Default.Locations.UpdateAsync(
            new UpdateLocationRequest
            {
                LocationId = "location_id",
                Location = new Location
                {
                    BusinessHours = new BusinessHours
                    {
                        Periods = new List<BusinessHoursPeriod>()
                        {
                            new BusinessHoursPeriod
                            {
                                DayOfWeek = Square.Default.DayOfWeek.Fri,
                                StartLocalTime = "07:00",
                                EndLocalTime = "18:00",
                            },
                            new BusinessHoursPeriod
                            {
                                DayOfWeek = Square.Default.DayOfWeek.Sat,
                                StartLocalTime = "07:00",
                                EndLocalTime = "18:00",
                            },
                            new BusinessHoursPeriod
                            {
                                DayOfWeek = Square.Default.DayOfWeek.Sun,
                                StartLocalTime = "09:00",
                                EndLocalTime = "15:00",
                            },
                        },
                    },
                    Description = "Midtown Atlanta store - Open weekends",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateLocationResponse>(mockResponse)).UsingDefaults()
        );
    }
}
