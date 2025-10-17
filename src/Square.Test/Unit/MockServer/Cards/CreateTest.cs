using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Cards;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Cards;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "4935a656-a929-4792-b97c-8848be85c27c",
              "source_id": "cnon:uIbfJXhXETSP197M3GB",
              "card": {
                "cardholder_name": "Amelia Earhart",
                "billing_address": {
                  "address_line_1": "500 Electric Ave",
                  "address_line_2": "Suite 600",
                  "locality": "New York",
                  "administrative_district_level_1": "NY",
                  "postal_code": "10003",
                  "country": "US"
                },
                "customer_id": "VDKXEEKPJN48QDG3BGGFAK05P8",
                "reference_id": "user-id-1"
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
              "card": {
                "id": "ccof:uIbfJXhXETSP197M3GB",
                "card_brand": "VISA",
                "last_4": "1111",
                "exp_month": 11,
                "exp_year": 2022,
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
                "fingerprint": "ex-p-cs80EK9Flz7LsCMv-szbptQ_ssAGrhemzSTsPFgt9nzyE6t7okiLIQc-qw_quqKX4Q",
                "customer_id": "VDKXEEKPJN48QDG3BGGFAK05P8",
                "merchant_id": "6SSW7HV8K2ST5",
                "reference_id": "user-id-1",
                "enabled": true,
                "card_type": "CREDIT",
                "prepaid_type": "NOT_PREPAID",
                "bin": "411111",
                "version": 1,
                "card_co_brand": "UNKNOWN",
                "issuer_alert": "ISSUER_ALERT_CARD_CLOSED",
                "issuer_alert_at": "issuer_alert_at",
                "hsa_fsa": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cards")
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

        var response = await Client.Cards.CreateAsync(
            new CreateCardRequest
            {
                IdempotencyKey = "4935a656-a929-4792-b97c-8848be85c27c",
                SourceId = "cnon:uIbfJXhXETSP197M3GB",
                Card = new Card
                {
                    CardholderName = "Amelia Earhart",
                    BillingAddress = new Address
                    {
                        AddressLine1 = "500 Electric Ave",
                        AddressLine2 = "Suite 600",
                        Locality = "New York",
                        AdministrativeDistrictLevel1 = "NY",
                        PostalCode = "10003",
                        Country = Country.Us,
                    },
                    CustomerId = "VDKXEEKPJN48QDG3BGGFAK05P8",
                    ReferenceId = "user-id-1",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateCardResponse>(mockResponse)).UsingDefaults()
        );
    }
}
