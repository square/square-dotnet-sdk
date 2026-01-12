using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations;

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
              "locations": [
                {
                  "id": "18YC4JDH91E1H",
                  "name": "Grant Park",
                  "address": {
                    "address_line_1": "123 Main St",
                    "locality": "San Francisco",
                    "administrative_district_level_1": "CA",
                    "postal_code": "94114",
                    "country": "US"
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
                  "business_email": "business_email",
                  "description": "description",
                  "twitter_username": "twitter_username",
                  "instagram_username": "instagram_username",
                  "facebook_url": "facebook_url",
                  "logo_url": "logo_url",
                  "pos_background_url": "pos_background_url",
                  "mcc": "mcc",
                  "full_format_logo_url": "full_format_logo_url"
                },
                {
                  "id": "3Z4V4WHQK64X9",
                  "name": "Midtown",
                  "address": {
                    "address_line_1": "1234 Peachtree St. NE",
                    "locality": "Atlanta",
                    "administrative_district_level_1": "GA",
                    "postal_code": "30309"
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
                  "business_email": "business_email",
                  "description": "Midtown Atlanta store",
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
                  "full_format_logo_url": "full_format_logo_url"
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/locations").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Locations.ListAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListLocationsResponse>(mockResponse)).UsingDefaults()
        );
    }
}
