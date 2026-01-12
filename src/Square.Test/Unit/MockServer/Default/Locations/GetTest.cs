using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations;

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
              "location": {
                "id": "18YC4JDH91E1H",
                "name": "Grant Park",
                "address": {
                  "address_line_1": "123 Main St",
                  "address_line_2": "address_line_2",
                  "address_line_3": "address_line_3",
                  "locality": "San Francisco",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "CA",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "94114",
                  "country": "US",
                  "first_name": "first_name",
                  "last_name": "last_name"
                },
                "timezone": "America/Los_Angeles",
                "capabilities": [
                  "CREDIT_CARD_PROCESSING"
                ],
                "status": "ACTIVE",
                "created_at": "2016-09-19T17:33:12.000Z",
                "merchant_id": "3MYCJG5GVYQ8Q",
                "country": "US",
                "language_code": "en-US",
                "currency": "USD",
                "phone_number": "+1 650-354-7217",
                "business_name": "Jet Fuel Coffee",
                "type": "PHYSICAL",
                "website_url": "website_url",
                "business_hours": {
                  "periods": [
                    {}
                  ]
                },
                "business_email": "business_email",
                "description": "description",
                "twitter_username": "twitter_username",
                "instagram_username": "instagram_username",
                "facebook_url": "facebook_url",
                "coordinates": {
                  "latitude": 1.1,
                  "longitude": 1.1
                },
                "logo_url": "logo_url",
                "pos_background_url": "pos_background_url",
                "mcc": "mcc",
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Locations.GetAsync(
            new GetLocationsRequest { LocationId = "location_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetLocationResponse>(mockResponse)).UsingDefaults()
        );
    }
}
