using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.Cards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.Cards;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "card_nonce": "YOUR_CARD_NONCE",
              "billing_address": {
                "address_line_1": "500 Electric Ave",
                "address_line_2": "Suite 600",
                "locality": "New York",
                "administrative_district_level_1": "NY",
                "postal_code": "10003",
                "country": "US"
              },
              "cardholder_name": "Amelia Earhart"
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
              "card": {
                "id": "icard-card_id",
                "card_brand": "VISA",
                "last_4": "1111",
                "exp_month": 11,
                "exp_year": 2018,
                "cardholder_name": "Amelia Earhart",
                "billing_address": {
                  "address_line_1": "500 Electric Ave",
                  "address_line_2": "Suite 600",
                  "address_line_3": "address_line_3",
                  "locality": "New York",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "NY",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "10003",
                  "country": "US",
                  "first_name": "first_name",
                  "last_name": "last_name"
                },
                "fingerprint": "fingerprint",
                "customer_id": "customer_id",
                "merchant_id": "merchant_id",
                "reference_id": "reference_id",
                "enabled": true,
                "card_type": "UNKNOWN_CARD_TYPE",
                "prepaid_type": "UNKNOWN_PREPAID_TYPE",
                "bin": "bin",
                "created_at": "created_at",
                "disabled_at": "disabled_at",
                "version": 1000000,
                "card_co_brand": "UNKNOWN",
                "issuer_alert": "ISSUER_ALERT_CARD_CLOSED",
                "issuer_alert_at": "issuer_alert_at",
                "hsa_fsa": true
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/customer_id/cards")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.Cards.CreateAsync(
            new CreateCustomerCardRequest
            {
                CustomerId = "customer_id",
                CardNonce = "YOUR_CARD_NONCE",
                BillingAddress = new Address
                {
                    AddressLine1 = "500 Electric Ave",
                    AddressLine2 = "Suite 600",
                    Locality = "New York",
                    AdministrativeDistrictLevel1 = "NY",
                    PostalCode = "10003",
                    Country = Country.Us,
                },
                CardholderName = "Amelia Earhart",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateCustomerCardResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
